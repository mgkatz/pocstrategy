using Microsoft.Extensions.DependencyInjection;
using PoCStrategy.Data;
using PoCStrategy.Business;
using PoCStrategy.Business.PriceStrategies;
using PoCStrategy.Business.SeedWork;
using System;
using System.Collections.Generic;

namespace PoCStrategy
{
	public class Program
	{
		// EN: A static object for the service provider.
		// ES: Un objeto estático para el proveedor de servicios.
		private static IServiceProvider _serviceProvider;

		public static void Main(string[] args)
		{
			// EN: Register the services.
			// ES: Se registran los servicios.
			RegisterServices();

			// EN: The context that will manage the strategies is obtained. Typically this would be injected into the constructor of a class but for the practical purposes of this proof of concept it is obtained directly.
			// ES: Se obtiene el contexto que administrará las estrategias. Regularmente esto se inyectaría en el constructor de una clase pero para los efectos prácticos de esta prueba de concepto se obtiene directamente.
			IPriceContext priceContext = _serviceProvider.GetService<IPriceContext>();

			// EN: An attempt will be made to process each of the cases. In the event that one of them fails, a message will be included in the console.
			// ES: Se intentará procesar cada uno de los casos. En caso que que alguno falle se incluirá un mensaje en la consola.
			try
			{
				// EN: For each of the test cases, the context will be asked to calculate the final price and the information will be displayed on the console.
				// ES: Por cada uno de los casos de test se le pedirá al contexto que calcule el precio final y se mostrará la información en la consola.
				foreach (var testCase in TestCasesProvider.PaymentInfoTestCases)
				{
					// EN: The price of the test case is saved in a variable.
					// ES: Se guarda en una variable el precio del caso de prueba.
					int originalPrice = (int)testCase.Value.Price;

					// EN: The context is asked to calculate the price and the necessary information is passed to it.
					// ES: Se le pide al contexto que calcule el precio y se le pasa la información necesaria.
					int finalPrice = (int)priceContext.CalculatePrice(testCase.Value);

					// EN: The name of the test case is displayed on the console as a title.
					// ES: Se muestra en la consola el nombre del caso de prueba a modo de título.
					Console.WriteLine($"Test Case - {testCase.Key}");

					// EN: The name of each of the fields that will be reported as a result is displayed on the console.
					// ES: Se muestra en la consola el nombre de cada uno de los campos que se informarán como resultado.
					Console.WriteLine("Payment Type,Card Company,Original Price,Final Price,Number of Payments");

					// EN: The value corresponding to the fields indicated previously is displayed on the console.
					// ES: Se muestra en la consola el valor correspondiente a los campos indicados previamente.
					Console.WriteLine($"{testCase.Value.TypeOfPayment},{testCase.Value.CardCompany.ToString() ?? string.Empty},{originalPrice},{finalPrice},{testCase.Value.NumberOfPayments}");

					// EN: A couple of empty lines are printed on the console in order to separate each test case.
					// ES: Se imprimen un par de líneas vacías en la consola a fin de separar cada caso de prueba.
					Console.WriteLine(string.Empty);
					Console.WriteLine(string.Empty);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error happened when calculating final price: {ex.Message}");
			}

			// EN: Resources are disposed.
			// ES: Se deshechan los recursos.
			Dispose();
		}

		/// <summary>
		/// EN: Responsible for disposing of resources.
		/// ES: Se encarga de deshechar los recursos.
		/// </summary>
		private static void Dispose()
		{
			if (_serviceProvider == null)
				return;

			if (_serviceProvider is IDisposable disposable)
				(disposable).Dispose();
		}

		/// <summary>
		/// EN: Registry of the services to be used with dependency injection.
		/// ES: Registro de los servicios a utilizar con inyección de dependencias.
		/// </summary>
		private static void RegisterServices()
		{
			// EN: Create a collection of services to be used by the service provider.
			// ES: Se crea una colección de servicios para ser usada por el proveedor de servicios.
			var collection = new ServiceCollection();

			// EN: Create a dictionary for the strategies to be registered.
			// ES: Se crea un diccionario para las estrategias que hay que registrar.
			var priceStrategies = new Dictionary<string, Type>
			{
				{ nameof(PaymentMethodType.Cash), typeof(CashStrategy) },
				{ nameof(PaymentMethodType.CreditCard), typeof(CreditCardStrategy) },
				{ nameof(PaymentMethodType.DebitCard), typeof(DebitCardStrategy) }
			};

			// EN: Register the context responsible for the strategies.
			// ES: Se registra el contexto responsable de las estrategias.
			collection.AddScoped<IPriceContext, PriceContext>();

			// EN: Register the strategies using a key dictionary to access them optimally and on demand.
			// ES: Se registran las estrategias usando un diccionario de claves para acceder a ellas de una manera óptima y a pedido.
			collection.AddKeyedServices<string, IPriceStrategy>(priceStrategies);

			// EN: Creates a service provider containing the items from the service collection provided.
			// ES: Se crea un proveedor de servicios que contiene los elementos de la colección de servicios proporcionada.
			_serviceProvider = collection.BuildServiceProvider();
		}
	}
}
