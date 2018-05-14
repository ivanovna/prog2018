using System.Media;
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
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\User\Desktop\веселье\prog2018\PhonebookConsole\PhonebookConsole\Жирик.wav");
                player.Play();
                return "Ошибка ввода!Телефон должен содержать минимум 2 символа";
            }

			for (int i = 0; i < phone.Length; ++i)
			{
				if (!char.IsDigit(phone[i]))
				{
					if (i != 0 || phone[i] != '+')
					{
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\User\Desktop\веселье\prog2018\PhonebookConsole\PhonebookConsole\Жирик.wav");
                        player.Play();
                        return "Ошибка ввода!Телефон должен состоять из цифр и может начинаться на +";
					}
				}
			}
			return null;
		}
	}
}
 