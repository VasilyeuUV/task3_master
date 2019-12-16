using System;
using task3.PBXPart;

namespace task3.CompanyPart.DB.BillingPart
{
    internal class CallsItem
    {        

        /// <summary>
        /// ID 
        /// </summary>
        internal int Id { get; set; } = 0;


        /// <summary>
        /// Outgoing Call Contract ID
        /// </summary>
        internal int From { get; set; } = 0;

        /// <summary>
        /// Incoming Call Contract ID
        /// </summary>
        internal int To { get; set; } = 0;

        /// <summary>
        /// Call Duration 
        /// </summary>
        internal int Duration { get; set; } = 0;

        /// <summary>
        /// Call DateTime
        /// </summary>
        internal DateTime DTG { get; set; }


        /// <summary>
        /// Call cost
        /// </summary>
        internal int Cost { get; set; } = 0;

    }
}
