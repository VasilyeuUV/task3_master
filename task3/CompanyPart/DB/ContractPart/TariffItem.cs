using task3.CompanyPart.Documents;

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
        internal TariffItem(int id, TariffModel tariff)
        {
            this.Id = id;
            this.Name = tariff.Name;
            this.Cost = tariff.Cost;
        }


    }
}
