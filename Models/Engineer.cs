using system;

namespace C_Activity3.Models;

public class Engineer
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Lastname { get; set; }
    public required string Speciality { get; set; }
    public int YearsExperience { get; set; }
}