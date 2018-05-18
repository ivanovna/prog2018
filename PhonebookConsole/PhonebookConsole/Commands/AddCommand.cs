using System.Media;
using System;
using System.Linq;
namespace PhonebookConsole.Commands
{
	/// <summary>
	/// Команда добавления
	/// </summary>
	public class AddCommand : CommandBase
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="loop">Цикл</param>
		public AddCommand(CommandLoop loop)
			: base(loop, 2)//Требуется два параметра
		{
		}

		/// <summary>
		/// Выполнить команду по параметрам
		/// </summary>
		/// <param name="parameters">Параметры</param>
		protected override void ExecuteByParams(string[] parameters)
		{
			var phone = parameters[0];
			var contact = parameters[1];
			var checkPhone = CheckPhone(phone);
			if (checkPhone != null)
			{
				WriteError(checkPhone);
			}
			else
			{
                var phoneEx = Loop.Model.Entries.FirstOrDefault(e =>
                    string.Equals(phone, e.Phone, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(contact, e.Contact, StringComparison.OrdinalIgnoreCase));
                if (phoneEx != null)
                {
                    WriteError(string.Format("Запись с такими данными уже существует ({0} - {1})", phoneEx.Phone, phoneEx.Contact));
                    return;
                }
                Loop.Model.Entries.Add(new PhonebookEntry() { Phone = phone, Contact = contact });
				
			}
		}

        /// <summary>
        /// Проверить телефон
        /// </summary>
        /// <param name="phone">Номер телефона</param>
        /// <returns>Сообщение об ошибке или null</returns>
        private string CheckPhone(string phone)
        {
            if (phone.Length == 1)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@".. \..\Жирик.wav");
                player.Play();
                return "Ошибка ввода!Телефон должен содержать минимум 2 символа";
            }

			for (int i = 0; i < phone.Length; ++i)
			{
				if (!char.IsDigit(phone[i]))
				{
					if (i != 0 || phone[i] != '+')
					{
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@".. \..\Жирик.wav");
                        player.Play();
                        return "Ошибка ввода!Телефон должен состоять из цифр и может начинаться на +";
					}
				}
			}
			return null;
		}
	}
}
 