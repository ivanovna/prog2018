using System;
using System.IO;
using System.Reflection;
using System.Media;

namespace PhonebookConsole
{
	/// <summary>
	/// Программа
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@".. \..\ржач.wav");
            player.Play();
            Console.Title = "MYSTICAL BEASTS";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Телефонный справочник MYSTICAL BEASTS.\nИнструкция по работе с ТС.\nДанный телефонный справочник содержит 5 команд:\n1.Добавить - для добавления контакта в ТС необходимо указать два параметра: номер телефона и имя контакта.\n2.Найти - поиск по контактам ТС осуществляется либо по номеру телефона, либо по имени.Для того что бы найти необходиый контакт надо указать один из параметров.\n3.Удалить - для удаления контакта из ТС необходимо полностью указать номер телефона или имя контакта.Для точности рекомендуем  сначала убедиться в правильности номера телефона или имени.\n4.Просмотр - для просмотра всех контактов ТС необходимо указать только саму команду,без дополнительных параметров.\n5.Выход - для выхода из программы необходимо указать команду,без дополнительных параметров.При выходе из программы вся информация сохраняется в файле,при не корректном выходе информация будет утеряна.\nДля реализации команды,в строке введите команду которую необходимо выполнить и необходимые параметры(если есть).Команда и параметры вводятся через пробел.\nПример:\nДобавить 89193245709 Бородин\nТем самым вы добавили в ТС контакт с номером 89193245709 под именем Бородин.\nОстальные команды используются по аналогии.Успехов в использовании.\nПо всем дополнительным вопросам обращаться в службу поддержки по номеру 89193825309.\n");

            PhonebookModel model;
			if (File.Exists(_phonebookFileName))
			{
				try
				{
					model = PhonebookModelSerializer.LoadFromFile(_phonebookFileName);
				}
				catch(Exception ex)
				{
					WriteException("Ошибка чтения файла телефонного справочника", ex);
					model = new PhonebookModel();
				}
			}
			else
			{
				model = new PhonebookModel();
			}
			_loop.Model = model;
			
			try
			{
				_loop.DoLoop();
			}
			catch (Exception ex)
			{
				WriteException("Что то пошло не так...ошибка работы цикла", ex);
			}

			try
			{
				PhonebookModelSerializer.WriteToFile(_phonebookFileName, _loop.Model);
			}
			catch (Exception ex)
			{
				WriteException("Что то пошло не так..ошибка сохранения телефонного справочника", ex);
			}
			Console.WriteLine("Нажмите любую клавишу...");
			Console.ReadKey();
		}

		/// <summary>
		/// Вывести сообщение об ошибке на экран
		/// </summary>
		/// <param name="header">Заголовок</param>
		/// <param name="ex">Сообщение об ошибке</param>
		private static void WriteException(string header, Exception ex)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(header);
			Console.WriteLine(ex.Message);
			Console.ForegroundColor = ConsoleColor.Yellow;
		}

		/// <summary>
		/// Имя файла со справочником
		/// </summary>
		private static readonly string _phonebookFileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Phobebook.xml");

		/// <summary>
		/// Цикл
		/// </summary>
		private static readonly CommandLoop _loop = new CommandLoop();
	}
}
