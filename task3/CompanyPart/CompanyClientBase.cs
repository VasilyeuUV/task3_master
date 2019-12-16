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





        /*
        КЛИЕНТ КОМПАНИИ – ОПЕРАТОРА АТС – ЭТО СТАТУС ЧЕЛОВЕКА
        •	Имеет:
        o	

        •	Функционал:
        o	

        •	Генерируемые события:
        o	Заключение Договора

        •	Обрабатываемые события:
        o	

         */

    }
}
