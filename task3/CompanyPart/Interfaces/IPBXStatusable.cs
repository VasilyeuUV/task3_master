using System;
using task3.CompanyPart.Documents.ContractPart;

namespace task3.CompanyPart.Interfaces
{
    interface IPBXStatusable
    {
        event EventHandler OnSignedAgreement;
        void SignAgreement(PBXContractDocument contract);
    }
}
