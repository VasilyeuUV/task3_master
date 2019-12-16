using System;
using System.Linq;
using task3.CompanyPart.Interfaces;

namespace task3.PBXPart
{
    internal class ControlDeviceBase : HardwareBase
    {
        private SwitchSystemBase _switchSystem = null;

        internal bool IsReady { get; private set; }

        private CallInfo _callInfo = null;


        internal delegate void CallFinishedHandler(IDataable info);
        internal event CallFinishedHandler OnCallFinished;


        internal ControlDeviceBase(ref SwitchSystemBase _switchSystem)
        {
            this._switchSystem = _switchSystem;
            this.OnPowerChange += ControlDeviceBase_OnPowerChange; 
        }




        /// <summary>
        /// Control Devise On powered event
        /// </summary>
        private void ControlDeviceBase_OnPowerChange()
        {
            if (this.IsPowered)
            {
                IsReady = true;
                foreach (var item in this._switchSystem.SwitchDevices)
                {
                    item.Connection += Switch_OnConnected;
                }
            }
            else
            {
                IsReady = false;
            }
        }

        /// <summary>
        /// On Connected handler
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="to"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private bool Switch_OnConnected(SwitchDeviceBase sw, int to, bool end)
        {
            //Console.WriteLine($"--- Control: switch {sw.PortNumber}: IsPowered {sw.IsPowered}; IsConnected {sw.IsConnected}");
            //Console.WriteLine("----- calls -----");           

            SwitchDeviceBase swDeviceTo = this._switchSystem.SwitchDevices.FirstOrDefault(x => x.PortNumber == to);
            if (swDeviceTo == null) { return false; }
            if (!swDeviceTo.IsPowered) { return false; }
            Console.WriteLine($"--- Control: switch {swDeviceTo.PortNumber}: IsPowered {swDeviceTo.IsPowered}; IsConnected {swDeviceTo.IsConnected}");

            if (end)
            {
                if (swDeviceTo.ConnectedSwitch == sw.PortNumber)
                {
                    Console.WriteLine($"--- Control: breaking");
                    swDeviceTo.ConnectedSwitch = -1;
                    sw.ConnectedSwitch = -1;
                    swDeviceTo.IsConnected = false;

                    this._callInfo.EndCall = DateTime.Now;
                    OnCallFinished(this._callInfo);
                }
            }
            else    // call
            {
                Console.WriteLine($"--- Control: connection");
                swDeviceTo.ConnectedSwitch = sw.PortNumber;
                sw.ConnectedSwitch = swDeviceTo.PortNumber;
                swDeviceTo.IsConnected = true;

                this._callInfo = new CallInfo(sw.PortNumber, swDeviceTo.PortNumber, DateTime.Now);
            }

            Console.WriteLine($"--- Control: switch {swDeviceTo.PortNumber}: IsPowered {swDeviceTo.IsPowered}; IsConnected {swDeviceTo.IsConnected}");
            return swDeviceTo.IsConnected;
        }
    }
}
