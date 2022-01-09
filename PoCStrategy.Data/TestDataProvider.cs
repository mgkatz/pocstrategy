using System.Linq;

namespace PoCStrategy.Data
{
	/// <summary>
	/// EN: Static class as a mock that would simulate what would be returned in the data layer when performing a query.
	/// ES: Clase estática a manera de mock que simularía lo que se retornaría en la capa de datos al realizar una consulta.
	/// </summary>
	public static class TestDataProvider
	{
		/// <summary>
		/// EN: List with the information of the payment methods that simulates the information that could be in a database.
		/// ES: Lista con la información de los métodos pago que simula la información que podría haber en una base de datos.
		/// </summary>
		private static readonly PaymentMethod[] _paymentMethods = new PaymentMethod[]
		{
			new PaymentMethod
			{
				Id = 1,
				Name = "Cash with List Price",
				TypeOfPayment = PaymentMethodType.Cash
			},
			new PaymentMethod
			{
				Id = 2,
				Name = "Cash with Discount",
				TypeOfPayment = PaymentMethodType.Cash,
				Percentage = -12
			},
			new PaymentMethod
			{
				Id = 3,
				Name = "Debit Card with List Price",
				TypeOfPayment = PaymentMethodType.DebitCard
			},
			new PaymentMethod
			{
				Id = 4,
				Name = "Credit Card with List Price in one Payment",
				TypeOfPayment = PaymentMethodType.CreditCard
			},
			new PaymentMethod
			{
				Id = 5,
				Name = "Credit Card with Extra Charge in one Payment",
				TypeOfPayment = PaymentMethodType.CreditCard,
				Percentage = 15
			},
			new PaymentMethod
			{
				Id = 6,
				Name = "Credit Card with Payments",
				TypeOfPayment = PaymentMethodType.CreditCard,
				PaymentPlans = new PaymentPlan[]
				{
					new PaymentPlan { CardCompany = CardCompany.VICARD, NumberOfPayments = 3, Percentage = 0 },
					new PaymentPlan { CardCompany = CardCompany.VICARD, NumberOfPayments = 6, Percentage = 0 },
					new PaymentPlan { CardCompany = CardCompany.VICARD, NumberOfPayments = 12, Percentage = 10 },
					new PaymentPlan { CardCompany = CardCompany.VICARD, NumberOfPayments = 18, Percentage = 20 },
					new PaymentPlan { CardCompany = CardCompany.ACARD, NumberOfPayments = 3, Percentage = 7 },
					new PaymentPlan { CardCompany = CardCompany.ACARD, NumberOfPayments = 6, Percentage = 12 },
					new PaymentPlan { CardCompany = CardCompany.ACARD, NumberOfPayments = 12, Percentage = 18 },
					new PaymentPlan { CardCompany = CardCompany.MYCARD, NumberOfPayments = 3, Percentage = 0 },
					new PaymentPlan { CardCompany = CardCompany.MYCARD, NumberOfPayments = 6, Percentage = 0 },
				}
			}
		};

		/// <summary>
		/// EN: Method that simulates a query in the data layer to obtain information about a specific payment method.
		/// ES: Método que simula una consulta en la capa de datos para obtener información sobre un método de pago específico.
		/// </summary>
		/// <param name="id">
		/// EN: Id of the payment method to search.
		/// ES: Id del método de pago a buscar.
		/// </param>
		/// <returns>
		/// EN: The information of the payment method searched.
		/// ES: La información del método de pago buscado.
		/// </returns>
		public static PaymentMethod GetPaymentMethodInfo(int id)
			=> _paymentMethods.SingleOrDefault(pm => pm.Id == id);
	}
}
