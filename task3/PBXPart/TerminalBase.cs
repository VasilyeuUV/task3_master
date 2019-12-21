using System;
using System.Threading;
using task3.CompanyPart.Interfaces;
using task3.PBXPart.Interfaces;
using task3.Tools;
using static task3.PBXPart.Interfaces.ITerminal;

namespace task3.PBXPart
{
    /// <summary>
    /// 
    /// </summary>
    public class TerminalBase : HardwareBase, IDataable
    {

        public int Id { get; private set; }

        /// <summary>
        /// Terminal number
        /// </summary>
        internal int Number { get; set; }

        public bool IsReady { get; internal set; }

        internal delegate bool CallHandler(int number, bool end = false);
        internal CallHandler CallDlgt;

        internal void RegisterHandler(CallHandler dlgt)
        {
            CallDlgt = dlgt;
        }


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="number"></param>
        private TerminalBase(int number)
        {
            this.Id = number;
            this.Number = number;

            this.OnPowerChange += TerminalBase_OnPowerChange;
        }

        /// <summary>
        /// Create new Terminal
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static TerminalBase CreateInstance(int number)
        {
            if (number < 1) { number = 0; }
            TerminalBase terminal = new TerminalBase(number);
            //TerminalBase.OnCreated?.Invoke(terminal, EventArgs.Empty);
            return terminal;
        }
        

        private void TerminalBase_OnPowerChange()
        {
            if (this.IsPowered)
            {
                IsReady = true;
            }
            else
            {
                IsReady = false;
            }
        }


        internal void Call(int number)
        {

            if (number == this.Number)
            {
                Console.WriteLine($"--- wrong number");
                return;
            }

            Console.WriteLine("-- CALLING --");
            Console.WriteLine($"-- terminal {this.Number} IsPowered: {this.IsPowered}; IsReady: {this.IsReady};");
            Console.WriteLine($"-- terminal {this.Number} call terminal {number}");
            this.IsReady = !CallDlgt(number);
            Console.WriteLine($"-- terminal {this.Number} IsPowered: {this.IsPowered}; IsReady: {this.IsReady};");
            if (!this.IsReady)
            {
                Thread.Sleep(Const.RND.Next(0, 1000));
                Console.WriteLine("-- BREAKING --");
                Console.WriteLine($"-- terminal {this.Number} IsPowered: {this.IsPowered}; IsReady: {this.IsReady};");
                Console.WriteLine($"-- terminal {this.Number} break terminal {number}");
                this.IsReady = !CallDlgt(number, true);           // as call break
            }
            Console.WriteLine($"-- terminal {this.Number} IsPowered: {this.IsPowered}; IsReady: {this.IsReady};");
            Console.WriteLine($"-- terminal {this.Number} end call");
        }        
    }
}
