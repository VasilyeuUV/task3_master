﻿using System.Collections.Generic;
using task3.PersonPart.Interfaces;

namespace task3.PersonPart
{
    public class Person
    {
        /// <summary>
        /// Some personal information of a person
        /// </summary>
        private IEnumerable<IPersonalData> _personalDataList = null;

        /// <summary>
        /// Person status in a particular PBX company
        /// </summary>
        private IEnumerable<IPBXStatusable> _pBXStatuses = null;

    }
}
