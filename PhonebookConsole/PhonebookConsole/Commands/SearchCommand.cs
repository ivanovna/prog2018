using System.Linq;

namespace PhonebookConsole.Commands
{
	/// <summary>
	/// Команда поиска
	/// </summary>
	public class SearchCommand : CommandBase
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="loop">Цикл</param>
		public SearchCommand(CommandLoop loop)
			: base(loop, 1)//Команда с одним параметром
		{
		}

		/// <summary>
		/// Выполнить команду по параметрам
		/// </summary>
		/// <param name="parameters">Параметры</param>
		protected override void ExecuteByParams(string[] parameters)
		{
			var text = parameters[0];
			var entries = Loop.Model.Entries.Where(e => e.Contact.Contains(text) || e.Phone.Contains(text));
			if (entries.Count() == 0)
			{
				WriteError("Записей не найдено");
				return;
			}
			WriteLine("Найдены записи: ");
			foreach (var entry in entries)
			{
				WriteLine(entry.ToString());
			}
		}
	}
}
