using task3.CompanyPart.Documents;
using task3.PBXPart;

namespace task3.CompanyPart.Documents.ContractPart
{
    internal class PBXContractModel
    {

        public int Id { get; private set; } = 0;

        /// <summary>
        /// Contract date
        /// </summary>
        public int ContractDate { get; private set; } = 0;

        /// <summary>
        /// Contract termination date
        /// </summary>
        public int ContractTerminationDate { get; set; } = 0;


        /// <summary>
        /// Reference to the Subscriber
        /// </summary>
        public PBXSubscriberModel Subscriber { get; private set; } = null;


        /// <summary>
        /// Reference to the Tariff
        /// </summary>
        public TariffModel Tariff { get; private set; }


        /// <summary>
        /// Reference to the Terminal
        /// </summary>
        public TerminalBase Terminal { get; private set; }

        /*
        ДОГОВОР
        •	Указывается:
        o	Номер договора (здесь будет = Абонентскому номеру)
        o	Номер терминала (здесь будет = Абонентскому номеру)
        o	Идентификатор Клиента

        •	Функционал:
        o	

        •	Генерируемые события:
        o	

        •	Обрабатываемые события:
        o	

         */

    }
}
