using System;
using task3.CompanyPart.Interfaces;

namespace task3.PBXPart
{
    internal class CallInfo : IDataable
    {

        internal int OutNumber { get; set; }
        internal int IncNumber { get; set; }
        internal DateTime BeginCall { get; set; }
        internal DateTime EndCall { get; set; }

        public int Id { get; set; }

        public CallInfo(int oNumber, int iNumber, DateTime begin)
        {
            this.OutNumber = oNumber;
            this.IncNumber = iNumber;
            this.BeginCall = begin;
        }

    }
}
