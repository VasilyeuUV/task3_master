using System;
using System.Collections.Generic;
using task3.CompanyPart;
using task3.CompanyPart.Documents.ContractPart;
using task3.PersonPart;
using task3.Tools;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            PBXCompanyModel company = PBXCompanyModel.CreateInstance();
            company.Service.StartWork(company);

            List<Person> persons = new List<Person>();

            for (int i = 0; i < Const.SWITCHDEVICE_COUNT_DEFAULT; i++)
            {
                Person person = Person.CreateInstance();

                person.OnEnteredToShop += company.SetClientStatus;
                person.EnterToShop(company);


                if (company.Service.AgreementConclusion(person))
                {
                    if (person.PBXStatus as CompanySubscriberBase != null)
                    {
                        persons.Add(person);
                    }
                }             
            }





            Console.ReadKey();
        }


    }
}
