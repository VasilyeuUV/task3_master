using System;
using task3.CompanyPart.Interfaces;
using task3.PBXPart;

namespace task3.CompanyPart.Documents.ContractPart
{
    internal class PBXContractDocument : IDataable
    {

        public int Id { get; set; } = 0;

        /// <summary>
        /// Contract date
        /// </summary>
        internal DateTime ContractDate { get; set; } 

        /// <summary>
        /// Contract termination date
        /// </summary>
        internal DateTime ContractTerminationDate { get; set; }


        /// <summary>
        /// Reference to the Subscriber
        /// </summary>
        internal Guid PassportData { get; set; }


        /// <summary>
        /// Reference to the Tariff
        /// </summary>
        internal TariffModel Tariff { get; set; }


        /// <summary>
        /// Reference to the Terminal
        /// </summary>
        internal TerminalBase Terminal { get; set; }




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
