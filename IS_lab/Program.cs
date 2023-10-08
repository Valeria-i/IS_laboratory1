using System;


namespace IS_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "lab1.csv";

            ControllerCats catController = new ControllerCats(filePath);
            bool exit = false;
            //catController.LoadData();
            do
            {
                Console.WriteLine("Меню");
                Console.WriteLine("1. Вывести все записи");
                Console.WriteLine("2. Вывести запись по номеру");
                Console.WriteLine("3. Создать запись");
                Console.WriteLine("4. Удалить запись");
                Console.WriteLine("Esc. Выйти из программы");
                ConsoleKeyInfo userInput = Console.ReadKey();
                Console.WriteLine();

                switch (userInput.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Все записи:");
                        catController.DisplayAllData();
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Введите номер записи, которую необходимо вывести:");
                        int recordNumber;
                        if (int.TryParse(Console.ReadLine(), out recordNumber))
                        {
                            catController.DisplayRecordByNymber(recordNumber);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный формат числа");
                        }
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Введите имя, возраст, пол, породу кота через запятую:");
                        string input = Console.ReadLine();
                        string[] values = input.Split(',');
                        if (values.Length == 5)
                        {
                            string name = values[0].Trim();
                            int age;
                            string gender = values[2].Trim();
                            string breed = values[3].Trim();
                            bool vaccination = bool.Parse(values[4].Trim());

                            if (int.TryParse(values[1].Trim(), out age))
                            {
                                string color = values[2].Trim();
                                catController.AddRecord(name, age, gender, breed, vaccination);
                                Console.WriteLine("Запись создана.");
                            }
                            else
                            {
                                Console.WriteLine("Некорректный формат возраста");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный формат ввода");
                        }
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Введите номер записи, которую необходимо удалить:");
                        int recordNumberToDelete;
                        if (int.TryParse(Console.ReadLine(), out recordNumberToDelete))
                        {
                            catController.DeleteRecord(recordNumberToDelete);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный формат числа");
                        }
                        Console.ReadLine();
                        break;
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Пожалуйста, выберите пункт меню снова.");
                        break;
                }

            } while (!exit);
        }
    }
}