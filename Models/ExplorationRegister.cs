namespace C_Activity3.Models;

public class ExplorationRegister
{
    public int Id { get; set; }
    public string Planet { get; set; }
    public string Description { get; set; }
    public string Risk { get; set; }
    
    public int MisionId { get; set; }
    public Mision Mision { get; set; }
}