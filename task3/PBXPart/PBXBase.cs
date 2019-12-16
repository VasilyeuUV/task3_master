using System;
using System.Collections.Generic;
using task3.Tools;

namespace task3.PBXPart
{
    /// <summary>
    /// Any PBX
    /// </summary>
    public class PBXBase : HardwareBase
    {

        private ControlDeviceBase _controlDevice = null;


        private SwitchSystemBase _switchSystem = null;

        internal ControlDeviceBase ControlDevice { get => _controlDevice;}



        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="terminal_count"></param>
        private PBXBase()
        {
            this._switchSystem = SwitchSystemBase.CreateInstance(Const.SWITCHDEVICE_COUNT_DEFAULT);
            this._controlDevice = new ControlDeviceBase(ref this._switchSystem);

            this.OnPowerChange += PBXBase_OnPowerChange;
        }

        /// <summary>
        /// Power control
        /// </summary>
        private void PBXBase_OnPowerChange()
        {
            if (this.IsPowered)
            {
                this._controlDevice.PowerOn();
                this._switchSystem.PowerOn();
            }
            else
            {
                this._controlDevice.PowerOff();
                this._switchSystem.PowerOff();
            }
        }

        /// <summary>
        /// Create new PBX
        /// </summary>
        /// <returns></returns>
        internal static PBXBase CreateInstance() 
        {
            return new PBXBase(); 
        }



        /// <summary>
        /// Get terminals from SwitchSystem
        /// </summary>
        /// <returns></returns>
        internal IEnumerable<TerminalBase> GetTerminals()
        {
            List<TerminalBase> lst = new List<TerminalBase>();
            foreach (var item in this._switchSystem.SwitchDevices)
            {
                lst.Add(item.Terminal);
            }
            return lst;
        }



        /// <summary>
        /// Set terminals
        /// </summary>
        /// <param name="terminal_count">number of added terminals</param>
        /// <returns>terminals list</returns>
        //private static IEnumerable<TerminalBase> SetTerminals(int terminal_count = 1)
        //{
        //    List<TerminalBase> lst = new List<TerminalBase>();
        //    for (int i = 0; i < terminal_count; i++)
        //    {
        //        lst.Add(TerminalBase.CreateInstance(i + 1));
        //    }
        //    return lst;
        //}












        // События:
        // - поступление вызова
        // - установление связи
        // - прекращение связи (отбой)
        //


        /*
        АТС
        В состав АТС входят: 
        - коммутационная система
        - управляющие устройства; 
        - вводные устройства для подключения телефонных линий связи к коммутационной системе;
        - установка электрического питания; 
        - вспомогательные устройства (вентиляционные, отопительные и пр.).
        выбор соединительного пути осуществляется на основании информации о номере вызываемого абонента, 
        которая поступает от телефонного аппарата, вызывающего абонента.


        •	Имеет:
        o	Управляющее устройство (выбирает свободные порты)
        o	Коммутационная система (порты для подключения терминала)
        o	Состояния:
        	Вкл. / откл.;

        •	Функционал:
        o	Взаимодействие с терминалами на основе событийной модели
        o	Отслеживание изменения состояния порта (вкл, откл, звонок, …)
        o	Соединение абонентов (может быть терминалов?) с учетом состояния порта

        */
    }
}
