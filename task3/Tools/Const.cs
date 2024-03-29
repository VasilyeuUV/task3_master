﻿using System;
using task3.CompanyPart.DB.ContractPart;

namespace task3.Tools
{
    internal static class Const
    {

        internal const int SWITCHDEVICE_COUNT_DEFAULT = 5;
        internal const int DEFAULT_TARIF_COST = 1;

        internal static readonly Random RND = new Random();

        internal enum GetInfo
        {
            CallReport = 1
        }

        internal enum ViewInfo
        {
            ByDate = 1,
            ByNumber,
            ByCost
        }

    }
}
