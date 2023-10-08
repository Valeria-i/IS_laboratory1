using System;
using System.Collections.Generic;
using System.IO;

namespace IS_lab
{
    public class ControllerCats
    {
        private string filePath;
        private List<Cat> cats;

        public ControllerCats(string filePath)
        {
            this.filePath = filePath;
            cats = Cat.ReadCatFromCSV(filePath);
        }

        public void DisplayAllData()
        {
            if (cats.Count > 0)
            {
                foreach (Cat cat in cats)
                {
                    Console.WriteLine($"{cat.Name},{cat.Age},{cat.Gender},{cat.Breed},{cat.Vaccination}");
                }
            }
            else
            {
                Console.WriteLine("Нет записей");
            }
        }
        public void DisplayRecordByNymber(int stringnumber)
        {
            if (stringnumber >= 1 && stringnumber <= cats.Count)
            {
                Cat cat = cats[stringnumber - 1];
                Console.WriteLine($"{cat.Name},{cat.Age},{cat.Gender},{cat.Breed},{cat.Vaccination}");
            }
            else
            {
                Console.WriteLine("Нет записи с таким номером");
            }
        }
        public void AddRecord(string name, int age, string gender, string breed, bool vaccination)
        {
            Cat cat = new Cat(name, age, gender, breed, vaccination);
            cats.Add(cat);
            SaveDataToCSV();
            Console.WriteLine("Запись добавлена");
        }
        public void DeleteRecord(int stringnumber)
        {
            if (stringnumber >= 1 && stringnumber <= cats.Count)
            {
                cats.RemoveAt(stringnumber - 1);
                SaveDataToCSV();
                Console.WriteLine("Запись удалена");
            }
        }

        private void SaveDataToCSV()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Cat cat in cats)
                    {
                        writer.WriteLine("{0},{1},{2}", cat.Name, cat.Age, cat.Gender, cat.Breed, cat.Vaccination);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при сохранении данных: " + ex.Message);
            }
        }
       
    }

}

