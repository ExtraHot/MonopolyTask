using MonopolyTask.Models;

namespace MonopolyTask;

public class Program
{
    public static void Main(string[] args)
    {
        // Генерация тестовых данных
        var storage = new Storage();
        Random rand = new Random();

        // Генерация паллет и коробок
        for (int i = 1; i <= 10; i++) // Создаем 10 паллет
        {
            var pallet = new Pallet
            {
                Id = i,
                Width = rand.Next(100, 200) / 100.0, // Ширина паллеты от 1.0 до 2.0 м
                Height = rand.Next(150, 250) / 100.0, // Высота паллеты от 1.5 до 2.5 м
                Depth =
                    rand.Next(100, 150)
                    / 100.0 // Глубина паллеты от 1.0 до 1.5 м
                ,
            };

            // Генерация коробок для каждой паллеты
            for (int j = 1; j <= 3; j++) // На паллете будет 3 коробки
            {
                var box = new Box
                {
                    Id = j,
                    Width = rand.Next(50, 100) / 100.0, // Ширина коробки от 0.5 до 1.0 м
                    Height = rand.Next(50, 100) / 100.0, // Высота коробки от 0.5 до 1.0 м
                    Depth = rand.Next(50, 100) / 100.0, // Глубина коробки от 0.5 до 1.0 м
                    Weight = rand.Next(5, 15), // Вес коробки от 5 до 15 кг
                    ProductionDate = DateTime.Now.AddDays(
                        -rand.Next(1, 300)
                    ) // Случайная дата производства
                    ,
                };

                // Иногда назначаем срок годности, а иногда оставляем его пустым (null)
                if (rand.Next(0, 2) == 0) // С вероятностью 50% срок годности будет null
                {
                    box.ExpiryDate = null; // Срок годности не задан
                }
                else
                {
                    box.ExpiryDate = DateTime.Now.AddDays(rand.Next(10, 200)); // Срок годности задан случайным образом
                }

                // Добавляем коробку в паллету с проверкой
                pallet.AddBox(box);
            }

            storage.AddPallet(pallet);
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Вывести сгруппированные паллеты по сроку годности");
            Console.WriteLine("2. Вывести топ 3 паллет с наибольшим сроком годности");
            Console.WriteLine("0. Выход");
            Console.Write("Ваш выбор: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    storage.DisplayPalletsGroupedByExpiryDate();
                    break;

                case "2":
                    storage.DisplayTop3PalletsByExpiryDate();
                    break;

                case "0":
                    Console.WriteLine("Выход из программы...");
                    return;

                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}
