namespace C_Activity3.Models;

public class Spaceship
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public int Capacity { get; set; }
    public string Status { get; set; }
    public List<Mision> Misions { get; set; }
}