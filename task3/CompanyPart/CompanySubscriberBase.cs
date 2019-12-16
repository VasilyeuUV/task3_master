using System;
using System.Collections.Generic;
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
        internal virtual IEnumerable<PBXContractDocument> Contracts { get; set; }


        /// <summary>
        /// Link to Terminals
        /// </summary>
        internal virtual IEnumerable<TerminalBase> Terminals { get; set; }



        List<CallReportItem> callReport = null;



        // EVENTS
        public event EventHandler OnSignedAgreement;

        public void SignAgreement(PBXContractDocument contract)
        {
            OnSignedAgreement?.Invoke(contract, EventArgs.Empty);
        }



        public delegate IEnumerable<IDataable> RequestCallReportHandler(PBXContractDocument contract, Const.GetInfo info);
        public event RequestCallReportHandler OnRequestCallReport;
        public IEnumerable<IDataable> RequestCallReport(PBXContractDocument contract, Const.GetInfo info)
        {
            return OnRequestCallReport?.Invoke(contract, Const.GetInfo.CallReport);
        }
    }
}
