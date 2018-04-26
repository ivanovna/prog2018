using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGames
{
    /// <summary>
    /// Информация о заявке на участие в проекте Игра
    /// </summary>
    public class RequestModel
    {
        /// <summary>
        /// Дата заполнения 
        /// </summary> 
        public DateTime Filled { get; set; }

        /// <summary>
        /// Вид спорта
        /// </summary>
        public Sport SportType { get; set; }

        /// <summary>
        /// Тип команды
        /// </summary>
        public TeamType TeamType { get; set; }

        /// <summary>
        /// Название команды
        /// </summary>
        public string TeamName { get; set; }

        /// <summary>
        /// Капитан команды
        /// </summary>
        public string TeamCaptain { get; set; }

        /// <summary>
        /// Количество участников
        /// </summary>
        public int CountCompetitors { get; set; }

        /// <summary>
        /// Информация о составе команды
        /// </summary>
        public List<TeamMember> TeamMembers { get; set; }
        

    }

    /// <summary>
    /// Участники команды
    /// </summary>
    public class TeamMember
    {
        /// <summary>
		/// Конструктор
		/// </summary>
		public TeamMember()
        {
            //Создаем объект контактной информации
            Contact = new ContactDetails();
        }
        /// <summary>
        /// ФИО участника
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Номер академ.группы игрока
        /// </summary>
        public string GroupNumber { get; set; }


        /// <summary>
        /// Колличество полных лет
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Состоит ли игрок в сборной университета по данному виду спорта
        /// </summary>
        public bool UniversityTeam { get; set; }

        /// <summary>
        /// Имеет ли игрок спортивный разряд по данному виду спорта
        /// </summary>
        public bool SportsСategory { get; set; }

        /// <summary>
        /// Контактные данные
        /// </summary>
        public ContactDetails Contact { get; set; }

        public override string ToString()
        {
            return string.Format("{0}    |    {1}    |    {2}    |    {3} лет    |    {4}    |    {5}", FullName, Sex == Sex.Male ? "М" : "Ж", GroupNumber, Age, Contact.PhoneNumber, Contact.EMail );
        }
        public TeamMember Clone()
        {
            return new TeamMember
            {
                FullName = FullName,
                Sex = Sex,
                GroupNumber = GroupNumber,
                Age = Age,
                UniversityTeam = UniversityTeam,
                SportsСategory = SportsСategory,
                Contact = Contact.Clone()
            };
        }
    }
    /// <summary>
    /// Контактные данные
    /// </summary>
    public class ContactDetails
    {
        /// <summary>
        /// Контактный телефон
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string EMail { get; set; }
        public ContactDetails Clone()
        {
            return new ContactDetails
            {
                PhoneNumber = PhoneNumber,
                EMail = EMail
            };
        }
    }

    public enum Sport
    {
        Basketball = 0,      // Баскетбол
        Volleyball = 1,     // Волейбол
        Handball = 2,      // Гандбол
        Hockey = 3,       // Хоккей
    }
    public enum TeamType
    {
        Mens,      // мужская команда
        Womens,   // женская команда
        Mixed,   // смешанная команда
    }
    public enum Sex
    {
        Male,
        Female,
    }
}


