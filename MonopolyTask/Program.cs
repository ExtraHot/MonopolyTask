namespace MonopolyTask;
public class Program
{
    public static void Main()
    {
        var storage = new Storage();

        // Генерация тестовых данных
        for (int i = 1; i <= 10; i++)
        {
            var pallet = new Pallet
            {
                Id = i,
                Width = 1.2,
                Height = 1.5,
                Depth = 1.0
            };

            for (int j = 1; j <= 3; j++)
            {
                var box = new Box
                {
                    Id = j,
                    Width = 0.6,
                    Height = 0.8,
                    Depth = 0.5,
                    Weight = 5.0 + j,  // Вес коробки
                    ProductionDate = DateTime.Now.AddDays(-j * 10)  // Разные даты производства
                };

                pallet.Boxes.Add(box);
            }

            storage.AddPallet(pallet);
        }

        // Вывод сгруппированных паллет
        storage.DisplayPalletsGroupedByExpiryDate();

        // Вывод топ 3 паллет с наибольшим сроком годности
        storage.DisplayTop3PalletsByExpiryDate();
    }
}