using System;

namespace task3.CompanyPart.DB.BillingPart
{
    internal class CallsItem
    {
        /// <summary>
        /// ID 
        /// </summary>
        internal int Id { get; private set; } = 0;


        /// <summary>
        /// From
        /// </summary>
        internal int From { get; private set; } = 0;

        /// <summary>
        /// To
        /// </summary>
        internal int To { get; private set; } = 0;

        /// <summary>
        /// Call Duration 
        /// </summary>
        internal int Duration { get; private set; } = 0;

        /// <summary>
        /// Call DateTime
        /// </summary>
        internal DateTime DTG { get; private set; }


        /// <summary>
        /// Call cost
        /// </summary>
        internal int Cost { get; private set; } = 0;
    }
}
