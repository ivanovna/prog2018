namespace PhonebookConsole
{
	/// <summary>
	/// Интерфейс команды
	/// </summary>
	public interface ICommand
	{
		/// <summary>
		/// Выполнить команду
		/// </summary>
		/// <param name="text">Текстовая информация для выполнения</param>
		void Execute(string text);
	}
}
