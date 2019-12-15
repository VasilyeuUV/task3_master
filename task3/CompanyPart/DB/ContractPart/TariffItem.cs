using task3.CompanyPart.Documents.ContractPart;

namespace task3.CompanyPart.DB.ContractPart
{
    internal class TariffItem
    {
        /// <summary>
        /// ID 
        /// </summary>
        internal int Id { get; private set; } = 0;


        /// <summary>
        /// Tariff name
        /// </summary>
        internal string Name { get; private set; }


        /// <summary>
        /// Tariff price 
        /// </summary>
        internal int Cost { get; private set; } = 1;


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="contract"></param>
        internal TariffItem(PBXContractDocument contract)
        {
            this.Name = contract.Tariff.Name;
            this.Cost = contract.Tariff.Cost;
        }


    }
}
