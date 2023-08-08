using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;

namespace PoCStrategy
{
	/// <summary>
	/// EN: 
	/// ES: Clase de extensión para usar en el registro de servicios.
	/// </summary>
	public static class RegistrationExtensions
	{
        /// <summary>
        /// EN: The extension method to add services using a dictionary of keys to access them in an optimal way and on demand.
        /// ES: Método the extensión para agregar servicios usando un diccionario de claves para acceder a ellas de una manera óptima y a pedido.
        /// </summary>
        /// <typeparam name="T">
        /// EN: It is the type to register.
        /// ES: Es el tipo a registrar.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// EN: It is the key to identify the type. It cannot have a null value.
        /// ES: Es la clave para identificar el tipo. No puede tener un valor nulo.
        /// </typeparam>
        /// <param name="services">
        /// EN: It is the collection of services that is being extended.
        /// ES: Es la colección de servicios que se está extendiendo.
        /// </param>
        /// <param name="servicesToRegister">
        /// EN: It is the dictionary with the services to be registered.
        /// ES: Es el diccionario con los servicios a registrar.
        /// </param>
        public static void AddKeyedServices<T, TKey>(
			this IServiceCollection services,
			IDictionary<TKey, Type> servicesToRegister)
			where TKey : notnull
			where T : class
		{
			// EN: Each of the dictionary services will be registered transiently. In this way they will only be used on demand.
			// ES: Cada uno de los servicios del diccionario se registrará de modo transient. De esta manera sólo se usarán a demanda.
			foreach (var serviceToRegister in servicesToRegister.Values)
			{
				services.TryAddTransient(serviceToRegister);
			}

			// EN: To access the services previously registered on demand, a function is registered at the scope (thread) level that obtains the required service from the dictionary. In this way, it will only be necessary to inject the function instead of each of the services.
			// ES: Para acceder a demanda a los servicios registrados antes, se registra a nivel de scope (thread) una función que obtiene el servicio requerido a partir del diccionario. De esta manera, sólo será necesario inyectar la función en vez de cada uno de los servicios.
			services.AddScoped<Func<TKey, T>>(provider => (key) =>
			{
				// EN: If the provider has a living instance and the service is inside the dictionary, then the corresponding instance is obtained from the service provider and it is returned by doing the corresponding cast. Otherwise, a null value is returned.
				// ES: Si el provider está instanciado y el servicio está dentro del diccionario se obtiene del proveedor de servicios la instancia correspondiente y se retorna haciendo el casteo correspondiente. De lo contrario, se retorna un valor null.
				return provider is not null && servicesToRegister.ContainsKey(key)
					? provider.GetRequiredService(servicesToRegister[key]) as T
					: null;
			});
		}
	}
}
