using System;
using System.Linq;

namespace task3.PBXPart
{
    internal class ControlDeviceBase : HardwareBase
    {
        private SwitchSystemBase _switchSystem = null;

        internal bool IsReady { get; private set; }
        
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
                    //item.RegisterHandler(
                    //    new SwitchDeviceBase.ConnectionHandler(this.ConnectTo));

                    //item.OnConnected += Switch_OnConnected;
                    item.Connection += Switch_OnConnected;


                }


            }
            else
            {
                IsReady = false;
            }
        }

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
                }
            }
            else    // call
            {
                Console.WriteLine($"--- Control: connection");
                swDeviceTo.ConnectedSwitch = sw.PortNumber;
                sw.ConnectedSwitch = swDeviceTo.PortNumber;
                swDeviceTo.IsConnected = true;
            }
            
            Console.WriteLine($"--- Control: switch {swDeviceTo.PortNumber}: IsPowered {swDeviceTo.IsPowered}; IsConnected {swDeviceTo.IsConnected}");
            return swDeviceTo.IsConnected;
        }





        //private bool ConnectTo(int from, int to)
        //{

        //    SwitchDeviceBase swDeviceFrom = this._switchSystem.SwitchDevices.FirstOrDefault(x => x.PortNumber == from);
        //    Console.WriteLine($"--- Control: switch {swDeviceFrom.PortNumber}: IsPowered{swDeviceFrom.IsPowered}; IsConnected{swDeviceFrom.IsConnected}");

        //    Console.WriteLine("----- calls -----");

        //    SwitchDeviceBase swDeviceTo = this._switchSystem.SwitchDevices.FirstOrDefault(x => x.PortNumber == to);
        //    Console.WriteLine($"--- Control: switch {swDeviceTo.PortNumber}: IsPowered{swDeviceTo.IsPowered}; IsConnected{swDeviceTo.IsConnected}");

        //    if (swDeviceTo == null) { return false; }

        //    Console.WriteLine($"--- find switch {swDeviceTo.PortNumber}");


        //    if (to < 0)
        //    {
        //        Console.WriteLine($"--- switch {swDeviceTo.PortNumber} break connection");
        //        swDeviceTo.IsConnected = false;
        //        return false;
        //    }

        //    if (!swDeviceTo.IsPowered || swDeviceTo.IsConnected) { return false; }
        //    Console.WriteLine($"--- switch {swDeviceTo.PortNumber} set connection");
        //    swDeviceTo.IsConnected = true;
        //    return true;
        //}















        /*
        УПРАВЛЯЮЩЕЕ УСТРОЙСТВО
        Управляет коммутатором
        •	Имеет:
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
