namespace C_Activity3.Models;

public class Astronaut
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Position { get; set; }
    public int HoursExperience { get; set; }
    public List<Mision> Misions { get; set; }
}