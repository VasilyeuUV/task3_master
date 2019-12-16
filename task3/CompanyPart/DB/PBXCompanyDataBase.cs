using System;
using System.Collections.Generic;
using System.Linq;
using task3.CompanyPart.DB.BillingPart;
using task3.CompanyPart.DB.ContractPart;
using task3.CompanyPart.Documents;
using task3.CompanyPart.Documents.ContractPart;
using task3.CompanyPart.Interfaces;
using task3.PBXPart;
using task3.Tools;

namespace task3.CompanyPart.DB
{
    internal class PBXCompanyDataBase
    {

        /// <summary>
        /// DB Contract table 
        /// </summary>
        internal HashSet<ContractItem> ContractTable { get; private set; }

        /// <summary>
        /// DB Subscriber table
        /// </summary>
        internal HashSet<SubscriberItem> SubscriberTable { get; private set; }

        /// <summary>
        /// DB Tariff table
        /// </summary>
        internal List<TariffItem> TariffTable { get; private set; }

        /// <summary>
        /// DB Terminal table
        /// </summary>
        internal HashSet<TerminalItem> TerminalTable { get; private set; }

        /// <summary>
        /// DB CallsTable
        /// </summary>
        internal List<CallsItem> CallsTable { get; private set; }

        /// <summary>
        /// CTOR
        /// </summary>
        public PBXCompanyDataBase()
        {
            this.CallsTable = new List<CallsItem>();
            this.ContractTable = new HashSet<ContractItem>();
            this.SubscriberTable = new HashSet<SubscriberItem>();
            this.TariffTable = new List<TariffItem>();
            this.TerminalTable = new HashSet<TerminalItem>();
        }

        internal IEnumerable<IDataable> GetData(int contractId, Const.GetInfo info)
        {

            switch (info)
            {
                case Const.GetInfo.CallReport:
                    return GetCallReport(contractId, DateTime.Now.AddMonths(-1), DateTime.Now);
                default:
                    return null;
            }
        }



        /// <summary>
        /// Get Call information
        /// </summary>
        /// <param name="dtg"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        private IEnumerable<CallReportItem> GetCallReport(int contractId, DateTime dtg, DateTime now)
        {
            var lst = CallsTable.Where(x => x.From == contractId
                                         && x.DTG >= dtg
                                         && x.DTG <= now)
                                .ToList();
            List<CallReportItem> result = new List<CallReportItem>();
            foreach (var item in lst)
            {
                result.Add(new CallReportItem(item));
            }

            return result.OrderByDescending(x => x.CallDTG);

        }









        /// <summary>
        /// Set Data to DB
        /// </summary>
        /// <param name="data"></param>
        internal void SetData(IDataable data)
        {

            var callInfo = data as CallInfo;
            if (callInfo != null) { SetCallInfo(callInfo); return; }


            var tariff = data as TariffModel;
            if (tariff != null) { SetTariff(tariff); return; }

            var terminal = data as TerminalBase;
            if (terminal != null) { SetTerminal(terminal); return; }

            var contract = data as PBXContractDocument;
            if (contract != null) { SaveContract(contract);  return; }

        }

        private void SetCallInfo(CallInfo callInfo)
        {
            CallsItem callItem = new CallsItem();

            var fromContract = GetContract(callInfo.OutNumber);
            var toContract = GetContract(callInfo.IncNumber);
            
            callItem.From = fromContract.Id;
            callItem.To = toContract.Id;
            callItem.DTG = callInfo.BeginCall;
            TimeSpan span = callInfo.EndCall - callItem.DTG;
            callItem.Duration = span.Milliseconds;
            callItem.Cost = callItem.Duration * GetCost(fromContract.TariffId);

            callItem.Id = CallsTable.Count + 1;
            CallsTable.Add(callItem);
        }

        private int GetCost(int tariffId)
        {
            var result = TariffTable.FirstOrDefault(x => x.Id == tariffId);
            return result == null ? Const.DEFAULT_TARIF_COST : result.Cost;
        }

        /// <summary>
        /// Get Contract by terminal number
        /// </summary>
        /// <param name="outNumber">terminal number</param>
        /// <returns></returns>
        private ContractItem GetContract(int number)
        {
            return ContractTable.FirstOrDefault(x => x.TerminalId == number);
        }






        /// <summary>
        /// Set Tariff to DB
        /// </summary>
        /// <param name="data"></param>
        private void SetTariff(TariffModel tariff)
        {
            if (TariffTable.FirstOrDefault(x => x.Name.ToLower() == tariff.Name.ToLower()) == null)
            {
                TariffTable.Add(new TariffItem(TariffTable.Count + 1, tariff));
            }
        }

        /// <summary>
        /// Set terminal to DB
        /// </summary>
        /// <param name="data"></param>
        private void SetTerminal(TerminalBase terminal)
        {
            if (TerminalTable.FirstOrDefault(x => x.Id == terminal.Number) == null)
            {
                TerminalTable.Add(new TerminalItem(terminal));
            }
        }

        /// <summary>
        /// Save contract
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        private void SaveContract(PBXContractDocument contract)
        {
            contract.Id = ContractTable.Count + 1;
            var contractItem = new ContractItem(contract);
            ContractTable.Add(contractItem);

            SubscriberItem subscriber = GetSubscriber(contract);
            subscriber.Contracts.Add(contract.Id);            
        }


                     

        /// <summary>
        /// Get Subscriber
        /// </summary>
        /// <param name="passportData"></param>
        /// <returns></returns>
        private SubscriberItem GetSubscriber(PBXContractDocument contract)
        {
            SubscriberItem subscriber = SubscriberTable.FirstOrDefault(x => x.PassportData == contract.PassportData);
            if (subscriber == null)
            { 
                subscriber = new SubscriberItem(contract);
                SubscriberTable.Add(subscriber);
            }
            return subscriber;
        }


        /// <summary>
        /// Get Tariff
        /// </summary>
        /// <param name="id">tariff id</param>
        /// <returns></returns>
        internal IDataable GetTariff(int id)
        {
            TariffItem t = TariffTable.FirstOrDefault(x => x.Id == id);
            if (t == null) { return null; }

            TariffModel tariff = TariffModel.ConvertToTariff(t);
            return tariff;
        }

    }
}
