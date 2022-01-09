using PoCStrategy.Data;
using PoCStrategy.Business.Extensions;
using PoCStrategy.Business.Models;
using PoCStrategy.Business.SeedWork;

namespace PoCStrategy.Business.PriceStrategies
{
	/// <summary>
	/// EN: Strategy implemented for payment in cash.
	/// ES: Estrategia implementada para el pago en efectivo.
	/// </summary>
	public class CashStrategy : IPriceStrategy
	{
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
		public decimal GetFinalPrice(PaymentInfoDto paymentInfo)
		{
			// EN: We obtain the payment information through a mock up that returns data simulating what the data layer would do.
			// ES: Obtenemos la información de pago a través de un mock que retorna datos simulando lo que haría la capa de datos.
			PaymentMethod paymentMethod = TestDataProvider.GetPaymentMethodInfo(paymentInfo.PaymentMethodId);

			// EN: Using an extension method for applying percentages, the final price is calculated and returned based on the original price and the percentage indicated by the information obtained from the data layer.
			// ES: Usando un método de extensión para la aplicación de porcentajes, se calcula y se retorna el precio final basados en el precio original y el porcentaje que indica la información obtenida de la capa de datos.
			return paymentInfo.Price.ApplyPercentage(paymentMethod.Percentage);
		}
	}
}
