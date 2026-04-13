using C_Activity3.Models;

bool s = true;

while (s)
{
    Console.Write("Welcome to the Spacial Exploration manager\n" +
                  "1 - Astronauts\n" +
                  "6 - Quit\n" +
                  "Please select an option: ");
    int op = int.Parse(Console.ReadLine()!);

    switch (op)
    {
        case 1:
            Console.Write("\nWelcome to the astronauts manager\n" +
                              "1 - Add an Astronaut\n" +
                              "2 - Show all Astronauts\n" +
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
