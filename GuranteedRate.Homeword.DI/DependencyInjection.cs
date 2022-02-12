using GuranteedRate.Homework.BusineesLogic.DataContract;
using GuranteedRate.Homework.BusineesLogic.Implementations;
using GuranteedRate.Homework.BusineesLogic.Interfaces;
using GuranteedRate.Homework.Repository;
using Microsoft.Extensions.DependencyInjection;


namespace GuranteedRate.Homeword.DI
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddScoped<IRecordBusinessLogic, RecordBusinessLogic>()
                .AddScoped<IFileRepository, FileRepository>();
        }
    }
}
