using System.Linq;

namespace PhonebookConsole.Commands
{
	/// <summary>
	/// Команда вывода всех записей
	/// </summary>
	public class PrintAllCommand : CommandBase
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="loop">Цикл</param>
		public PrintAllCommand(CommandLoop loop)
			: base(loop, 0)//Команда без параметров
		{
		}

		/// <summary>
		/// Выполнить команду по параметрам
		/// </summary>
		/// <param name="parameters">Параметры</param>
		protected override void ExecuteByParams(string[] parameters)
		{
			if (Loop.Model.Entries.Count == 0)
			{
				WriteError("Записей не найдено");
				return;
			}
			WriteLine("Найдены записи: ");
			foreach (var entry in Loop.Model.Entries)
			{
				WriteLine(entry.ToString());
			}
		}
	}
}
