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

            Console.Clear();

            int second = 0;        
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            do
            {
                Thread.Sleep(100);

                person = persons[Const.RND.Next(0, Const.SWITCHDEVICE_COUNT_DEFAULT)];
                Console.WriteLine($"Selected Person {person.PersonalInfo.PersonalId}.");

                int operation = Const.RND.Next(0, Const.SWITCHDEVICE_COUNT_DEFAULT);
                if (operation < 1)
                {
                    Console.WriteLine($"- operation: Get Call Report.");
                    //person.GetCallReport();
                }
                else
                {
                    Console.WriteLine($"- operation: Call");
                    var terminal = person.Terminals.First();
                    Console.WriteLine($"-- terminal number {terminal.Number}: IsPowered - {terminal.IsPowered}; IsReady - {terminal.IsReady}");
                    if (terminal.IsReady)
                    {
                        Console.WriteLine($"-- terminal ready");
                        int number = Const.RND.Next(0, Const.SWITCHDEVICE_COUNT_DEFAULT);
                        Console.WriteLine($"-- call number {number}");
                        if (number != terminal.Number)
                        {
                            Console.WriteLine($"--- start call");
                            terminal.Call(number);
                        }
                        else
                        {
                            Console.WriteLine($"--- wrong number");
                        }
                    }
                }
                Console.WriteLine($"");
                Console.ReadKey();

                //if (Console.KeyAvailable == true)
                //{
                //    cki = Console.ReadKey(true);
                //}
            } while (cki.Key != ConsoleKey.Escape || second < Int32.MaxValue);




            Console.ReadKey();
        }


    }
}
