using System;
using System.Collections.Generic;
using task3.CompanyPart.Documents.ContractPart;

namespace task3.CompanyPart.DB.ContractPart
{
    internal class SubscriberItem
    {
        /// <summary>
        /// ID 
        /// </summary>
        internal int Id { get; private set; } = 0;

        /// <summary>
        /// Subscriber PassportData
        /// </summary>
        internal Guid PassportData { get; private set; }

        /// <summary>
        /// Subscriber contracts
        /// </summary>
        internal List<int> Contracts { get; private set; } = null;

        /// <summary>
        /// CTOR
        /// </summary>
        public SubscriberItem(PBXContractDocument contract)
        {
            this.PassportData = contract.PassportData;
            this.Contracts = new List<int>
            {
                contract.Id
            };
        }

    }
}
