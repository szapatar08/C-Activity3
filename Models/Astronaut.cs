namespace C_Activity3.Models;

public class Astronaut
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Lastname { get; set; }
    public required string Position { get; set; }
    public int HoursExperience { get; set; }
    public required List<Mision> Misions { get; set; }
}