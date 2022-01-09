using PoCStrategy.Data;
using PoCStrategy.Business.Extensions;
using PoCStrategy.Business.Models;
using PoCStrategy.Business.SeedWork;
using System;
using System.Linq;

namespace PoCStrategy.Business.PriceStrategies
{
	/// <summary>
	/// EN: Strategy implemented for payment by credit card.
	/// ES: Estrategia implementada para el pago con tarjeta de crédito.
	/// </summary>
	public class CreditCardStrategy : IPriceStrategy
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
			// EN: In the case of credit cards, it will be mandatory to indicate the type of card, for that reason an error is validated and returned if it is not specified.
			// ES: En el caso de las tarjetas de crédito va a ser obligatorio indicar el tipo de tarjeta, por eso se valida y retorna un error en caso de que no esté especificado.
			if (!paymentInfo.CardCompany.HasValue)
				throw new Exception("The credit card company is mandatory. Please provide it.");

			// EN: We obtain the payment information through a mock up that returns data simulating what the data layer would do.
			// ES: Obtenemos la información de pago a través de un mock que retorna datos simulando lo que haría la capa de datos.
			PaymentMethod paymentMethod = TestDataProvider.GetPaymentMethodInfo(paymentInfo.PaymentMethodId);

			// EN: If there is no fees plan in the information provided by the data layer and, using an extension method for the application of percentages, the final price is calculated and returned based on the original price and the percentage indicated by the information obtained. of the data layer.
			// ES: Si no hay plan de cuotas en la información que nos brinda la capa de datos y, usando un método de extensión para la aplicación de porcentajes, se calcula y se retorna el precio final basados en el precio original y el porcentaje que indica la información obtenida de la capa de datos.
			if (paymentMethod.Fees == null)
				return paymentInfo.Price.ApplyPercentage(paymentMethod.Percentage);

			// EN: Information on the fees plan to apply is obtained.
			// ES: Se obtiene la información sobre el plan de cuotas a aplicar.
			PaymentFeesDetail paymentFeesDetail = paymentMethod
				.Fees
				.SingleOrDefault(f => f.CardCompany == paymentInfo.CardCompany && f.NumberOfFees == paymentInfo.NumberOfFees);

			// EN: If there are no details regarding the fees plan chosen for the indicated credit card, an error will be returned. Otherwise, using an extension method for applying percentages, the final price is calculated and returned based on the original price and the percentage indicated by the information obtained from the data layer.
			// ES: Si no hay detalles respecto al plan de cuotas elegido para la tarjeta de crédito indicada se retornará un error. De lo contrario, usando un método de extensión para la aplicación de porcentajes, se calcula y se retorna el precio final basados en el precio original y el porcentaje que indica la información obtenida de la capa de datos.
			return paymentFeesDetail == null
                ? throw new Exception($"A payment in {paymentInfo.NumberOfFees} fees with {paymentInfo.CardCompany} credit card is not possible because the card is not providing that plan.")
				: paymentInfo.Price.ApplyPercentage(paymentFeesDetail.Percentage);
		}
	}
}
