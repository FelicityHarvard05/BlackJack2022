using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCommandLine
{
    class Rules
    {
        public void WriteRules()
        {
            Game game = new Game();
            Rules rules = new Rules();

            Console.WriteLine("-------------------------------------------\n");

            Console.WriteLine("  _______ _            _____       _           ");
            Console.WriteLine(" |__   __| |          |  __ \\     | |          ");
            Console.WriteLine("    | |  | |__   ___  | |__) |   _| | ___  ___ ");
            Console.WriteLine("    | |  | '_ \\ / _ \\ |  _  / | | | |/ _ \\/ __|");
            Console.WriteLine("    | |  | | | |  __/ | | \\ \\ |_| | |  __/\\__ \\");
            Console.WriteLine("    |_|  |_| |_|\\___| |_|  \\_\\__,_|_|\\___||___/");

            Console.WriteLine("-------------------------------------------\n");

            Console.WriteLine("Players take turns drawing cards trying to get as \nclose to 21 as possible with out going over \nand before the dealer can get 21 themselves. Both \nthe dealer and players will recive 2 cards to start \nthe game(The dealer will only have on card visable),\n then the players can take turns either taking a \nanother card, 'Hit', or passing. The game ends either when \nsomeone gets Blackjack(21) or someone busts(goes over 21");
            Console.WriteLine("");

            
            rules.options();
        }

        public void options()
        {
            Console.WriteLine("What would you like to do:");
            Console.WriteLine("\ta - See more instructions");
            Console.WriteLine("\ts - Go to Home Screen");
            Console.WriteLine("\td - Play Game");

            Game game = new Game();
            Rules rules = new Rules();
            switch (Console.ReadLine())
            {
                case "a":
                    rules.MoreInstructions();
                    break;
                case "s":
                    game.HomePage();
                    break;
                case "d":
                    BlackJackCommandLine.PlayGame playgame = new BlackJackCommandLine.PlayGame();
                    playgame.Run();
                    break;
                default:
                    Console.WriteLine("Please select a valid key...");
                    rules.options();
                    break;
            }
        }   

        public void MoreInstructions()
        {
            Console.WriteLine("-------------------------------------------\n");
            Console.WriteLine("What would you like to here more about?");

            Console.WriteLine("\ta - Card Values/Scoring");
            Console.WriteLine("\ts - Dealers Rules");
            Console.WriteLine("\td - Go Back");

            Rules rules = new Rules();
            switch (Console.ReadLine())
            {
                case "a":                   
                    Console.WriteLine("-------------------------------------------\n");
                    Console.WriteLine("~~~~~~       Card Values/Scoring     ~~~~~~");
                    Console.WriteLine("BalckJack is played with a standared 52 card deck.\nThe deck contains 4 suits (Hearts, Clubs, Spaids,\nand Diamonds) and each suit has 13 cards. There\nare also 9 `pip` cards (2,3,4,5,6,7,8,9,10) and four\n face cards (Jack, Queen, King, Ace). All the 'pip'\ncards count for the number on their card,\nthe normal face cards(Jack, Queen, Kind) count\n for 10 points each, and the Ace can be\ncounted as a 1 or a 11. ");
                    Console.WriteLine("");
                    MoreInstructions();
                    break;
                case "s":
                    Console.WriteLine("-------------------------------------------\n");
                    Console.WriteLine("~~~~~~           Dealers Rules         ~~~~~~");
                    Console.WriteLine("When the dealer has served every player, the dealers\nface-down card is turned up.If the total is\n17 or more, it must stand. If the total\nis 16 or under, they must take a card.\nThe dealer must continue to take cards until\nthe total is 17 or more, at which point\nthe dealer must stand. If the dealer has\nan ace, and counting it as 11 would bring\nthe total to 17 or more (but not\nover 21), the dealer must count the ace as\n11 and stand.");
                    Console.WriteLine("");
                    MoreInstructions();
                    break;
                case "d":
                    WriteRules();
                    break;
                default:
                    Console.WriteLine("Please select a valid key...");
                    rules.MoreInstructions();
                    break;
            }
        }
    }
}
