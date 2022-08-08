using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCommandLine
{
    class Results
    {
        public void TheResults(int results, List<DeckEnums> playerhand, List<DeckEnums> dealerhand,int ptotalcardValues, int dtotalcardValues)
        {
            Game game = new Game();
            BlackJackCommandLine.DeckAction deckAction = new();

            Console.WriteLine("\n\n");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("  ___             _ _      ");
            Console.WriteLine(" | _ \\___ ____  _| | |_ ___");
            Console.WriteLine(" |   / -_|_-< || | |  _(_-<");
            Console.WriteLine(" |_|_\\___/__/\\_,_|_|\\__/__/");
            Console.WriteLine("-------------------------------------------");
            if (results == 1) // Player got BlackJack
            {
                Console.WriteLine("You got BlackJack! Lucky you.");
            }
            if (results == 2) //Dealer got BlackJack
            {
                Console.WriteLine("Oh no, The Dealer got BlackJack! You must be unlucky.....");
            }
            if (results == 3) // Dealer busted
            {
                Console.WriteLine("Yikes, look like the dealer busted and you won! Good job staying under 21.");
            }
            if (results == 4) // Player busted
            {
                Console.WriteLine("Oops, you busted! Make sure to stay under 21 next time..");
            }
            if (results == 5) // Dealer had # closest to 21
            {

                Console.WriteLine("You lost! No one busted but the dealer had the closet number to 21");
            }
            if (results == 6) // Player had # closest to 21
            {
                Console.WriteLine("You won! No one busted but you had the closet number to 21");
            }
            if (results == 7) //Draw
            {

                Console.WriteLine("There was a draw...you and the dealer had the same score that was under or equal to 21.");
            }
            if (results == 8) //Player got 21
            {

                Console.WriteLine("You got 21! The dealer was unable to get to 21 before you.");
            }
            if (results == 9) //Dealer got 21
            {

                Console.WriteLine("Oh no, The Dealer got to 21! You were unable to get to 21 before the dealer.");
            }

            Console.WriteLine("Here are the dealers cards:");
            Console.WriteLine();
            foreach (var card in dealerhand)
            {
                Console.WriteLine(card.Values + " of " + card.Suits);

            }

            
            Console.WriteLine("The dealers total was: " + dtotalcardValues);
            Console.WriteLine("------------------------\n");
            Console.WriteLine("Here are yours cards:\n");

            foreach (var card in playerhand)
            {
                Console.WriteLine(card.Values + " of " + card.Suits);
            }
            Console.WriteLine("");
            Console.WriteLine("The players total was: " + ptotalcardValues);

            options();
        }

        public void options()
        {
            Game game = new Game();
            Results results = new();

            Console.WriteLine("What would you like to do:");
            Console.WriteLine("\ts - Go to Home Screen");
            Console.WriteLine("\ta - Play Again");
            Console.WriteLine("\td - Check out the Rules");
            Console.WriteLine("\tw - Exit");


            switch (Console.ReadLine())
            {
                case "s":
                    game.HomePage();
                    break;
                case "a":
                    BlackJackCommandLine.PlayGame playgame = new BlackJackCommandLine.PlayGame();
                    playgame.Run();
                    break;
                case "d":
                    BlackJackCommandLine.Rules rules = new();
                    rules.WriteRules();
                    break;
                case "w":
                    Console.WriteLine("Thanks for playing! I hope you enjoyed it C:");
                    break;
                default:
                    Console.WriteLine("Please select a valid key...");
                    results.options();
                    break;
            }

        }
    }
}
