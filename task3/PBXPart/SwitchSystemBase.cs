using System.Collections.Generic;

namespace task3.PBXPart
{

    /// <summary>
    /// PBX Switching system base variant
    /// </summary>
    internal class SwitchSystemBase : HardwareBase
    {

        /// <summary>
        /// Number of SwitchDevices in SwitchSystem
        /// </summary>
        internal IEnumerable<SwitchDeviceBase> SwitchDevices { get; private set; } = null;

        
        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="switchDeviceCount"></param>
        private SwitchSystemBase()
        {
        }



        /// <summary>
        /// Create new SwitchSystem
        /// </summary>
        /// <param name="switchDeviceCount">number of SwitchDevices in SwitchSystem</param>
        /// <returns></returns>
        internal static SwitchSystemBase CreateInstance(int switchDeviceCount = 1)
        {
            List<SwitchDeviceBase> lst = new List<SwitchDeviceBase>();
            for (int i = 0; i < switchDeviceCount; i++)
            {
                lst.Add(SwitchDeviceBase.CreateInstance(i + 1));
            }
            var swSys = new SwitchSystemBase();
            swSys.SwitchDevices = lst;
            return swSys;
        }






        /*
        КОММУТАТОР 
        •	Имеет:
        o	Список Портjd для подключения
        o	Состояния:
        	Вкл. / откл.;
        •	Функционал:
        o	

        •	Генерируемые события:
        o	

        •	Обрабатываемые события:
        o	

        */
    }
}
