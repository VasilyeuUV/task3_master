using System;
using task3.CompanyPart.Documents.ContractPart;

namespace task3.CompanyPart.DB.ContractPart
{
    internal class ContractItem
    {

        /// <summary>
        /// ID 
        /// </summary>
        internal int Id { get; private set; } = 0;

        /// <summary>
        /// Contract number
        /// </summary>
        internal int ContractNumber { get; private set; }

        /// <summary>
        /// Contract created date
        /// </summary>
        internal DateTime CreateData { get; private set; } 

        /// <summary>
        /// Contract terminate date 
        /// </summary>
        internal DateTime CloseDate { get; private set; } = new DateTime();

        /// <summary>
        /// Tariff id
        /// </summary>
        internal int TariffId { get; private set; }

        /// <summary>
        /// Terminal id
        /// </summary>
        internal int TerminalId { get; private set; }


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="contract"></param>
        internal ContractItem(PBXContractDocument contract)
        {
            this.Id = contract.Id;
            this.ContractNumber = contract.Id;
            this.CreateData = contract.ContractDate;
            this.TariffId = contract.Tariff.Id;
            this.TerminalId = contract.Terminal.Number;

        }
         
    }
}
