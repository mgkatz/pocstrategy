namespace PoCStrategy.Data
{
	/// <summary>
	/// EN: Class that represents information that could be in a database about the detail of payments with fees.
	/// ES: Clase que representa información que podría haber en una base de datos sobre el detalle de pagos en cuotas.
	/// </summary>
	public class PaymentFeesDetail
	{
		/// <summary>
		/// EN: Company to which the card belongs, if applicable.
		/// ES: Compañía a la que pertenece la tarjeta en caso que corresponda.
		/// </summary>
		public CardCompany CardCompany { get; set; }

		/// <summary>
		/// EN: Number of fees.
		/// ES: Número de cuotas.
		/// </summary>
		public int NumberOfFees { get; set; }

		/// <summary>
		/// EN: Percentage that may or may not be applied to a price within a plan to pay with fees.
		/// ES: Porcentaje que puede aplicarse o no sobre un precio dentro de un plan de cuotas.
		/// </summary>
		public decimal Percentage { get; set; }
	}
}
