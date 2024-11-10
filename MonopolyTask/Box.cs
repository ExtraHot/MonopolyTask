namespace MonopolyTask;

public class Box
{
    public int Id { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public double Weight { get; set; }
    public DateTime ProductionDate { get; set; }
    public DateTime ExpiryDate
    {
        get
        {
            return ProductionDate.AddDays(100);  // Срок годности через 100 дней
        }
    }

    // Объем коробки
    public double Volume => Width * Height * Depth;
}