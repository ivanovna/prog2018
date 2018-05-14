using System.Linq;

namespace PhonebookConsole.Commands
{
	/// <summary>
	/// Команда выхода
	/// </summary>
	public class ExitCommand : CommandBase
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="loop">Цикл</param>
		public ExitCommand(CommandLoop loop)
			: base(loop, 0)//Команда без параметров
		{
		}

		/// <summary>
		/// Выполнить команду по параметрам
		/// </summary>
		/// <param name="parameters">Параметры</param>
		protected override void ExecuteByParams(string[] parameters)
		{
            //Оповещаем цикл о необходимости остановки
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@".. \..\прощание.wav");
            player.Play();
            Loop.Break = true;
		}
	}
}
