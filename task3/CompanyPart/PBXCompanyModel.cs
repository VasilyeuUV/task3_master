using System;
using task3.CompanyPart.DB;
using task3.PBXPart;
using task3.PersonPart;

namespace task3.CompanyPart
{
    public class PBXCompanyModel : IObservable<Person>
    {

        private PBXBase _pBX = null;                              // АТС
        private PBXCompanyDataBase _companyDB = null;             // База данных компании
        private CompanyServiceDepartment _service = null;


        //internal PBXBase PBX { get => _pBX; }
        //internal PBXCompanyDataBase CompanyDB { get => _companyDB; }

        /// <summary>
        /// Отдел обслуживания
        /// </summary>
        public CompanyServiceDepartment Service { get => _service; }




        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="tERMINAL_COUNT_DEFAULT"></param>
        internal PBXCompanyModel()
        {
            this._pBX = PBXBase.CreateInstance();
            this._companyDB = new PBXCompanyDataBase();
            this._service = new CompanyServiceDepartment();
        }

        
        /// <summary>
        /// Company work
        /// </summary>
        internal void StartWork()
        {
            this._pBX.PowerOn();
        }




        public IDisposable Subscribe(IObserver<Person> observer)
        {
            throw new NotImplementedException();
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
