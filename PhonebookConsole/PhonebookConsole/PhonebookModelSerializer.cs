using System.IO;
using System.Xml.Serialization;

namespace PhonebookConsole
{
	/// <summary>
	/// Класс-сериализатор модели телефонного справочника
	/// </summary>
	public static class PhonebookModelSerializer
	{
		/// <summary>
		/// Xml-Сериализатор
		/// </summary>
		private static readonly XmlSerializer _xs = new XmlSerializer(typeof(PhonebookModel));

		/// <summary>
		/// Записать в файл
		/// </summary>
		/// <param name="fileName">Имя файла</param>
		/// <param name="model">Модель</param>
		public static void WriteToFile(string fileName, PhonebookModel model)
		{
			using (var fileStream = File.Create(fileName))
			{
				_xs.Serialize(fileStream, model);
			}
		}
		/// <summary>
		/// Прочитать из файла
		/// </summary>
		/// <param name="fileName">Имя файла</param>
		/// <returns>Модель</returns>
		public static PhonebookModel LoadFromFile(string fileName)
		{
			using (var fileStream = File.OpenRead(fileName))
			{
				return (PhonebookModel)_xs.Deserialize(fileStream);
			}
		}
	}
}
