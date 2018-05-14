using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookConsole
{
	/// <summary>
	/// Модель телефонного справочника
	/// </summary>
	public class PhonebookModel
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		public PhonebookModel()
		{
			Entries = new List<PhonebookEntry>();
		}

		/// <summary>
		/// Записи в телефонной книге
		/// </summary>
		public List<PhonebookEntry> Entries { get; set; }
	}
}
