using ConsoleTables;
using GuranteedRate.Homework.BusineesLogic.Interfaces;
using GuranteedRate.Homework.Domain.Extensions;
using GuranteedRate.Homework.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace GuranteedRate.Homework.Command
{
    public class Executor : IExecutor
    {
        private readonly IRecordBusinessLogic _recordBusinessLogic;
        private List<MenuOptions> _menuOptions;

        public Executor(IRecordBusinessLogic recordBusinessLogic)
        {
            _recordBusinessLogic = recordBusinessLogic;
            _menuOptions = new List<MenuOptions>()
            {
                new MenuOptions("AddPerson", () => AddPerson("Add Person Record")),
                new MenuOptions("SortByColorThenLNameAsc", () => Sorta("Sort by First Name")),
                new MenuOptions("SortByDobAsc", () => Sortb("Sort by Last Name")),
                new MenuOptions("SortByLNameDesc", () => sortc("Sort by Email")),
            };
        }

        public void Execute()
        {
            RunMenu();

            //var person = new Person()
            //{
            //    FirstName = "Joe",
            //    LastName = "Doe",
            //    Email = "JoeDoe@Domain.com",
            //    DateOfBirth = DateTime.Now,
            //    FavoriteColor = "Blue"
            //};

            //_recordBusinessLogic.AddRecord(person);
            //var records = _recordBusinessLogic.GetRecords();

            //var table = new ConsoleTable("FirstName", "LastName", "Email", "DOB", "FavoriteColor");
            //foreach(var record in records)
            //{
            //    table.AddRow(record.FirstName, record.LastName, record.Email, record.DateOfBirth.ToString("d"), record.FavoriteColor);
            //}

            //table.Write();
        }

        private void RunMenu()
        {
            int index = 0;

            WriteMenu(_menuOptions, _menuOptions[index]);

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < _menuOptions.Count)
                    {
                        index++;
                        WriteMenu(_menuOptions, _menuOptions[index]);
                    }
                }
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(_menuOptions, _menuOptions[index]);
                    }
                }
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    _menuOptions[index].Selected.Invoke();
                    index = 0;
                }
            }
            while (keyInfo.Key != ConsoleKey.X);
        }

        private void AddPerson(string msg)
        {
            WriteTempMsg(msg);

            WriteMenu(_menuOptions, _menuOptions[0]);
        }

        private void Sorta(string msg)
        {
            WriteTempMsg(msg);

            WriteMenu(_menuOptions, _menuOptions[0]);
        }

        private void Sortb(string msg)
        {
            WriteTempMsg(msg);

            WriteMenu(_menuOptions, _menuOptions[0]);
        }

        private void sortc(string msg)
        {
            WriteTempMsg(msg);

            WriteMenu(_menuOptions, _menuOptions[0]);
        }

        private void WriteTempMsg(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Thread.Sleep(3000);
        }

        private void WriteMenu(List<MenuOptions> menuOptions, MenuOptions selectedOption)
        {
            Console.Clear();

            foreach(MenuOptions option in menuOptions)
            {
                if(option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
            }
        }
    }
}
