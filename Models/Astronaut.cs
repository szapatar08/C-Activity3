using C_Activity3.Data;
using Microsoft.EntityFrameworkCore;

namespace C_Activity3.Models;

public class Astronaut
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Lastname { get; set; }
    public required string Position { get; set; }
    public int HoursExperience { get; set; }
    public required List<Mision> Misions { get; set; }

    public static void AddAstronaut()
    {
        using var context = new AppDbContext();
        
        Console.Write("\nPlease enter the astronaut name: ");
        string name = Console.ReadLine()!;
        Console.Write("Please enter the astronaut lastname: ");
        string lastname = Console.ReadLine()!;
        Console.Write("Please enter the astronaut position: \n" +
                      "1 - Rookie\n" +
                      "2 - Pilot\n" +
                      "3 - Major\n" +
                      "Please enter an option: ");
        int option = int.Parse(Console.ReadLine()!);
        string position = option == 1 ?  "Rookie" : option == 2 ? "Pilot" : "Major";
        Console.Write("Please enter the astronaut hours of experience: ");
        int hoursExperience = int.Parse(Console.ReadLine()!);
        
        Astronaut astronaut = new Astronaut() {Name = name, Lastname = lastname, Position = position, HoursExperience = hoursExperience, Misions = new List<Mision>()};
        context.Astronauts.Add(astronaut);
        context.SaveChanges();
        
        Console.WriteLine("Astronaut successfully added!\n");
    }

    public static void ShowAstronaut()
    {
        using var context = new AppDbContext();

        List<Astronaut> astronauts = context.
            Astronauts.
            Include(n => n.Misions).
            ToList();

        Console.WriteLine("\n****Astronauts****");
        foreach (Astronaut astronaut in astronauts)
        {
            string missions = "";
            if (astronaut.Misions.Count > 0)
            {
                foreach (Mision m in astronaut.Misions)
                {
                    missions += $"Mission: {m.Name} ";
                }
            }
            else
            {
                missions = "No Missions Found";
            }
            
            Console.WriteLine($"Id: {astronaut.Id}\n" +
                              $"Full Name: {astronaut.Name} {astronaut.Lastname}\n" +
                              $"Position: {astronaut.Position}\n" +
                              $"Hours of Experience: {astronaut.HoursExperience}\n" +
                              $"Missions: {missions}\n" +
                              $"-----------------------------------------------------\n");
        }
    }
}