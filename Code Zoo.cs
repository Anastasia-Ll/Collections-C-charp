using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {        
        public struct Animal
        {
            public string name;
            public bool type; // теплолюбивое/морозоустойчивое
            public bool type1; // хищное/травоядное
        }

        public struct Zoo
        {
            public string title;
            public List<Cage> zooCages;
        }

        public struct Cage
        {
            public int number;
            public bool typeCage; // тёплый/холодный
            public List<Animal> pet;
        }

        static void Main(string[] args)
        {
            Animal an1 = new Animal
            {
                name = "Lion",
                type = false,
                type1 = true
            };
            Animal an2 = new Animal
            {
                name = "Snake",
                type = true,
                type1 = true
            };
            Animal an3 = new Animal
            {
                name = "Monkey",
                type = true,
                type1 = true
            };
            Animal an4 = new Animal
            {
                name = "Bear",
                type = false,
                type1 = true
            };

            Zoo zoo = new Zoo
            {
                title = "Роев Ручей"
            };
            zoo.zooCages = new List<Cage>();
            zoo.zooCages.Add(new Cage {number = 1, typeCage = true, pet = new List<Animal> {an1, an2} });
            zoo.zooCages.Add(new Cage {number = 2, typeCage = false, pet = new List<Animal> {an3, an4} });


            {
                int k = 0; // счётчик несовпадений животных
                int t = 0; // счётчик несовпадений вальеров
                {
                    if (zoo.zooCages[0].pet[0].type1 != zoo.zooCages[0].pet[1].type1) //сравниваем животных 
                        k++;
                    if (zoo.zooCages[1].pet[0].type1 != zoo.zooCages[1].pet[1].type1)
                        k++;
                }

                {
                    if (zoo.zooCages[0].typeCage != zoo.zooCages[0].pet[0].type) //сравниваем вальеры
                        t++;
                    if (zoo.zooCages[0].typeCage != zoo.zooCages[0].pet[1].type)
                        t++;
                    if (zoo.zooCages[1].typeCage != zoo.zooCages[1].pet[0].type)
                        t++;
                    if (zoo.zooCages[1].typeCage != zoo.zooCages[1].pet[1].type)
                        t++;
                }

                Console.WriteLine("Количество инцидентов:" + (k + t));
            }
            Console.ReadKey();


        }
    }
}
