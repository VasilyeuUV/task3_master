using System;
using System.Collections.Generic;
using System.Linq;
using task3.CompanyPart.Documents;
using task3.CompanyPart.Documents.ContractPart;
using task3.CompanyPart.Interfaces;
using task3.PBXPart;
using task3.PersonPart;
using task3.Tools;

namespace task3.CompanyPart
{
    internal class CompanyServiceDepartment
    {

        private List<TerminalBase> Terminals { get; set; }
        private TerminalBase selectedTerminal = null;


        /// <summary>
        /// CTOR
        /// </summary>
        internal CompanyServiceDepartment()
        {
            this.Terminals = new List<TerminalBase>();            
        }


        internal delegate void SetDataHandler(IDataable data);
        internal delegate IEnumerable<IDataable> GetDataHandler(int id, Const.GetInfo info);

        internal SetDataHandler SetDataDlgt;
        internal GetDataHandler GetDataDlgt;

        public void RegisterHandler(SetDataHandler dlgt)
        {
            SetDataDlgt = dlgt;
        }
        public void RegisterHandler(GetDataHandler dlgt)
        {
            GetDataDlgt = dlgt;
        }



        /// <summary>
        /// First operations on Create Company
        /// </summary>
        internal void StartWork(PBXCompanyModel company)
        {
            SetDataDlgt(TariffModel.NewTariff());
            this.Terminals = (company.PBX.GetTerminals()).ToList();
            foreach (var item in this.Terminals)
            {
                SetDataDlgt(item);
            }
            company.PBX.PowerOn();
        }
                          

        /// <summary>
        /// 1-st stage: conclusion of an agreement
        /// </summary>
        internal bool AgreementConclusion(Person person)
        {
            if (person == null) { return false; }
            if (person.PBXStatus == null || person.PBXStatus as IPBXStatusable == null) { return false; }

            if (this.Terminals.Count < 1) { return false; }

            OnProposedAgreement += person.BuyService;
            person.PBXStatus.OnSignedAgreement += SubscriberRegistration;

            PBXContractDocument contract = GetPBXContract();
            ProposeAgreement(contract);            

            if (person.PBXStatus as CompanySubscriberBase == null)
            {
                person.PBXStatus = new CompanySubscriberBase(contract);
                (person.PBXStatus as CompanySubscriberBase).OnRequestCallReport += GetCallReport;
            }

            person.TakeTerminal(selectedTerminal);
            this.Terminals.Remove(selectedTerminal);
            selectedTerminal = null;


            return true;
        }












        #region EVENT
        //################################################################################################################

        public event EventHandler OnProposedAgreement;
        private void ProposeAgreement(PBXContractDocument contract)
        {            
            OnProposedAgreement?.Invoke(contract, EventArgs.Empty);
        }



        #endregion //EVENTS


        #region EVENT HANDLERS
        //################################################################################################################


        internal void SubscriberRegistration(object sender, EventArgs e)
        {
            var contract = sender as PBXContractDocument;
            if (contract == null) { return; }

            if (contract.PassportData != null)
            {
                SetDataDlgt(contract);
            }                     
        }



        private IEnumerable<IDataable> GetCallReport(PBXContractDocument contract, Const.GetInfo info)
        {
            if (contract == null) { return null; }
            return GetDataDlgt(contract.Id, info);

        }


        #endregion //EVENT HANDLERS





        /// <summary>
        /// Create new Contract
        /// </summary>
        /// <param name="number">Contract number</param>
        /// <returns></returns>
        private PBXContractDocument GetPBXContract(int number = 0)
        {
            PBXContractDocument contract = new PBXContractDocument();
            contract.Id = number;
            if (number == 0) 
            {
                contract.ContractDate = DateTime.Now;
                contract.Tariff = TariffModel.NewTariff();
                
                selectedTerminal = Terminals.First();
                contract.Terminal = selectedTerminal;
            }
            else 
            {
                //contract.ContractDate = GetContractDate(id);
                //contract.Subscriber = GetContractSubscriber(id);
                //contract.Tariff = GetContractTariff(id);
                //contract.Terminal = GetContractTerminal(id);
            }            
            return contract;
        }

    }
}