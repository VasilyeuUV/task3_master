using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3.PBXPart
{
    internal class SwitchDeviceBase
    {

        internal int PortNumber { get; set; } = 0;

        internal bool IsPowered { get; set; } = false;

        public bool IsConnected { get; set; } = false;


        private SwitchDeviceBase()
        {
        }


        internal static SwitchDeviceBase CreateInstance()
        {
            return new SwitchDeviceBase();
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
