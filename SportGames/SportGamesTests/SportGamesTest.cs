using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportGames;
using System.Collections.Generic;

namespace SportGamesTests
{
    [TestClass]
    public class SportGamesTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dto = new RequestModel
            {
                Filled = DateTime.Now,
                SportType = Sport.Basketball,
                TeamType = TeamType.Mixed,
                TeamName = "TheBest",
                TeamCaptain = "Ivan Ivanov",
                CountCompetitors = 3,
                TeamMembers = new List<TeamMember>()
                {
                    new TeamMember
                    {
                        FullName = "Ivan Ivanov",
                        Sex = Sex.Male,
                        GroupNumber="RI-261223",
                        Age=21,
                        UniversityTeam=false,
                        SportsСategory=true,
                        Contact = new ContactDetails()
                        {
                            PhoneNumber="89023494883",
                            EMail="ivan@mail.ru",
                        }
                    },
                    new TeamMember
                    {
                        FullName = "Maria Petrova",
                        Sex = Sex.Female,
                        GroupNumber="RI-261221",
                        Age=20,
                        UniversityTeam=true,
                        SportsСategory=true,
                        Contact = new ContactDetails()
                        {
                            PhoneNumber="89023467834",
                            EMail="maria@yandex.ru",

                        }
                    },
                    new TeamMember
                    {
                        FullName = "Petr Sidorov",
                        Sex = Sex.Female,
                        GroupNumber="RI-261220",
                        Age=19,
                        UniversityTeam=false,
                        SportsСategory=false,
                        Contact = new ContactDetails()
                        {
                            PhoneNumber="89483787834",
                            EMail="petr@yandex.ru",
                        }
                    }
                }
            };
        }
    }
}



