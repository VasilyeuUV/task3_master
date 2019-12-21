using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using task3.CompanyPart;
using task3.CompanyPart.Documents;
using task3.PersonPart;
using task3.Tools;

namespace task3
{
    class Program
    {
        const int CALLCOUNT = 30;


        static void Main(string[] args)
        {
            PBXCompanyModel company = PBXCompanyModel.CreateInstance();
            company.Service.StartWork(company);

            Console.WriteLine("Company creation completed.");

            Person[] persons = new Person[Const.SWITCHDEVICE_COUNT_DEFAULT];
            Person person;

            for (int i = 0; i < Const.SWITCHDEVICE_COUNT_DEFAULT; i++)
            {
                person = Person.CreateInstance();

                person.OnEnteredToShop += company.SetClientStatus;
                person.EnterToShop(company);


                if (company.Service.AgreementConclusion(person))
                {
                    if (person.PBXStatus as CompanySubscriberBase != null)
                    {
                        persons[i] = person;
                    }
                }             
            }


            Console.WriteLine("Subscriber registration completed.");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

           

            int second = 0;        
            //ConsoleKeyInfo cki = new ConsoleKeyInfo();
            do
            {
                Thread.Sleep(1000);

                Console.Clear();

                person = persons[Const.RND.Next(0, Const.SWITCHDEVICE_COUNT_DEFAULT)];
                Console.WriteLine($"Selected Person {person.PersonalInfo.PersonalId}.");

                int operation = Const.RND.Next(0, Const.SWITCHDEVICE_COUNT_DEFAULT);
                if (operation < 1)
                {
                    Console.WriteLine($"- operation: Get Call Report.");                   
                    //subscriber.RequestCallReport();
                }
                else
                {
                    Console.WriteLine($"- operation: Call");
                    var terminal = person.Terminals.First();
                    Console.WriteLine($"-- terminal number {terminal.Number}: IsPowered - {terminal.IsPowered}; IsReady - {terminal.IsReady}");
                    if (terminal.IsReady)
                    {
                        Console.WriteLine($"-- terminal ready");
                        int number = Const.RND.Next(1, Const.SWITCHDEVICE_COUNT_DEFAULT);
                        Console.WriteLine($"-- call number {number}");

                        Console.WriteLine($"--- start call");
                        terminal.Call(number);
                    }
                }
                Console.WriteLine($"");
            } while (/*cki.Key != ConsoleKey.Escape ||*/ ++second < CALLCOUNT);


            Console.Clear();

            var subscriber = person.PBXStatus as CompanySubscriberBase;
            if (subscriber != null)
            {
                var contractNumber = subscriber.Contracts.First();
                Console.WriteLine($"Information about calls under the contract of {contractNumber.ContractDate.Date} No. {contractNumber.Id} ");
                Console.WriteLine();

                var result = subscriber.RequestCallReport(contractNumber, Const.GetInfo.CallReport);
                Console.WriteLine($"TOTAL CALLS - {result.Count()}");
                Console.WriteLine();

                Console.WriteLine($"Sorted by DATA:");
                ViewReport(subscriber.SortReportByData(result), Const.ViewInfo.ByDate);

                Console.WriteLine($"Sorted by NUMBER:");
                ViewReport(subscriber.SortReportByNumber(result), Const.ViewInfo.ByNumber);

                Console.WriteLine($"Sorted by COST:");
                ViewReport(subscriber.SortReportByCost(result), Const.ViewInfo.ByCost);
            }

            Console.WriteLine($"Press any key to Exit");
            Console.ReadKey();
        }

        private static void ViewReport(IEnumerable<CallReportItem> lst, Const.ViewInfo param)
        {
            StringBuilder str = new StringBuilder();



            foreach (var item in lst)
            {
                switch (param)
                {
                    case Const.ViewInfo.ByDate:
                        str.Append(string.Format("Date: {0}; Number: {1}; Duration: {2}; Cost: {3};\n"
                            , item.CallDTG, item.OutNumber, item.CallDuration, item.Cost));
                        break;
                    case Const.ViewInfo.ByNumber:
                        str.Append(string.Format("Number: {0}; Date: {1}; Duration: {2}; Cost: {3};\n"
                            , item.OutNumber, item.CallDTG, item.CallDuration, item.Cost));
                        break;
                    case Const.ViewInfo.ByCost:
                        str.Append(string.Format("Cost: {0}; Number: {1}; Date: {2}; Duration: {3};\n"
                            , item.Cost, item.OutNumber, item.CallDTG, item.CallDuration));
                        break;
                    default:
                        break;
                }
            }            
            Console.WriteLine(str.ToString());
            Console.WriteLine();
        }
    }
}
