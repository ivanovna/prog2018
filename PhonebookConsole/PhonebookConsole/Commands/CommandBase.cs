using System;
using System.Linq;

namespace PhonebookConsole.Commands
{
	/// <summary>
	/// Базовый класс команды
	/// </summary>
	public abstract class CommandBase : ICommand
	{
		/// <summary>
		/// Разделитель - пробел
		/// </summary>
		private static readonly char[] _separator = new char[] { ' ' };

		/// <summary>
		/// Защищенный конструктор
		/// </summary>
		/// <param name="loop">Цикл обработки</param>
		/// <param name="paramsCount">Требуемое количество параметров</param>
		protected CommandBase(CommandLoop loop, int paramsCount)
		{
			_paramsCount = paramsCount;
			_loop = loop;
		}

		/// <summary>
		/// Требуемое количество параметрво
		/// </summary>
		private readonly int _paramsCount;

		private readonly CommandLoop _loop;
		/// <summary>
		/// Цикл обработки
		/// </summary>
		protected CommandLoop Loop
		{
			get { return _loop; }
		}

		/// <summary>
		/// Выполнить команду
		/// </summary>
		/// <param name="text">Текст команды</param>
		public void Execute(string text)
		{
			//Получаем коллекцию строк, которые разделены пробелом
			var strs = text.Split(_separator, _paramsCount + 1, StringSplitOptions.RemoveEmptyEntries);
			//Проверяем, что для выполнения команды было передано нужно число параметров (не считая имени самой команды)
			if (strs.Length != _paramsCount + 1)
			{
				WriteError(string.Format("Для выполнения команды требуется {0} параметров", _paramsCount));
				return;
			}
			var commandName = strs[0];
			if (strs.Length > 1)
			{
				//Если параметров команды больше одного (т.е. имени команды)
				//то передаем оставшиеся аргументы
				ExecuteByParams(strs.Skip(1).ToArray());
			}
			else
			{
				//Если передано только название команды, то вызываем его
				ExecuteByParams(null);
			}
		}

		/// <summary>
		/// Выполнить команду по параметрам (для реализации в классах-наследниках)
		/// </summary>
		/// <param name="parameters">Параметры</param>
		protected abstract void ExecuteByParams(string[] parameters);

		/// <summary>
		/// Отобразить сообщение об ошибке
		/// </summary>
		/// <param name="message">Сообщение</param>
		protected void WriteError(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(message);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		/// <summary>
		/// Отобразить сообщение
		/// </summary>
		/// <param name="message">Сообщение</param>
		protected void WriteLine(string message)
		{
			Console.WriteLine(message);
		}
	}
}
