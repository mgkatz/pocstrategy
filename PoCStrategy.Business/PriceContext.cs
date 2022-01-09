using PoCStrategy.Business.Models;
using PoCStrategy.Business.SeedWork;
using System;

namespace PoCStrategy.Business
{
	/// <summary>
	/// EN: Implementation of the context that will determine the strategy to use.
	/// ES: Implementación del contexto que determinará la estrategia a usar.
	/// </summary>
	public class PriceContext : IPriceContext
	{
		// EN: Read-only private property in which the function that allows obtaining the necessary strategy will be saved.
		// ES: Propiedad privada de sólo lectura en la cual se guardará la función que permite obtener la estrategia necesaria.
		private readonly Func<string, IPriceStrategy> _priceStrategies;

		/// <summary>
		/// EN: Context constructor.
		/// ES: Constructor del contexto.
		/// </summary>
		/// <param name="priceStrategies">
		/// EN: Function that allows obtaining from the dictionary of registered strategies the necessary to solve the requested action.
		/// ES: Función que permite obtener del diccionario de estrategias registradas la necesaria para resolver la acción solicitada.
		/// </param>
		public PriceContext(Func<string, IPriceStrategy> priceStrategies)
		{
			// EN: We save the function that allows us to obtain the instance of the strategy. In case the function is null, an error will be returned.
			// ES: Guardamos la función que nos permite obtener la instancia de la estrategia. En caso de que la función sea nula se retornará un error.
			_priceStrategies = priceStrategies ?? throw new ArgumentNullException(nameof(priceStrategies));
		}

		/// <summary>
		/// EN: It allows the calculation of the final price according to the payment information provided.
		/// ES: Permite el cálculo del precio final de acuerdo a la información de pago proporcionada.
		/// </summary>
		/// <param name="paymentInfo">
		/// EN: The payment information.
		/// ES: La información del pago.
		/// </param>
		/// <returns>
		/// EN: The final price.
		/// ES: El precio final.
		/// </returns>
		public decimal CalculatePrice(PaymentInfoDto paymentInfo)
		{
			// EN: The strategy is obtained from the type of payment chosen.
			// ES: Se obtiene la estrategia a partir del tipo de pago elegido.
			IPriceStrategy strategy = _priceStrategies(paymentInfo.TypeOfPayment.ToString());

			// EN: If no strategy was found, an error will be returned.Otherwise, the method of the strategy that obtains the final price will be called.
			// ES: Si no se encontró ninguna estrategia se retornará un error. En caso contrario se llamará al método de la estrategia que obtiene el precio final.
			return strategy == null
                ? throw new Exception($"The type of payment '{paymentInfo.TypeOfPayment}' doesn't exist or is not available.")
				: strategy.GetFinalPrice(paymentInfo);
		}
	}
}
