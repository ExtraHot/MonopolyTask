namespace MonopolyTask;

public class Storage
{
    private List<Pallet> _pallets;

    public Storage()
    {
        _pallets = new List<Pallet>();
    }

    // Добавить паллету
    public void AddPallet(Pallet pallet)
    {
        _pallets.Add(pallet);
    }

    // Группировка паллет по сроку годности
    public IEnumerable<IGrouping<DateTime, Pallet>> GroupByExpiryDate()
    {
        return _pallets
            .GroupBy(p => p.ExpiryDate)
            .OrderBy(g => g.Key);  // Сортируем по сроку годности
    }

    // Получить 3 паллеты с наибольшим сроком годности, отсортированные по объему
    public List<Pallet> GetTop3PalletsByExpiryDate()
    {
        return _pallets
            .OrderByDescending(p => p.Boxes.Max(b => b.ExpiryDate))  // Сортируем по самой поздней коробке
            .ThenBy(p => p.Volume)  // Затем по объему
            .Take(3)
            .ToList();
    }

    // Вывод всех паллет, сгруппированных по сроку годности и отсортированных по весу
    public void DisplayPalletsGroupedByExpiryDate()
    {
        var groupedPallets = GroupByExpiryDate();

        foreach (var group in groupedPallets)
        {
            Console.WriteLine($"Группа по сроку годности: {group.Key.ToShortDateString()}");

            foreach (var pallet in group.OrderBy(p => p.TotalWeight))  // Сортируем по весу
            {
                Console.WriteLine($"Паллета ID: {pallet.Id}, Вес: {pallet.TotalWeight} кг, Объем: {pallet.Volume} м³");
            }
        }
    }

    // Вывод 3 паллет с наибольшим сроком годности
    public void DisplayTop3PalletsByExpiryDate()
    {
        var topPallets = GetTop3PalletsByExpiryDate();

        Console.WriteLine("Топ 3 паллет с наибольшим сроком годности:");

        foreach (var pallet in topPallets)
        {
            Console.WriteLine($"Паллета ID: {pallet.Id}, Вес: {pallet.TotalWeight} кг, Объем: {pallet.Volume} м³, Срок годности: {pallet.ExpiryDate.ToShortDateString()}");
        }
    }
}