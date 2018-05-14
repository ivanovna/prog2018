using System.Linq;
using System.Media;


namespace PhonebookConsole.Commands
{
	/// <summary>
	/// Команда удаления
	/// </summary>
	public class RemoveCommand : CommandBase
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="loop">Цикл</param>
		public RemoveCommand(CommandLoop loop)
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
			var entry = Loop.Model.Entries.FirstOrDefault(e => e.Contact == text || e.Phone == text);
			if (entry == null)
			{
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\User\Desktop\веселье\prog2018\PhonebookConsole\PhonebookConsole\ржач.wav");
                player.Play();
                WriteError("Запись не найдена");
				return;
			}
			Loop.Model.Entries.Remove(entry);
		}
	}
}
