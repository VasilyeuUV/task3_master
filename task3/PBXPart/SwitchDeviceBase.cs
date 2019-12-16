using System;

namespace task3.PBXPart
{
    internal class SwitchDeviceBase : HardwareBase
    {
        private TerminalBase _terminal = null;

        internal int PortNumber { get; private set; } = 0;
        public bool IsConnected { get; set; } = false;
        public TerminalBase Terminal { get => _terminal; }

        


        /// <summary>
        /// CTOR
        /// </summary>
        private SwitchDeviceBase(int number)
        {
            this.PortNumber = number;
            this._terminal = TerminalBase.CreateInstance(number);
        }


        /// <summary>
        /// Create new Terminal
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static SwitchDeviceBase CreateInstance(int number)
        {            
            if (number < 1) { number = 0; }
            SwitchDeviceBase switchDevice = new SwitchDeviceBase(number);
            return switchDevice;
        }









        /*
        ПОРТ ДЛЯ ПОДКЛЮЧЕНИЯ ТЕРМИНАЛА

        •	Имеет:
        o	Состояния:
        	Вкл. / откл.;
        	Занят / свободен
        •	Функционал:
        o	

        •	Генерируемые события:
        o	

        •	Обрабатываемые события:
        o	


        */
    }
}
