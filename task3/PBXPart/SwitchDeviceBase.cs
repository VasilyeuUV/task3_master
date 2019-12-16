using System;

namespace task3.PBXPart
{
    internal class SwitchDeviceBase : HardwareBase
    {
        private TerminalBase _terminal = null;

        internal int PortNumber { get; private set; } = 0;

        internal int ConnectedSwitch { get; set; } = -1;

        public bool IsConnected { get; set; } = false;
        public TerminalBase Terminal { get => _terminal; }


        internal delegate bool ConnectionHandler(SwitchDeviceBase sw, int to, bool end );
        internal event ConnectionHandler Connection;

        internal bool ConnectTo(int to, bool end)
        {
            Console.WriteLine($"--- switch {this.PortNumber}: IsPowered - {this.IsPowered}; IsConnected - {this.IsConnected};");
            this.IsConnected = Connection.Invoke(this, to, end);
            Console.WriteLine($"--- switch {this.PortNumber}: IsPowered - {this.IsPowered}; IsConnected - {this.IsConnected};");
            return this.IsConnected;
        }





        //internal delegate bool ConnectionHandler(int from, int to);
        //internal ConnectionHandler ConnectionDlgt;
        //public void RegisterHandler(ConnectionHandler dlgt)
        //{
        //    ConnectionDlgt = dlgt;
        //}


        /// <summary>
        /// CTOR
        /// </summary>
        private SwitchDeviceBase(int number)
        {
            this.PortNumber = number;
            this._terminal = TerminalBase.CreateInstance(number);

            this.OnPowerChange += SwitchDeviceBase_OnPowerChange;
            //this.OnConnected += SwitchDeviceBase_OnConnected;

            this._terminal.RegisterHandler(
                new TerminalBase.CallHandler(this.ConnectTo));
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




        private void SwitchDeviceBase_OnPowerChange()
        {
            if (this.IsPowered)
            {
                IsConnected = false;
                //this.Terminal.OnPowerChange += Terminal_OnPowerChange;
            }
            else
            {
                IsConnected = false;
                //this.Terminal.OnPowerChange -= Terminal_OnPowerChange;
            }
        }

        //private void Terminal_OnPowerChange()
        //{
        //    if (this.Terminal.IsPowered)
        //    {
        //        IsConnected = false;
        //        OnConnected();
        //    }
        //    else
        //    {
        //        IsConnected = false;
        //        OnConnected();
        //    }
        //}


        //private void SwitchDeviceBase_OnConnected()
        //{
        //    Console.WriteLine($"--- switch {this.PortNumber}: IsPowered {this.IsPowered}; IsConnected {this.IsConnected}");
        //    if (this.IsConnected)
        //    {
        //        this.Terminal.IsReady = false;
        //    }
        //    else
        //    {
        //        this.Terminal.IsReady = true;
        //    }
        //    Console.WriteLine($"--- switch {this.PortNumber}: IsPowered{this.IsPowered}; IsConnected{this.IsConnected}");
        //}








        //private bool ConnectTo(int number)
        //{            

        //    if (!this.IsPowered) { return false; }
        //    if (this.IsConnected && number >= 0) { return false; }

        //    if (number < 0) // break signal
        //    {
        //        Console.WriteLine($"--- switch {this.PortNumber} break switch {number}");
        //        IsConnected = false;
        //    }
        //    else
        //    {
        //        Console.WriteLine($"--- switch {this.PortNumber} connectto switch {number}");
        //        IsConnected = true;                
        //    }
        //    return ConnectionDlgt(this.PortNumber, number);
        //}













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
