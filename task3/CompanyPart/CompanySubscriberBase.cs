using System;
using System.Collections.Generic;
using System.Linq;
using task3.CompanyPart.Documents;
using task3.CompanyPart.Documents.ContractPart;
using task3.CompanyPart.Interfaces;
using task3.PBXPart;
using task3.Tools;

namespace task3.CompanyPart
{
    internal class CompanySubscriberBase : IPBXStatusable
    {

        public int Id { get; set; }


        /// <summary>
        /// Link to Contracts
        /// </summary>
        internal virtual ICollection<PBXContractDocument> Contracts { get; private set; }
        
        /// <summary>
        /// Link to Terminals
        /// </summary>
        internal virtual IEnumerable<TerminalBase> Terminals { get; set; }
        

        public CompanySubscriberBase(PBXContractDocument contract)
        {
            this.Contracts = new List<PBXContractDocument> { contract };
        }



        // EVENTS
        public event EventHandler OnSignedAgreement;

        public void SignAgreement(PBXContractDocument contract)
        {
            OnSignedAgreement?.Invoke(contract, EventArgs.Empty);
        }



        public delegate IEnumerable<IDataable> RequestCallReportHandler(PBXContractDocument contract, Const.GetInfo info);
        public event RequestCallReportHandler OnRequestCallReport;
        public IEnumerable<CallReportItem> RequestCallReport(PBXContractDocument contract, Const.GetInfo info)
        {
            var result = OnRequestCallReport?.Invoke(contract, Const.GetInfo.CallReport);
            return ConvertToCallReport(result);
        }


        private IEnumerable<CallReportItem> ConvertToCallReport(IEnumerable<IDataable> lst)
        {
            List<CallReportItem> result = new List<CallReportItem>();
            foreach (var item in lst)
            {
                result.Add(item as CallReportItem);
            }
            return result;
        }

        internal IEnumerable<CallReportItem> SortReportByData(IEnumerable<CallReportItem> lst)
        {
            return lst.OrderByDescending(x => x.CallDTG);
        }

        internal IEnumerable<CallReportItem> SortReportByNumber(IEnumerable<CallReportItem> lst)
        {
            return lst.OrderBy(x => x.OutNumber);
        }

        internal IEnumerable<CallReportItem> SortReportByCost(IEnumerable<CallReportItem> lst)
        {
            return lst.OrderByDescending(x => x.Cost);
        }
    }
}
