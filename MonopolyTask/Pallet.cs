namespace MonopolyTask;

public class Pallet
{
    private int id { get; set; }
    private int width { get; set; }
    private int height { get; set; }
    private int depth { get; set; }
    private int weight { get; set; }
    
    private List<Box> boxes = new List<Box>();
}