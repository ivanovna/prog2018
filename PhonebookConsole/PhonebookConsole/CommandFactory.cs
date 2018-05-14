using System;
using System.Linq;

using PhonebookConsole.Commands;

namespace PhonebookConsole
{
	/// <summary>
	/// Фабрика команд
	/// </summary>
	public class CommandFactory
	{
		/// <summary>
		/// Разделитель - пробел
		/// </summary>
		private static readonly char[] _separator = new char[] { ' ' };

		/// <summary>
		/// Создать объект команды
		/// </summary>
		/// <param name="loop">Цикл обработки</param>
		/// <param name="commandText">Текст команды</param>
		/// <returns>Команда</returns>
		public ICommand Create(CommandLoop loop, string commandText)
		{
			if (string.IsNullOrEmpty(commandText))
				return null;
			//Получаем коллекцию строк, которые разделены пробелом
			var strs = commandText.Split(_separator, StringSplitOptions.RemoveEmptyEntries).ToList();
			if (strs.Count == 0)
				return null;
			var commandName = strs[0];
			if (commandName == "Добавить" || commandName == "добавить")
			{
				return new AddCommand(loop);
			}
			else if (commandName == "Удалить" || commandName == "удалить")
			{
				return new RemoveCommand(loop);
			}
			else if (commandName == "Найти" || commandName == "найти")
			{
				return new SearchCommand(loop);
			}
			else if (commandName == "Выход" || commandName == "выход")
			{
				return new ExitCommand(loop);
			}
			else if (commandName == "Просмотр" || commandName == "просмотр")
			{
				return new PrintAllCommand(loop);
			}
			return null;
		}
	}
}
