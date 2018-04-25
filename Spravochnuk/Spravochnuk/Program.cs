using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spravochnuk
{
    
    class Spravochnik
    {
        int nomer;
        string adress;
        string name;
        public override string ToString()
        {
            return String.Format("Абонент по имени:{0},зарегистрирован за номером:{1},проживает по адресу:{2}", name, nomer, adress);
        }
        public Spravochnik(int n, string a, string na)
        {
            this.nomer = n;
            this.adress = a;
            this.name = na;
        }
        public bool Findname(Spravochnik sp)
        {
            return sp.name == name; ;
        }
        public bool Findnumber(Spravochnik sp)
        {
            return sp.nomer == nomer; ;
        }
        public bool Findadrees(Spravochnik sp)
        {
            return sp.adress == adress;
        }
    }
    class EntryMainPoint
    {
        static void Main()
        {
            string command;
            int number;
            string name;
            string adress;
            List<Spravochnik> mylist = new List<Spravochnik>();
            Console.WriteLine("Введите количество абонентов:");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите имя абонента:");
                name = Console.ReadLine();
                Console.WriteLine("Введите номер абонента:");
                number = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите адрес абонента:");
                adress = Console.ReadLine();
                mylist.Add(new Spravochnik(number, adress, name));
            }
            do
            {
                Console.WriteLine(@"1:Найти по номеру
2:Найти по адресу
3:Найти по имени
4:выход");
                command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        Console.WriteLine("Введите номер абонента для поиска:");
                        int nomer = int.Parse(Console.ReadLine());
                        Spravochnik spp = new Spravochnik(nomer, "", "");
                        Spravochnik sp = mylist.Find(new Predicate<Spravochnik>(spp.Findnumber));
                        if (sp != null)
                        {
                            Console.WriteLine(sp);
                        }
                        else
                        {
                            Console.WriteLine("Абонент с таким номером не найден:");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Введите адресс абонента для поиска:");
                        string adress1 = Console.ReadLine();
                        Spravochnik spp1 = new Spravochnik(0, adress1, "");
                        Spravochnik sp1 = mylist.Find(new Predicate<Spravochnik>(spp1.Findadrees));
                        if (sp1 != null)
                        {
                            Console.WriteLine(sp1);
                        }
                        else
                        {
                            Console.WriteLine("Абонент с таким адресом не найден:");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Введите имя для поиска:");
                        string names = Console.ReadLine();
                        Spravochnik sppp = new Spravochnik(0, "", names);
                        mylist.FindAll(new Predicate<Spravochnik>(sppp.Findname)).ForEach(delegate (Spravochnik s) { Console.WriteLine(s); });
                        break;
                    default:
                        Console.WriteLine("Вводите значения от 1 до 4:");
                        break;
                }

            } while (command != "4");
        }
    }
}