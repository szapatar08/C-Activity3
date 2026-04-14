using C_Activity3.Models;

bool s = true;

while (s)
{
    Console.Write("Welcome to the Spacial Exploration manager\n" +
                  "1 - Astronauts\n" +
                  "2 - Engineers\n" +
                  "6 - Quit\n" +
                  "Please select an option: ");
    int op = int.Parse(Console.ReadLine()!);

    switch (op)
    {
        case 1:
            Console.Write("\nWelcome to the astronauts manager\n" +
                          "1 - Add an Astronaut\n" +
                          "2 - Show all Astronauts\n" +
                          "3 - Update an Astronaut\n" +
                          "4 - Remove an Astronaut\n" +
                          "Please select an option: ");
            int op2 = int.Parse(Console.ReadLine()!);

            switch (op2)
            {
                case 1:
                    Astronaut.AddAstronaut();
                    break;
                
                case 2:
                    Astronaut.ShowAstronaut();
                    break;
                
                case 3:
                    Astronaut.UpdateAstronaut();
                    break;
                
                case 4:
                    Astronaut.DeleteAstronaut();
                    break;
            }
            break;
        
        case 2:
            Console.Write("\nWelcome to the astronauts manager\n" +
                          "1 - Add an Engineer\n" +
                          "2 - Show all Engineer\n" +
                          "3 - Update an Engineer\n" +
                          "4 - Remove an Engineer\n" +
                          "Please select an option: ");
            int op3 = int.Parse(Console.ReadLine()!);

            switch (op3)
            {
                case 1:
                    Astronaut.AddAstronaut();
                    break;
                
                case 2:
                    Astronaut.ShowAstronaut();
                    break;
                
                case 3:
                    Astronaut.UpdateAstronaut();
                    break;
                
                case 4:
                    Astronaut.DeleteAstronaut();
                    break;
            }
            break;
        
        case 6:
            s = false;
            break;
        
        case >6:
            Console.WriteLine("\nPlease enter a valid option\n");
            break;
        
        case < 1:
            Console.WriteLine("\nPlease enter a valid option\n");
            break;
    }
}
