namespace PoCStrategy.Business.Extensions
{
	/// <summary>
	/// EN: Class to extend functionalities related to prices.
	/// ES: Clase para extender funcionalidades relativas a los precios.
	/// </summary>
	public static class PriceExtensions
	{
		/// <summary>
		/// EN: Extension method to apply a percentage on a given price.
		/// ES: Método de extensión para aplicar un porcentaje sobre un precio dado.
		/// </summary>
		/// <param name="price">
		/// EN: The given price.
		/// ES: El precio dado.
		/// </param>
		/// <param name="percentage">
		/// EN: The percentage to be applied in the price.
		/// ES: El porcentaje a aplicar en el precio.
		/// </param>
		/// <returns>
		/// EN: The price given plus the applied percentage.
		/// ES: El precio dado más el porcentaje aplicado.
		/// </returns>
		public static decimal ApplyPercentage(this decimal price, decimal percentage)
			=> percentage == 0 ? price : price * (1 + (percentage / 100));
	}
}
