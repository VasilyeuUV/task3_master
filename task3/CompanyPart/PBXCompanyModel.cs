﻿using System;
using task3.CompanyPart.DB;
using task3.PBXPart;
using task3.PersonPart;

namespace task3.CompanyPart
{
    public class PBXCompanyModel
    {
        // The company components
        private PBXBase _pBX = null;                              // АТС
        private PBXCompanyDataBase _companyDB = null;             // База данных компании

        /// <summary>
        /// Отдел обслуживания
        /// </summary>
        internal CompanyServiceDepartment Service { get; private set; }
        internal PBXBase PBX { get => _pBX; }


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="tERMINAL_COUNT_DEFAULT"></param>
        private PBXCompanyModel()
        {
            this._pBX = PBXBase.CreateInstance();
            this._companyDB = new PBXCompanyDataBase();
            this.Service = new CompanyServiceDepartment();
        }

        /// <summary>
        /// Create new PBXCompanyModel object
        /// </summary>
        /// <returns></returns>
        internal static PBXCompanyModel CreateInstance()
        {
            PBXCompanyModel company = new PBXCompanyModel(); 

            company.Service.RegisterHandler(
                new CompanyServiceDepartment.SetDataHandler(company._companyDB.SetData));
            company.Service.RegisterHandler(
                new CompanyServiceDepartment.GetDataHandler(company._companyDB.GetData));

            company.PBX.ControlDevice.OnCallFinished += company._companyDB.SetData;


            return company;
        }




        // Event Handlers
        internal void SetClientStatus(object sender, EventArgs e)
        {
            var person = sender as Person;
            if (person == null) { return; }

            if (person.PBXStatus == null)
            {
                person.PBXStatus = new CompanyClientBase();
            }
        }










        /*
        КОМПАНИЯ – ОПЕРАТОР АТС:
        •	Имеет:
        o	Отдел обслуживания (заключение контрактов, внесение информации в БД)
        o	АТС (здесь будет одна)
        o	Свободные Терминалы (будут закупаться из воздуха по мере необходимости)

        •	Услуги:
        o	Тарифный план (может быть несколько)

        •	Функционал:
        o	Формирование базовой информации для Биллинговой системы:
        	присваивание клиенту Номера
        	присваивание аппарату Абонентского номера
        	присваивание Договору Номера
        o	выдача каждому Абоненту терминала (телефона)
        o	предоставление портов для подключения терминала;

        •	Генерируемые события:
        o	Изменение статуса Человека
        o	Расторжение договора

        •	Обрабатываемые события:
        o	Заключение Договора

        */

    }
}
