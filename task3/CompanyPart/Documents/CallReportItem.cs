using System;
using task3.CompanyPart.DB.BillingPart;
using task3.CompanyPart.Interfaces;

namespace task3.CompanyPart.Documents
{
    internal class CallReportItem : IDataable
    {
        public int Id { get; set; }        

        /// <summary>
        /// Call DateTime
        /// </summary>
        internal DateTime CallDTG { get; private set; }

        /// <summary>
        /// Call duration in second
        /// </summary>
        internal int CallDuration { get; private set; }

        /// <summary>
        /// Call cost in smallest monetary units
        /// </summary>
        internal int Cost { get; private set; }

        /// <summary>
        /// Outgoing number
        /// </summary>
        internal int OutNumber { get; private set; }

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="item"></param>
        internal CallReportItem(CallsItem item)
        {
            this.CallDTG = item.DTG;
            this.CallDuration = item.Duration;
            this.Cost = item.Cost;
            this.OutNumber = item.To;
        }


    }
}
