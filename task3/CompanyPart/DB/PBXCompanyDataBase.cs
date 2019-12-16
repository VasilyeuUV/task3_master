﻿using System;
using System.Collections.Generic;
using System.Linq;
using task3.CompanyPart.DB.BillingPart;
using task3.CompanyPart.DB.ContractPart;
using task3.CompanyPart.Documents;
using task3.CompanyPart.Documents.ContractPart;
using task3.CompanyPart.Interfaces;
using task3.PBXPart;

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

        internal IDataable GetData(int id = 0)
        {
            return null;
        }


        /// <summary>
        /// Set Data to DB
        /// </summary>
        /// <param name="data"></param>
        internal void SetData(IDataable data)
        {
            var tariff = data as TariffModel;
            if (tariff != null) { SetTariff(tariff); return; }

            var terminal = data as TerminalBase;
            if (terminal != null) { SetTerminal(terminal); return; }

            var contract = data as PBXContractDocument;
            if (contract != null) { SaveContract(contract);  return; }

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
