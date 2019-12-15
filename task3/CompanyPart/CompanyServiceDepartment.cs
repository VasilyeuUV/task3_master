using System;
using task3.CompanyPart.Documents;
using task3.CompanyPart.Documents.ContractPart;
using task3.CompanyPart.Interfaces;
using task3.PersonPart;

namespace task3.CompanyPart
{
    internal class CompanyServiceDepartment
    {


        /// <summary>
        /// 1-st stage: conclusion of an agreement
        /// </summary>
        internal void AgreementConclusion(Person person)
        {
            if (person == null) { return; }
            if (person.PBXStatus == null || person.PBXStatus as IPBXStatusable == null) { return; }

            OnProposedAgreement += person.BuyService;
            person.PBXStatus.OnSignedAgreement += SubscriberRegistration;

            ProposeAgreement();

            if (person.PBXStatus as CompanySubscriberBase == null)
            {
                person.PBXStatus = new CompanySubscriberBase();
            }
        }



        #region EVENT
        //################################################################################################################

        public event EventHandler OnProposedAgreement;
        private void ProposeAgreement()
        {
            PBXContractDocument contract = GetPBXContract();
            OnProposedAgreement?.Invoke(contract, new EventArgs());
        }



        #endregion //EVENTS


        #region EVENT HANDLERS
        //################################################################################################################


        internal void SubscriberRegistration(object sender, EventArgs e)
        {
            var contract = sender as PBXContractDocument;
            if (contract == null) { return; }





        }


        #endregion //EVENT HANDLERS





        /// <summary>
        /// Create new Contract
        /// </summary>
        /// <returns></returns>
        private PBXContractDocument GetPBXContract(int id = 0)
        {
            PBXContractDocument contract = new PBXContractDocument();
            contract.Id = id;
            if (id == 0) 
            {
                contract.ContractDate = DateTime.Now;
                contract.Tariff = TariffModel.NewTariff();
               // contract.Terminal = TerminalBase.GetTerminal();
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