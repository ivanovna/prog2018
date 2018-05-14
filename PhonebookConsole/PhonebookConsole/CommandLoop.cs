using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace PhonebookConsole
{
	/// <summary>
	/// Фасадный класс цикла обработки
	/// </summary>
	public class CommandLoop
	{
		/// <summary>
		/// Выполнить цикл
		/// </summary>
		public void DoLoop()
		{
			//Сбрасываем флаг остановки цикла
			Break = false;
			//Выполняем цикл, пока не будет выставлен флаг
			while (!Break)
			{
				Console.WriteLine("Введите команду:");
				var text = Console.ReadLine();
				var command = _factory.Create(this, text);
				if (command == null)
				{
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@".. \..\Жирик.wav");
                    player.Play();
                    Console.WriteLine("Команда не найдена");
				}
				else
				{
					command.Execute(text);
                    Console.WriteLine();
				}
			}
		}

		/// <summary>
		/// Фабрика команд
		/// </summary>
		private readonly CommandFactory _factory = new CommandFactory();

		/// <summary>
		/// Модель телефонной книги
		/// </summary>
		public PhonebookModel Model { get; set; }

		/// <summary>
		/// Флаг остановки цикла
		/// </summary>
		public bool Break { get; set; }
	}
}
