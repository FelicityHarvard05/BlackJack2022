// See https://aka.ms/new-console-template for more information
using BlackJackCommandLine;


Game game = new Game();
game.HomePage();
class Game
{
    
    public void HomePage()
    {

        Console.WriteLine("-------------------------------------------\n");
        Console.WriteLine("        Welcome to the game they call");
        Console.WriteLine(" _     _            _    _            _  ");
        Console.WriteLine("| |   | |          | |  (_)          | |  ");
        Console.WriteLine("| |__ | | __ _  ___| | ___  __ _  ___| | __");
        Console.WriteLine("| '_ \\| |/ _` |/ __| |/ / |/ _` |/ __| |/ /");
        Console.WriteLine("| |_) | | (_| | (__|   <| | (_| | (__|   < ");
        Console.WriteLine("|_.__/|_|\\__,_|\\___|_|\\_\\ |\\__,_|\\___|_|\\_\\");
        Console.WriteLine("                       _/ |                ");
        Console.WriteLine("                      |__/                 ");

        Console.WriteLine("-------------------------------------------\n");

        Console.WriteLine("The main goal of BlackJack is for each player ");
        Console.WriteLine("to beat the dealer by getting a count as close ");
        Console.WriteLine("to 21 as possible, without going over 21 and ");
        Console.WriteLine("before the dealer does. If you like you can ");
        Console.WriteLine("look more closely at the rules below or go\nahead and give the game a try. In any case\nmay the luck be with you...");

        Console.WriteLine("");
        
        Game game = new Game();
        game.options();
    }

    public void options()
    {
      
        Console.WriteLine("What would you like to do:");
        Console.WriteLine("\ta - Play Game");
        Console.WriteLine("\ts - Read the Rules");
        Console.WriteLine("\tw - Exit");
        Console.WriteLine("Press the key associated to what you want to do (For example 'a' to play game) then press enter");
        Game game = new Game();
        switch (Console.ReadLine())
        {
            case "a":
                BlackJackCommandLine.PlayGame playgame = new();
                playgame.Run();
                break;
            case "s":
                BlackJackCommandLine.Rules rules = new();
                rules.WriteRules();
                break;
            case "w":
                Console.WriteLine("Good luck out there...");
                break;
            default:
                Console.WriteLine("Please select a valid key...");
                game.options();
                break;
        }
    }
}
