using System;
using task3.CompanyPart.Documents.ContractPart;
using task3.CompanyPart.Interfaces;

namespace task3.CompanyPart
{
    internal class CompanyClientBase : IPBXStatusable
    {


        // EVENTS
        public event EventHandler OnSignedAgreement;

        public void SignAgreement(PBXContractDocument contract)
        {
            OnSignedAgreement?.Invoke(contract, EventArgs.Empty);
        }
    }
}
