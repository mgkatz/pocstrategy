using PoCStrategy.Data;
using PoCStrategy.Business.Models;
using System.Collections.Generic;

namespace PoCStrategy
{
	/// <summary>
	/// EN: Class that provides the test cases.
	/// ES: Clase que provee los casos de prueba.
	/// </summary>
	public static class TestCasesProvider
	{
		/// <summary>
		/// EN: Dictionary with each of the test cases.
		/// ES: Diccionario con cada uno de los casos de prueba.
		/// </summary>
		public static IDictionary<string, PaymentInfoDto> PaymentInfoTestCases =
			new Dictionary<string, PaymentInfoDto>
			{
				{ "Price for cash with list price", GetPriceForCashWithListPrice() },
				{ "Price for cash with discount", GetPriceForCashWithDiscount() },
				{ "Price for debit card with list price", GetPriceForDebitCardWithListPrice() },
				{ "Price for credit card with list price in one payment", GetPriceForCreditCardWithListPriceInOnePayment() },
				{ "Price for credit card with extra charge in one payment", GetPriceForCreditCardWithExtraChargeInOnePayment() },
				{ $"Price for credit card {nameof(CardCompany.VICARD)} with 3 payments", GetPriceForCreditCardViCardWith3Payments() },
				{ $"Price for credit card {nameof(CardCompany.VICARD)} with 6 payments", GetPriceForCreditCardViCardWith6Payments() },
				{ $"Price for credit card {nameof(CardCompany.VICARD)} with 12 payments", GetPriceForCreditCardViCardWith12Payments() },
				{ $"Price for credit card {nameof(CardCompany.VICARD)} with 18 payments", GetPriceForCreditCardViCardWith18Payments() },
				{ $"Price for credit card {nameof(CardCompany.ACARD)} with 3 payments", GetPriceForCreditCardAcardWith3Payments() },
				{ $"Price for credit card {nameof(CardCompany.ACARD)} with 6 payments", GetPriceForCreditCardAcardWith6Payments() },
				{ $"Price for credit card {nameof(CardCompany.ACARD)} with 12 payments", GetPriceForCreditCardAcardWith12Payments() },
				{ $"Price for credit card {nameof(CardCompany.MYCARD)} with 3 payments", GetPriceForCreditCardMyCardWith3Payments() },
				{ $"Price for credit card {nameof(CardCompany.MYCARD)} with 6 payments", GetPriceForCreditCardMyCardWith6Payments() },
				{ "Price for credit card with no existing plan", GetPriceForCreditCardNoExistingPlan() }
			};

		/// <summary>
		/// EN: Test case - Payment in cash must return the same list price.
		/// ES: Caso de prueba - Pago en efectivo debe retornar el mismo precio de lista.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCashWithListPrice()
		{
			return new PaymentInfoDto
			{
				PaymentMethodId = 1,
				TypeOfPayment = PaymentMethodType.Cash,
				Price = 1000.00M
			};
		}

		/// <summary>
		/// EN: Test case - Payment in cash must return the price with a discount.
		/// ES: Caso de prueba - Pago en efectivo debe retornar el precio con un descuento.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCashWithDiscount()
		{
			return new PaymentInfoDto
			{
				PaymentMethodId = 2,
				TypeOfPayment = PaymentMethodType.Cash,
				Price = 1000.00M
			};
		}

		/// <summary>
		/// EN: Test case - Payment by debit card must return the same list price.
		/// ES: Caso de prueba - Pago con tarjeta de débito debe retornar el mismo precio de lista.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForDebitCardWithListPrice()
		{
			return new PaymentInfoDto
			{
				PaymentMethodId = 3,
				TypeOfPayment = PaymentMethodType.DebitCard,
				Price = 1000.00M
			};
		}

		/// <summary>
		/// EN: Test case - You must return the list price when choosing a credit card in one payment only.
		/// ES: Caso de prueba - Debe retornar el precio de lista cuando se elige una tarjeta de crédito en un pago sólo.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardWithListPriceInOnePayment()
		{
			return new PaymentInfoDto
			{
				PaymentMethodId = 4,
				TypeOfPayment = PaymentMethodType.CreditCard,
				Price = 1000.00M,
				NumberOfPayments = 1,
				CardCompany = CardCompany.VICARD
			};
		}

		/// <summary>
		/// EN: Test case - You must return the final price when choosing a credit card in a payment with a charge for payment with it.
		/// ES: Caso de prueba - Debe retornar el precio final cuando se elige una tarjeta de crédito en un pago con un cargo por pago con la misma.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardWithExtraChargeInOnePayment()
		{
			return new PaymentInfoDto
			{
				PaymentMethodId = 5,
				TypeOfPayment = PaymentMethodType.CreditCard,
				Price = 1000.00M,
				NumberOfPayments = 1,
				CardCompany = CardCompany.VICARD
			};
		}

		/// <summary>
		/// EN: Test case - You must return the final price when you choose the VICARD credit card with payments in 3 payments.
		/// ES: Caso de prueba - Debe retornar el precio final cuando se elige la tarjeta de crédito VICARD con pagos en 3 cuotas.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardViCardWith3Payments()
		{
			return new PaymentInfoDto
			{
				PaymentMethodId = 6,
				TypeOfPayment = PaymentMethodType.CreditCard,
				Price = 1000.00M,
				NumberOfPayments = 3,
				CardCompany = CardCompany.VICARD
			};
		}

		/// <summary>
		/// EN: Test case - You must return the final price when you choose the VICARD credit card with payments in 6 payments.
		/// ES: Caso de prueba - Debe retornar el precio final cuando se elige la tarjeta de crédito VICARD con pagos en 6 cuotas.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardViCardWith6Payments()
		{
			return new PaymentInfoDto
			{
				PaymentMethodId = 6,
				TypeOfPayment = PaymentMethodType.CreditCard,
				Price = 1000.00M,
				NumberOfPayments = 6,
				CardCompany = CardCompany.VICARD
			};
		}

		/// <summary>
		/// EN: Test case - You must return the final price when you choose the VICARD credit card with payments in 12 payments.
		/// ES: Caso de prueba - Debe retornar el precio final cuando se elige la tarjeta de crédito VICARD con pagos en 12 cuotas.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardViCardWith12Payments()
		{
			return new PaymentInfoDto
			{
				PaymentMethodId = 6,
				TypeOfPayment = PaymentMethodType.CreditCard,
				Price = 1000.00M,
				NumberOfPayments = 12,
				CardCompany = CardCompany.VICARD
			};
		}

		/// <summary>
		/// EN: Test case - You must return the final price when you choose the VICARD credit card with payments in 18 payments.
		/// ES: Caso de prueba - Debe retornar el precio final cuando se elige la tarjeta de crédito VICARD con pagos en 18 cuotas.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardViCardWith18Payments()
		{
			return new PaymentInfoDto
			{
				PaymentMethodId = 6,
				TypeOfPayment = PaymentMethodType.CreditCard,
				Price = 1000.00M,
				NumberOfPayments = 18,
				CardCompany = CardCompany.VICARD
			};
		}

		/// <summary>
		/// EN: Test case - You must return the final price when you choose the ACARD credit card with payments in 3 payments.
		/// ES: Caso de prueba - Debe retornar el precio final cuando se elige la tarjeta de crédito ACARD con pagos en 3 cuotas.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardAcardWith3Payments()
		{
			return new PaymentInfoDto
			{
				PaymentMethodId = 6,
				TypeOfPayment = PaymentMethodType.CreditCard,
				Price = 1000.00M,
				NumberOfPayments = 3,
				CardCompany = CardCompany.ACARD
			};
		}

		/// <summary>
		/// EN: Test case - You must return the final price when you choose the ACARD credit card with payments in 6 payments.
		/// ES: Caso de prueba - Debe retornar el precio final cuando se elige la tarjeta de crédito ACARD con pagos en 6 cuotas.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardAcardWith6Payments()
		{
			return new PaymentInfoDto
			{
				PaymentMethodId = 6,
				TypeOfPayment = PaymentMethodType.CreditCard,
				Price = 1000.00M,
				NumberOfPayments = 6,
				CardCompany = CardCompany.ACARD
			};
		}

		/// <summary>
		/// EN: Test case - You must return the final price when you choose the ACARD credit card with payments in 12 payments.
		/// ES: Caso de prueba - Debe retornar el precio final cuando se elige la tarjeta de crédito ACARD con pagos en 12 cuotas.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardAcardWith12Payments()
		{
			return new PaymentInfoDto
			{
				PaymentMethodId = 6,
				TypeOfPayment = PaymentMethodType.CreditCard,
				Price = 1000.00M,
				NumberOfPayments = 12,
				CardCompany = CardCompany.ACARD
			};
		}

		/// <summary>
		/// EN: Test case - You must return the final price when you choose the MYCARD credit card with payments in 3 payments.
		/// ES: Caso de prueba - Debe retornar el precio final cuando se elige la tarjeta de crédito MYCARD con pagos en 3 cuotas.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardMyCardWith3Payments()
		{
			return new PaymentInfoDto
			{
				PaymentMethodId = 6,
				TypeOfPayment = PaymentMethodType.CreditCard,
				Price = 1000.00M,
				NumberOfPayments = 3,
				CardCompany = CardCompany.MYCARD
			};
		}

		/// <summary>
		/// EN: Test case - You must return the final price when you choose the MYCARD credit card with payments in 6 payments.
		/// ES: Caso de prueba - Debe retornar el precio final cuando se elige la tarjeta de crédito MYCARD con pagos en 6 cuotas.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardMyCardWith6Payments()
		{
			return new PaymentInfoDto
			{
				PaymentMethodId = 6,
				TypeOfPayment = PaymentMethodType.CreditCard,
				Price = 1000.00M,
				NumberOfPayments = 6,
				CardCompany = CardCompany.MYCARD
			};
		}

		/// <summary>
		/// EN: Test case - It must return an error because the chosen payment plan does not exist for the selected credit card.
		/// ES: Caso de prueba - Debe retornar error porque el plan de pagos elegido no existe para la tarjeta de crédito seleccionada.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardNoExistingPlan()
		{
			return new PaymentInfoDto
			{
				PaymentMethodId = 6,
				TypeOfPayment = PaymentMethodType.CreditCard,
				Price = 1000.00M,
				NumberOfPayments = 12,
				CardCompany = CardCompany.MYCARD
			};
		}
	}
}
