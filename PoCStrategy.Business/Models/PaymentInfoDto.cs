using PoCStrategy.Data;

namespace PoCStrategy.Business.Models
{
	/// <summary>
	/// EN: DTO type model to handle the information of a payment within the application.
	/// ES: Modelo de tipo DTO para manejar la información de un pago dentro de la aplicación.
	/// </summary>
	public class PaymentInfoDto
	{
		/// <summary>
		/// EN: Payment method id.
		/// ES: Id del método de pago.
		/// </summary>
		public int PaymentMethodId { get; set; }

		/// <summary>
		/// EN: Method of payment.
		/// ES: Forma de pago.
		/// </summary>
		public PaymentMethodType TypeOfPayment { get; set; }

		/// <summary>
		/// EN: Number of payments.
		/// ES: Número de cuotas.
		/// </summary>
		public int NumberOfPayments { get; set; }

		/// <summary>
		/// EN: Original price.
		/// ES: Precio original.
		/// </summary>
		public decimal Price { get; set; }

		/// <summary>
		/// EN: Company to which the card belongs, if applicable.
		/// ES: Compañía a la que pertenece la tarjeta en caso que corresponda.
		/// </summary>
		public CardCompany? CardCompany { get; set; }
	}
}
