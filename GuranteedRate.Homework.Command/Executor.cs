using ConsoleTables;
using GuranteedRate.Homework.BusineesLogic.Interfaces;
using GuranteedRate.Homework.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace GuranteedRate.Homework.Command
{
    public class Executor : IExecutor
    {
        private readonly IRecordBusinessLogic _recordBusinessLogic;
        private readonly ISortHelper _sortHelper;
        private List<MenuOptions> _menuOptions;

        public Executor(IRecordBusinessLogic recordBusinessLogic, ISortHelper sortHelper)
        {
            _recordBusinessLogic = recordBusinessLogic;
            _sortHelper = sortHelper;
            _menuOptions = new List<MenuOptions>()
            {
                new MenuOptions("AddPerson", () => AddPerson("Add Person Record")),
                new MenuOptions("SortByColorThenLNameAsc", () => SortByColorDescThenLNameAsc("Sort by First Name")),
                new MenuOptions("SortByDobAsc", () => SortByDobAsc("Sort by Last Name")),
                new MenuOptions("SortByLNameDesc", () => SortByLNameDesc("Sort by Email")),
            };
        }

        public void Execute()
        {
            RunMenu();
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

            Console.WriteLine("Please enter record in one of the following format");
            Console.WriteLine("LastName | FirstName | Email | FavoriteColor | DateOfBirth");
            Console.WriteLine("LastName, FirstName, Email, FavoriteColor, DateOfBirth");
            Console.WriteLine("LastName FirstName Email FavoriteColor DateOfBirth");
            Console.Write("Input: ");
            var record = Console.ReadLine();

            _recordBusinessLogic.AddRecord(record);
            WriteMenu(_menuOptions, _menuOptions[0]);
        }

        private void SortByColorDescThenLNameAsc(string msg)
        {
            var persons = _recordBusinessLogic.GetRecords();
            var orderedPersons = _sortHelper.SortByColorDescThenLNameAsc(persons);
            DisplayPersons(orderedPersons, msg);
            WriteMenu(_menuOptions, _menuOptions[0]);
        }

        private void SortByDobAsc(string msg)
        {
            var persons = _recordBusinessLogic.GetRecords();
            var orderedPersons = _sortHelper.SortByDobAsc(persons);
            DisplayPersons(orderedPersons, msg);
            WriteMenu(_menuOptions, _menuOptions[0]);
        }

        private void SortByLNameDesc(string msg)
        {
            var persons = _recordBusinessLogic.GetRecords();
            var orderedPersons = _sortHelper.SortByLNameDesc(persons);
            DisplayPersons(orderedPersons, msg);
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

        private void DisplayPersons(ICollection<Person> persons, string msg)
        {
            Console.Clear();
            WriteTempMsg(msg);
            Console.WriteLine(msg);

            var consoleTable = new ConsoleTable("Last Name", "First Name", "Email", "Favorite Coler", "Date of Birth");
            foreach(var person in persons)
            {
                consoleTable.AddRow(person.LastName, person.FirstName, person.Email, person.FavoriteColor, person.DateOfBirth.ToShortDateString());
            }
            consoleTable
                .Configure(c => c.NumberAlignment = Alignment.Right)
                .Write(Format.Alternative);

            Console.WriteLine();
            Console.WriteLine("Please Any Key To Continue....");
            Console.ReadKey();
        }
    }
}
