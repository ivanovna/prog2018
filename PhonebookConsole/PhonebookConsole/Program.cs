using System;
using System.IO;
using System.Reflection;

namespace PhonebookConsole
{
	/// <summary>
	/// Программа
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
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
			Console.ForegroundColor = ConsoleColor.Gray;
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
