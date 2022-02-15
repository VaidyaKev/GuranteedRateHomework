using GuranteedRate.Homework.BusineesLogic.DataContract;
using GuranteedRate.Homework.DI;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GuranteedRate.Homework.Command
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DependecyInjection();
            Console.ReadLine();           
        }

        static void DependecyInjection()
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IExecutor, Executor>()
                .AddScoped<ISortHelper, SortHelper>();

            DependencyInjection.ConfigureServices(serviceProvider);
            var buildService = serviceProvider.BuildServiceProvider();

            var personRepo = buildService.GetService<IPersonRepository>();
            new RecordHelper(personRepo);

            buildService
                .GetService<IExecutor>()
                .Execute();
        }
    }
}
