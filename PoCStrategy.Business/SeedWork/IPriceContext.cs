using PoCStrategy.Business.Models;

namespace PoCStrategy.Business.SeedWork
{
	/// <summary>
	/// EN: It allows to implement a context for prices calculation.
	/// ES: Permite implementar un contexto para el cálculo de precios.
	/// </summary>
	public interface IPriceContext
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
		decimal CalculatePrice(PaymentInfoDto paymentInfo);
	}
}
