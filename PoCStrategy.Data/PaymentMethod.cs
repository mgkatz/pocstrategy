namespace PoCStrategy.Data
{
	/// <summary>
	/// EN: Class that represents information that could be in a database about the method of payment.
	/// ES: Clase que representa información que podría haber en una base de datos sobre una forma de pago.
	/// </summary>
	public class PaymentMethod
	{
		/// <summary>
		/// EN: Payment method id.
		/// ES: Id del método de pago.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// EN: Name of the payment method.
		/// ES: Nombre del método de pago.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// EN: Type of payment method.
		/// ES: Tipo de método de pago.
		/// </summary>
		public PaymentMethodType TypeOfPayment { get; set; }

		/// <summary>
		/// EN: Percentage that may or may not be applied to a price.
		/// ES: Porcentaje que puede aplicarse o no sobre un precio.
		/// </summary>
		public decimal Percentage { get; set; }

		/// <summary>
		/// EN: Relationship with details of payments with fees.
		/// ES: Relación con detalles de pagos en cuotas.
		/// </summary>
		public PaymentFeesDetail[] Fees { get; set; }
	}
}
