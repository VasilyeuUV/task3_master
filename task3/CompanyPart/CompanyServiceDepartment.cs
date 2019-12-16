using System;
using System.Collections.Generic;
using System.Linq;
using task3.CompanyPart.Documents;
using task3.CompanyPart.Documents.ContractPart;
using task3.CompanyPart.Interfaces;
using task3.PBXPart;
using task3.PersonPart;

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
        internal delegate IDataable GetDataHandler(int id);

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

            ProposeAgreement();            

            if (person.PBXStatus as CompanySubscriberBase == null)
            {
                person.PBXStatus = new CompanySubscriberBase();
            }

            person.TakeTerminal(selectedTerminal);
            this.Terminals.Remove(selectedTerminal);
            selectedTerminal = null;


            return true;
        }






        #region EVENT
        //################################################################################################################

        public event EventHandler OnProposedAgreement;
        private void ProposeAgreement()
        {
            PBXContractDocument contract = GetPBXContract();
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














        private void SubscriberAdd(Person person)
        {
            //int contractNumber = GetContract(person) + 1;            // получить номер договора
            //TerminalBase terminal = GetTerminal(contractNumber);     // закрепить терминал за  

        }

        private void SubscriberRemove(Person person)
        {
            //int contractNumber = GetContract(person);            // получить номер договора

            //if (contractNumber < 1)
            //{
            //    foreach (var item in collection)
            //    {
            //        RemoveContract(item);
            //    }
            //    return;
            //}
            //RemoveContract(contractNumber);            
        }
















        /*
           Отдел обслуживания КОМПАНИИ – ОПЕРАТОРА АТС:
           •	Имеет:
           o	

           •	Услуги (методы):
           o	Регистрация Клиента (Абонента):
                - регистрация Договора (присваивание номера, внесение в БД);
                - изменение статуса Персоны с Клиента на Абонента (если не Абонент);
                - внесение Абонента в БД;
                - выдача Абоненту Терминала;
                -
           o	Предложение контракта
           o	Внесение информации по контракту в БД
           o	Выдача Абоненту Терминала (телефона) 
           o	Расторжение контракта
           o	Выдача части информации из Базы данных (так правильнее, чем доступ Абонента к БД)

           •	Функционал:
           o	Формирование базовой информации для Биллинговой системы:
               	присваивание клиенту Номера (Клиент станет Абонентом)
               	присваивание аппарату Абонентского номера
               	присваивание Договору Номера
           o	выдача каждому Абоненту терминала (телефона)           

           •	Генерируемые события:
           o	Изменение статуса Человека
           o	Расторжение договора

           •	Обрабатываемые события:
           o	Заключение Клиентом или Абонентом Договора

           */
    }
}