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
    }
}
