using System.Collections.Generic;
using task3.Interfaces;

namespace task3.HumanPart
{
    public class Human
    {
        /// <summary>
        /// Some human personal information
        /// </summary>
        IEnumerable<IPersonalData> _personalDataList = null;


        IEnumerable<IPBXStatusable> _pBXStatuses = null;

    }
}
