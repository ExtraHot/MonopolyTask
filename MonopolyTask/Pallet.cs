namespace MonopolyTask;

public class Pallet
{
    public int Id { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public double Weight { get; set; }  // Вес паллеты (включая коробки)
    public List<Box> Boxes { get; set; } = new List<Box>();

    // Срок годности паллеты - минимальный срок годности среди коробок
    public DateTime ExpiryDate
    {
        get
        {
            return Boxes.Min(b => b.ExpiryDate);
        }
    }

    // Объем паллеты - сумма объема коробок и объема паллеты
    public double Volume
    {
        get
        {
            double totalVolume = Boxes.Sum(b => b.Volume);
            double palletVolume = Width * Height * Depth;
            return totalVolume + palletVolume;
        }
    }

    // Вес паллеты - сумма веса коробок + 30 кг (собственный вес паллеты)
    public double TotalWeight
    {
        get
        {
            return Boxes.Sum(b => b.Weight) + 30;  // +30 кг - собственный вес паллеты
        }
    }
}