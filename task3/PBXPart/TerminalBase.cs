namespace task3.PBXPart
{
    class TerminalBase : HardwareBase
    {

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
            this.Number = number;
        }

        /// <summary>
        /// Create new Terminal
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static TerminalBase CreateInstance(int number) => number < 1
            ? new TerminalBase(0)
            : new TerminalBase(number);







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
