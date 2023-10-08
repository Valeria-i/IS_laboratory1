using System;
using System.Collections.Generic;
using System.IO;



namespace IS_lab
{
    public sealed class Cat
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Breed { get; set; }
        public bool Vaccination { get; set; }

        public Cat (string name, int age, string gender, string breed, bool vaccination)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Breed = breed;
            Vaccination = vaccination;
        }

        public static List<Cat> ReadCatFromCSV(string filePath)
        {
            List<Cat> cats = new List<Cat>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] values = line.Split(',');
                    string name = values[0];
                    int age = Convert.ToInt32(values[1]);
                    string gender = values[2];
                    string breed = values[3];
                    bool vaccination;
                    if (bool.TryParse(values[4], out vaccination))
                    {
                        Cat cat = new Cat(name, age, gender, breed, vaccination);
                        cats.Add(cat);
                    }
                    else
                    {
                        Console.WriteLine("Некорректное значение в поле Vaccination");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден");
            }
            catch (FormatException)
            {
                Console.WriteLine("Некорректный формат данных");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            return cats;
        }

    }

  
}

