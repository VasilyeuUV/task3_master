namespace task3.PBXPart
{
    internal class SwitchDeviceBase : HardwareBase
    {

        internal int PortNumber { get; set; } = 0;
        public bool IsConnected { get; set; } = false;



        /// <summary>
        /// CTOR
        /// </summary>
        private SwitchDeviceBase(int number)
        {
            this.PortNumber = number;
        }


        /// <summary>
        /// Create new Terminal
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static SwitchDeviceBase CreateInstance(int number)
        {
            return number < 1
                          ? new SwitchDeviceBase(0)
                          : new SwitchDeviceBase(number);
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
