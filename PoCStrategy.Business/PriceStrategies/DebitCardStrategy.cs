using PoCStrategy.Business.Models;
using PoCStrategy.Business.SeedWork;

namespace PoCStrategy.Business.PriceStrategies
{
	/// <summary>
	/// EN: Strategy implemented for payment by dedit card.
	/// ES: Estrategia implementada para el pago con tarjeta de dédito.
	/// </summary>
	public class DebitCardStrategy : IPriceStrategy
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
			=> paymentInfo.Price;
		// EN: In this case, there are no plans or adjustments or benefits or anything, just the indicated price is returned.
		// ES: En este caso, no hay planes ni ajustes ni beneficios ni nada, simplemente se devuelve el precio indicado.
	}
}
