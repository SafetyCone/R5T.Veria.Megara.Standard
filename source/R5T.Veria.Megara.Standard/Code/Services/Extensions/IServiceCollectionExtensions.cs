using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Bath.Standard;
using R5T.Bedford.Bath.Standard;
using R5T.Dacia;
using R5T.Megara;
using R5T.Vandalia;


namespace R5T.Veria.Megara.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds a text-based <see cref="IRoundTripFileSerializationVerifier{T}"/> service.
        /// </summary>
        public static IServiceCollection AddRoundTripFileSerializationVerifier_Text<TValue>(this IServiceCollection services,
            ServiceAction<IFileSerializer<TValue>> addFileSerializer,
            ServiceAction<IValueEqualityComparer<TValue>> addValueEqualityComparer)
        {
            services.AddRoundTripFileSerializationVerifier<TValue>(
                services.AddHumanOutputAction(),
                services.AddTextFileEqualityComparerAction(),
                addFileSerializer,
                addValueEqualityComparer);

            return services;
        }

        /// <summary>
        /// Adds a text-based <see cref="IRoundTripFileSerializationVerifier{T}"/> service.
        /// </summary>
        public static ServiceAction<IRoundTripFileSerializationVerifier<TValue>> AddRoundTripFileSerializationVerifier_TextAction<TValue>(this IServiceCollection services,
            ServiceAction<IFileSerializer<TValue>> addFileSerializer,
            ServiceAction<IValueEqualityComparer<TValue>> addValueEqualityComparer)
        {
            var serviceAction = new ServiceAction<IRoundTripFileSerializationVerifier<TValue>>(() => services.AddRoundTripFileSerializationVerifier_Text<TValue>(
                addFileSerializer,
                addValueEqualityComparer));
            return serviceAction;
        }

        /// <summary>
        /// Adds a binary-based <see cref="IRoundTripFileSerializationVerifier{T}"/> service.
        /// </summary>
        public static IServiceCollection AddRoundTripFileSerializationVerifier_Binary<TValue>(this IServiceCollection services,
            ServiceAction<IFileSerializer<TValue>> addFileSerializer,
            ServiceAction<IValueEqualityComparer<TValue>> addValueEqualityComparer)
        {
            services.AddRoundTripFileSerializationVerifier<TValue>(
                services.AddHumanOutputAction(),
                services.AddBinaryFileEqualityComparerAction(),
                addFileSerializer,
                addValueEqualityComparer);

            return services;
        }

        /// <summary>
        /// Adds a binary-based <see cref="IRoundTripFileSerializationVerifier{T}"/> service.
        /// </summary>
        public static ServiceAction<IRoundTripFileSerializationVerifier<TValue>> AddRoundTripFileSerializationVerifier_BinaryAction<TValue>(this IServiceCollection services,
            ServiceAction<IFileSerializer<TValue>> addFileSerializer,
            ServiceAction<IValueEqualityComparer<TValue>> addValueEqualityComparer)
        {
            var serviceAction = new ServiceAction<IRoundTripFileSerializationVerifier<TValue>>(() => services.AddRoundTripFileSerializationVerifier_Binary<TValue>(
                addFileSerializer,
                addValueEqualityComparer));
            return serviceAction;
        }
    }
}
