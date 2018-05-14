namespace PhonebookConsole
{
	/// <summary>
	/// Запись в справочнике телефонов
	/// </summary>
	public class PhonebookEntry
	{
		/// <summary>
		/// Телефон
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// Контакт
		/// </summary>
		public string Contact { get; set; }

		/// <summary>
		/// Преобразовать в строку
		/// </summary>
		public override string ToString()
		{
			return string.Format("{0} - {1}", Phone, Contact);
		}
	}
}
