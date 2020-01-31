using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Richmond;


namespace R5T.Veria.Megara.Standard.Construction
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ServiceProviderBuilder.NewUseStartup<Startup>();

            var program = serviceProvider.GetRequiredService<Program>();

            program.Run();
        }


        public Program()
        {

        }

        public void Run()
        {

        }
    }
}
