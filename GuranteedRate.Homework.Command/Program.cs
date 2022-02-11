using Microsoft.Extensions.DependencyInjection;
using System;
using DI = GuranteedRate.Homework.Domain.Helpers.DependencyInjection;

namespace GuranteedRate.Homework.Command
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DependecyInjection();
        }

        static void DependecyInjection()
        {
            var serviceProvider = new ServiceCollection();
            DI.ConfigureServices(serviceProvider);
            serviceProvider
                .BuildServiceProvider();
        }
    }
}
