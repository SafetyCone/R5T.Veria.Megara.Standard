using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Bath.Standard;
using R5T.Bedford.Bath.Standard;
using R5T.Vandalia.Bath;
using R5T.Vandalia.Bath.Standard;


namespace R5T.Veria.Megara.Standard
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddRoundTripFileSerializationVerifier_Text<TValue, TValueEqualityComparer>(this IServiceCollection services,
            Action addFileSerializer)
            where TValueEqualityComparer: HumanOutputValueEqualityComparer<TValue>
        {
            services
                .AddSingleton<IRoundTripFileSerializationVerifier<TValue>, RoundTripFileSerializationVerifier<TValue>>()
                .AddTextFileEqualityComparer()

            //services
            //    .AddSingleton<IRoundTripFileSerializationVerifier<TValue>, RoundTripFileSerializationVerifier<TValue>>()
            //    .AddHumanOutput()
            //    .AddTextFileEqualityComparer()
            //    .AddValueEqualityComparer<TValue, TValueEqualityComparer>()
            //    ;

            return services;
        }
    }
}
