namespace MonopolyTask.Models;

public class Box
{
    public int Id { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public double Weight { get; set; }
    public DateTime ProductionDate { get; set; }
    public DateTime? ExpiryDate { get; set; } // Срок годности может быть null

    // Если срок годности не указан, то добавляем 100 дней к дате производства
    public DateTime ExpiryDateComputed => ExpiryDate ?? ProductionDate.AddDays(100);

    public double Volume => Width * Height * Depth;
}
