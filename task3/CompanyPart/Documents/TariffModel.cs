using task3.CompanyPart.DB.ContractPart;
using task3.CompanyPart.Interfaces;

namespace task3.CompanyPart.Documents
{
    public class TariffModel : IDataable
    {

        /// <summary>
        /// Tariff id for DB
        /// </summary>
        public int Id { get; private set; } = 1;

        /// <summary>
        /// Tarif name
        /// </summary>
        public string Name { get; private set; } = "Basic";

        /// <summary>
        /// Tariff price for 1 minute
        /// </summary>
        internal int Cost { get; private set; } = 1;



        /// <summary>
        /// CTOR
        /// </summary>
        private TariffModel()
        {
        }

        /// <summary>
        /// Create tariff
        /// </summary>
        /// <param name="name">Tariff name</param>
        /// <returns></returns>
        internal static TariffModel NewTariff(string name = "", int cost = 0)
        {
            TariffModel tariff = new TariffModel();
            if (name != "") { tariff.Name = name; }
            if (cost != 0) { tariff.Cost = cost; }
            return tariff;
        }

        /// <summary>
        /// Convert TariffItem To TariffModel
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        internal static TariffModel ConvertToTariff(TariffItem t)
        {
            if (t == null) { return null; }
            TariffModel tariff = new TariffModel();
            tariff.Id = t.Id;
            tariff.Name = t.Name;
            tariff.Cost = t.Cost;
            return tariff;
        }



        /*
        ТАРИФНЫЙ ПЛАН
        •	Имеет:
        o	Id
        o	Название
        o	Плату за звонок

        •	Функционал:
        o	

        •	Генерируемые события:
        o	

        •	Обрабатываемые события:
        o	


        */

    }
}
