using System.Diagnostics;

namespace C_Activity3.Models;

public class Mision
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly Date { get; set; }
    public string Status { get; set; }
    
    public int AstronautId { get; set; }
    public Astronaut Astronaut { get; set; }
    public int SpaceshipId { get; set; }
    public Spaceship Spaceship { get; set; }
    
    public List<ExplorationRegister> Registers { get; set; }
}