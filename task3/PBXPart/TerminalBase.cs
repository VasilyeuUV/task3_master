using System;
using task3.CompanyPart.Interfaces;

namespace task3.PBXPart
{
    public class TerminalBase : HardwareBase, IDataable
    {

        public int Id { get; private set; }

        /// <summary>
        /// Terminal number
        /// </summary>
        internal int Number { get; set; }

        


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="number"></param>
        private TerminalBase(int number)
        {
            this.Id = number;
            this.Number = number;
        }

        /// <summary>
        /// Create new Terminal
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static TerminalBase CreateInstance(int number)
        {
            if (number < 1) { number = 0; }
            TerminalBase terminal = new TerminalBase(number);
            //TerminalBase.OnCreated?.Invoke(terminal, EventArgs.Empty);
            return terminal;
        }


        //internal static event EventHandler OnCreated;





        /*
        ТЕРМИНАЛ (ТЕЛЕФОН):
        •	Имеет:
        o	Уникальный Абонентский номер (один терминал – один абонентский номер)

        •	Функционал:
        o	Взаимодействие со станцией на основе событийной модели

        •	Генерируемые события:
        o	Запрос к АТС на установление связи с другим Терминалом
        o	

        •	Обрабатываемые события:
        o	


        */

    }
}
