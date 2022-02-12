using GuranteedRate.Homework.DI;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GuranteedRate.Homework.Command
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DependecyInjection();

            Console.ReadLine();
            
        }

        static void DependecyInjection()
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IExecutor, Executor>();

            DependencyInjection.ConfigureServices(serviceProvider);
            serviceProvider.BuildServiceProvider()
                .GetService<IExecutor>()
                .Execute();
        }
    }
}
