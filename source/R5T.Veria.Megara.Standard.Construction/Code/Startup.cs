using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Cambridge.Types;
using R5T.Chalandri.DropboxRivetTestingData;
using R5T.Dacia;
using R5T.Evosmos.CDriveTemp;
using R5T.Richmond;
using R5T.Soludas.Standard;
using R5T.Solutas.Standard;


namespace R5T.Veria.Megara.Standard.Construction
{
    class Startup : StartupBase
    {
        public Startup(ILogger<Startup> logger)
            : base(logger)
        {
        }

        protected override void ConfigureServicesBody(IServiceCollection services)
        {
            services
                .AddSingleton<Program>()
                .AddTemporaryDirectoryFilePathProvider()
                .AddTestingDataDirectoryContentPathsProvider()
                .AddRoundTripFileSerializationVerifier_Text<SolutionFile>(
                    ServiceAction.AddedElsewhere,
                    ServiceAction.AddedElsewhere)
                .AddVisualStudioSolutionFileSerializer()
                .AddVisualStudioSolutionFileValueEqualityComparer()
                ;
        }
    }
}
