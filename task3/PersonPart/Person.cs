using System;
using System.Collections.Generic;
using task3.CompanyPart.Documents.ContractPart;
using task3.CompanyPart.Interfaces;
using task3.PersonPart.Interfaces;

namespace task3.PersonPart
{
    public class Person
    {

        internal struct PassportData
        {
            internal Guid PersonalId { get; private set; }


            public PassportData(Guid guid) : this()
            {
                this.PersonalId = guid;
            }
        }




        /// <summary>
        /// Person status in a particular PBX company
        /// </summary>
        internal IPBXStatusable PBXStatus { get; set; } = null;


        /// <summary>
        /// Pasport Data
        /// </summary>
        internal PassportData PersonalInfo { get; private set; }


        /// <summary>
        /// CTOR
        /// </summary>
        private Person()
        {
            this.PersonalInfo = new PassportData(Guid.NewGuid());
        }

        /// <summary>
        /// Create Person Instance
        /// </summary>
        /// <returns></returns>
        public static Person CreateInstance()
        {
            return new Person();
        }



        #region EVENTS
        //################################################################################################################




        public event EventHandler OnEnteredToShop;
        public void EnterToShop(CompanyPart.PBXCompanyModel company)
        {
            if (company != null) { OnEnteredToShop?.Invoke(this, EventArgs.Empty); }           
        }


        internal event EventHandler OnSignedAgreement;
        internal void SignAgreement(PBXContractDocument contract)
        {
            OnSignedAgreement?.Invoke(contract, EventArgs.Empty);
        }

        #endregion //EVENTS


        #region EVENT HANDLERS
        //################################################################################################################

        internal void BuyService(object sender, EventArgs e)
        {
            var contract = sender as PBXContractDocument;
            if (contract == null) { return; }

            contract.PassportData = PersonalInfo.PersonalId;

            if (contract.PassportData == null)
            {
                SignAgreement(null);
            }
            else
            {
                SignAgreement(contract);
            }
        }

        #endregion EVENT HANDLERS





    }




    /*
    ЧЕЛОВЕК
    •	Имеет:
    o	список статусов (Статус присваивает Компания (Клиент (по умолчанию) или Абонент)

    •	Функционал:
    o	Зависит от статуса

    */
}

