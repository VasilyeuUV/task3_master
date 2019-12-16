using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using task3.CompanyPart;
using task3.CompanyPart.Documents.ContractPart;
using task3.PersonPart;
using task3.Tools;

namespace task3
{
    class Program
    {
        const int CALLCOUNT = 20;


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
                if (++second < 5)
                {
                    Thread.Sleep(2000);
                }

                
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
                //Console.ReadKey();

                //if (Console.KeyAvailable == true)
                //{
                //    cki = Console.ReadKey(true);
                //}
            } while (/*cki.Key != ConsoleKey.Escape ||*/ second < CALLCOUNT);


            Console.Clear();

            var subscriber = person.PBXStatus as CompanySubscriberBase;
            if (subscriber != null)
            {
                var terminalNumber = subscriber.Contracts.First();
                Console.WriteLine($"Information about calls from number {terminalNumber}");
                subscriber.RequestCallReport(terminalNumber, Const.GetInfo.CallReport);

            }

            




            Console.WriteLine($"Press any key to Exit");
            Console.ReadKey();
        }
        

    }
}
