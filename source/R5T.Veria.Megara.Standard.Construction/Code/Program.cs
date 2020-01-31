using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Cambridge.Types;
using R5T.Chalandri;
using R5T.Ilioupoli.Default;
using R5T.Richmond;
using R5T.Evosmos;


namespace R5T.Veria.Megara.Standard.Construction
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var serviceProvider = ServiceProviderBuilder.NewUseStartup<Startup>() as ServiceProvider)
            {
                var program = serviceProvider.GetRequiredService<Program>();

                program.Run();
            }
        }


        private ITemporaryDirectoryFilePathProvider TemporaryDirectoryFilePathProvider { get; }
        private ITestingDataDirectoryContentPathsProvider TestingDataDirectoryContentPathsProvider { get; }
        private IRoundTripFileSerializationVerifier<SolutionFile> SolutionFileRoundTripFileSerializationVerifier { get; }


        public Program(
            ITemporaryDirectoryFilePathProvider temporaryDirectoryFilePathProvider,
            ITestingDataDirectoryContentPathsProvider testingDataDirectoryContentPathsProvider,
            IRoundTripFileSerializationVerifier<SolutionFile> solutionFileRoundTripFileSerializationVerifier
            )
        {
            this.TemporaryDirectoryFilePathProvider = temporaryDirectoryFilePathProvider;
            this.TestingDataDirectoryContentPathsProvider = testingDataDirectoryContentPathsProvider;
            this.SolutionFileRoundTripFileSerializationVerifier = solutionFileRoundTripFileSerializationVerifier;
        }

        public void Run()
        {
            var sourceFilePath = this.TestingDataDirectoryContentPathsProvider.GetExampleVisualStudioSolutionFilePath();

            var serializationFilePath = this.TemporaryDirectoryFilePathProvider.GetTemporaryDirectoryFilePath(TestingDataDirectoryContentConventions.ExampleVisualStudioSolutionFileNameValue);

            this.SolutionFileRoundTripFileSerializationVerifier.Verify(sourceFilePath, serializationFilePath);
        }
    }
}
