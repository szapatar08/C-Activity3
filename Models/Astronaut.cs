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

        if (astronauts.Count > 0)
        {
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
        else
        {
            Console.WriteLine("\nThere are not astronauts registered\n");
        }
    }

    public static void UpdateAstronaut()
    {
        var context = new AppDbContext();

        Console.Write("\nPlease enter the astronaut id: ");
        int id = int.Parse(Console.ReadLine()!);
        
        Astronaut astronaut = context.Astronauts.Where(a => a.Id == id).FirstOrDefault();

        if (astronaut == null)
        {
            Console.WriteLine($"\nThere is no Astronaut with Id: {id}\n");
        }
        else
        {
            Console.Write("What do you want to update?\n" +
                          "1 - Name\n" +
                          "2 - Lastname\n" +
                          "3 - Position\n" +
                          "4 - Hours of Experience\n" +
                          "Please select an option: ");
            int op = int.Parse(Console.ReadLine()!);

            switch (op)
            {
                case 1:
                    Console.Write("What is the new name: ");
                    string newName = Console.ReadLine()!;
                    astronaut.Name = newName;
                    context.SaveChanges();
                    break;
                
                case 2:
                    Console.Write("What is the new lastname: ");
                    string newLastname = Console.ReadLine()!;
                    astronaut.Lastname = newLastname;
                    context.SaveChanges();
                    break;
                
                case 3:
                    Console.Write("What is the new position: ");
                    string newPosition = Console.ReadLine()!;
                    astronaut.Position = newPosition;
                    context.SaveChanges();
                    break;
                
                case 4:
                    Console.Write("Update the hours of experience: ");
                    int hoursExperince = int.Parse(Console.ReadLine()!);
                    astronaut.HoursExperience = hoursExperince;
                    context.SaveChanges();
                    break;
            }

            Console.WriteLine("Successfully updated\n");
        }
    }

    public static void DeleteAstronaut()
    {
        var context = new AppDbContext();
        
        Console.Write("\nPlease enter the astronaut id: ");
        int id = int.Parse(Console.ReadLine()!);
        
        Astronaut astronaut = context.Astronauts.Where(a => a.Id == id).FirstOrDefault();

        if (astronaut == null)
        {
            Console.WriteLine($"\nThere is no Astronaut with Id: {id}\n");
        }
        else
        {
            context.Astronauts.Remove(astronaut);
            context.SaveChanges();
            Console.WriteLine("Successfully removed\n");
        }
    }
}