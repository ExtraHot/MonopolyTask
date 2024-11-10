namespace MonopolyTask.Models;

public class Pallet
{
    public int Id { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public List<Box> Boxes { get; set; } = new List<Box>();

    // Если паллета содержит коробки, то берем минимальный срок годности, иначе используем минимальную возможную дату
    public DateTime ExpiryDate =>
        Boxes.Any() ? Boxes.Min(b => b.ExpiryDateComputed) : DateTime.MinValue; // Минимальный срок годности среди коробок

    // Объем паллеты
    public double Volume
    {
        get
        {
            double totalVolume = Boxes.Sum(b => b.Volume); // Суммируем объем всех коробок
            double palletVolume = Width * Height * Depth; // Добавляем объем самой паллеты
            return totalVolume + palletVolume;
        }
    }

    // Вес паллеты
    public double TotalWeight => Boxes.Sum(b => b.Weight) + 30; // Вес паллеты с коробками + 30 кг

    // Метод для добавления коробки в паллету с проверкой размеров
    public bool AddBox(Box box)
    {
        // Проверяем, что коробка не превышает размеры паллеты по ширине и глубине
        if (box.Width <= Width && box.Depth <= Depth)
        {
            Boxes.Add(box);
            return true;
        }
        else
        {
            Console.WriteLine(
                $"Ошибка: Коробка с ID {box.Id} не помещается на паллету {Id}. Размеры коробки: {box.Width}x{box.Depth}, размеры паллеты: {Width}x{Depth}"
            );
            return false;
        }
    }
}
