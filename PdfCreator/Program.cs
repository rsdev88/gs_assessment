using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using PdfCreator.InputMappers;
using PdfCreator.FileReaders;
using PdfCreator.PdfGenerators;

namespace PdfCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Configuration setup
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            //IoC registration
            var services = new ServiceCollection();
            services.AddSingleton(configuration);
            services.AddTransient<PdfCreator>();
            services.AddTransient<IFileReader, FileReader>();
            services.AddTransient<IMapper, InputMapper>();
            services.AddTransient<IPdfGenerator, PdfGenerator>();

            var serviceProvider = services.BuildServiceProvider();
            var scope = serviceProvider.CreateScope();

            //Run the program
            try
            {
                scope.ServiceProvider.GetRequiredService<PdfCreator>().Run();
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                Console.ReadLine();
            }

            //IoC disposal
            if (serviceProvider != null && serviceProvider is IDisposable)
            {
                serviceProvider.Dispose();
            }

        }
    }
}
