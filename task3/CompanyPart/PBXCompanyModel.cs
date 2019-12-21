using System;
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
    }
}
