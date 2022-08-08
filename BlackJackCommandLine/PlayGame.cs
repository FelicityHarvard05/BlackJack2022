using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJackCommandLine;


namespace BlackJackCommandLine
{
    class PlayGame
    {
        public List<DeckEnums> deck { get; set; } = new(); //Creates blank deck
        private static Random rng = new();
        public List<DeckEnums> PlayersHand = new(); // Creates blank player hand
        public List<DeckEnums> DealersHand = new(); // Creates blank dealer hand

        public void Run()
        {
           
            DeckAction deckAction = new DeckAction();

            int pAcelocation = 99;

            deckAction.MakeBaseDeck(deck); // fills deck
            deck = deckAction.ShuffleDeck(deck); // shuffles deck 

            deckAction.AddCard(deck, PlayersHand); // creats starting hand for dealer 
            deckAction.AddCard(deck, PlayersHand);

            deckAction.AddCard(deck, DealersHand); // creates starting hand for player 
            deckAction.AddCard(deck, DealersHand);

            intro(deck,PlayersHand,DealersHand, pAcelocation);
        }

        public void intro(List<DeckEnums> deck, List<DeckEnums> playerhand, List<DeckEnums> dealerhand,int pAcelocation)
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("  ___ _              ___                ");
            Console.WriteLine(" | _ \\ |__ _ _  _   / __|__ _ _ __  ___ ");
            Console.WriteLine(" |  _/ / _` | || | | (_ / _` | '  \\/ -_)");
            Console.WriteLine(" |_| |_\\__,_|\\_, |  \\___\\__,_|_|_|_\\___|");
            Console.WriteLine("             |__/                       ");
            Console.WriteLine("-------------------------------------------\n");

            DeckAction deckAction = new();
            PlayGame playGame = new();
            Calulations cal = new();

            Console.WriteLine("Here are the dealers cards:");
            Console.WriteLine();
            foreach (var card in dealerhand)
            {
                if (dealerhand.IndexOf(card) != 0)
                {
                    Console.WriteLine(card.Values + " of " + card.Suits);                  
                }
                else
                {
                    Console.WriteLine("??? of ???");
                }
            }

            Console.WriteLine("\n");
            Console.WriteLine("Here are yours cards:\n");

            foreach (var card in playerhand)
            {
                Console.WriteLine(card.Values + " of " + card.Suits);
                
            }
          
            Console.WriteLine("");

            //Checking for aces in the starting hands
            bool playersAce = deckAction.CheckForAce(playerhand);
            var playerAceDec = 0;
            int flag = 0;

            if (playersAce && pAcelocation == 99) // lets ace action happen if there is an ace and if the decsion on the ace hasnt already been made (default 99)
            {
                var playNumAce = deckAction.getAmountofAce(playerhand);

                if (playNumAce == 2) //that means the player was dealt 2 aces for there starting hand
                {
                    flag = 1; //sends a flag signal telling the playeracechoices there are two aces, sending number 1
                    int choice1 = playerAceChoices(playerhand, playerAceDec, flag);               
                    flag = 2; //sends a flag signal telling the playeracechoices there are two aces, sending number 1
                    int choice2 = playerAceChoices(playerhand, playerAceDec, flag);
                    playerAceDec = choice1 + choice2;
                    pAcelocation = 22; // code for 2 ace in player hand
                   
                    Console.WriteLine("Your total with the Aces are: " + pAcelocation);
                    Console.WriteLine(" ");
                }
                if (playerAceDec == 0)// player only has one ace
                {
                    pAcelocation = deckAction.getLocationofAce(playerhand);
                    int playTotalValNoAce = deckAction.GetTotalWithoutAce(playerhand);
                    playerAceDec = playerAceChoices(playerhand, playerAceDec, flag);              
                    int ptotal = playTotalValNoAce + playerAceDec;
                    Console.WriteLine("Your total with the Ace is: " + ptotal);
                    Console.WriteLine(" ");
                }                           
                
            }
            if(playersAce == true && pAcelocation == 99)
            {
                int playTotalValNoAce = deckAction.GetTotalWithoutAce(playerhand);
                int ptotal = playTotalValNoAce + playerAceDec;
                Console.WriteLine("Your total is: " + pAcelocation);
            }
            if(playersAce == false)
            {
                int playertotal = deckAction.GettotalOfHand(playerhand);
                Console.WriteLine("Your total is: " + playertotal);
            }

            playGame.options(deck, playerhand, dealerhand, playerAceDec, pAcelocation, flag);
        }

        public int playerAceChoices(List<DeckEnums> playerhand, int playerAceDec,int flag)
        {
            DeckAction deckAction = new();
            PlayGame playGame = new();

            
            if(flag == 0) //normal hand
            {
                int playTotalValNoAce = deckAction.GetTotalWithoutAce(playerhand);
                Console.WriteLine("Your total without the Ace is:" + playTotalValNoAce);
                Console.WriteLine("You have an Ace which value would you like it to be?");
                Console.WriteLine("\ta - 1");
                Console.WriteLine("\ts - 11");
            }
            if(flag == 1) //player has 2 aces in starting hand getting the value of first ace
            {
                Console.WriteLine("You have two Aces in your hand, which value would you like the first one it to be?");
                Console.WriteLine("\ta - 1");
                Console.WriteLine("\ts - 11");
            }
            if(flag == 2) //player has 2 aces in starting hand getting the value of first ace
            {
                Console.WriteLine("You have two Aces in your hand, which value would you like the secound one it to be?");
                Console.WriteLine("\ta - 1");
                Console.WriteLine("\ts - 11");
            }
            if (flag == 3) // player got a new card and it was an ace 
            {
                Console.WriteLine("Your new card was an Ace, which value would you like it to be?");
                Console.WriteLine("\ta - 1");
                Console.WriteLine("\ts - 11");
            }

                switch (Console.ReadLine())
            {
                case "a":
                    playerAceDec = 1;                    
                    break;
                case "s":
                    playerAceDec = 11;                  
                    break;
                default:
                    Console.WriteLine("Please select a valid key...");
                    playGame.playerAceChoices(playerhand, playerAceDec, flag);
                    break;
            }
            return playerAceDec;
        }

        public void options(List<DeckEnums> deck, List<DeckEnums> playerhand, List<DeckEnums> dealerhand, int playerAceDec, int pAcelocation,int flag)
        {
            Calulations cal = new();
            PlayGame playGame = new();

            Console.WriteLine("What would you like to do:");
            Console.WriteLine("\ta - Hit");
            Console.WriteLine("\ts - Pass");
            Console.WriteLine("\tw - Exit");

            switch (Console.ReadLine())
            {
                case "a":
                    cal.calRound(true, deck, playerhand, dealerhand, playerAceDec, pAcelocation, flag);
                    break;
                case "s":
                    cal.calRound(false, deck, playerhand, dealerhand, playerAceDec, pAcelocation,flag);                  
                    break;
                case "w":
                    Console.WriteLine("Good luck out there...");
                    break;
                default:
                    Console.WriteLine("Please select a valid key...");
                    playGame.options(deck, playerhand, dealerhand, playerAceDec, pAcelocation,flag);
                    break;
            }
        }
    }



    public class DeckAction
    {

        public List<DeckEnums> MakeBaseDeck(List<DeckEnums> baseDeck)  //Creats the standerd 52 card deck
        {
            for (int i = 0; i < Enum.GetValues(typeof(CardSuits)).Length; i++)
            {
                for (int j = 0; j < Enum.GetValues(typeof(CardsNorm)).Length; j++)
                {
                    var deckEnums = new DeckEnums((CardSuits)i, (CardsNorm)j);
                    baseDeck.Add(deckEnums);
                }
            }
            return (baseDeck);
        }

        public List<DeckEnums> ShuffleDeck(List<DeckEnums> baseDeck) //Shuffles Deck
        {
            Random rng = new();
            var shuffledDeck = baseDeck.OrderBy(a => rng.Next()).ToList();
            return (shuffledDeck);
        }

        public List<DeckEnums> AddCard(List<DeckEnums> shuffledDeck, List<DeckEnums> hand) //Adds a card from deck to hand
        {
            hand.Add(shuffledDeck.First()); // adds card to hand
            var test2 = shuffledDeck.Remove(shuffledDeck.First()); //removes said card to hand
            return (hand);
        }
        public int ConvertCardToValue(DeckEnums card) //converts enum card value to an int 
        {
            int cardValue = 0;


            if ((int)(card.Values) == 0)
            {
                cardValue = 2;
            }
            if ((int)(card.Values) == 1)
            {
                cardValue = 3;
            }
            if ((int)(card.Values) == 2)
            {
                cardValue = 4;
            }
            if ((int)(card.Values) == 3)
            {
                cardValue = 5;
            }
            if ((int)(card.Values) == 4)
            {
                cardValue = 6;
            }
            if ((int)(card.Values) == 5)
            {
                cardValue = 7;
            }
            if ((int)(card.Values) == 6)
            {
                cardValue = 8;
            }
            if ((int)(card.Values) == 7)
            {
                cardValue = 9;
            }
            if ((int)(card.Values) == 8)
            {
                cardValue = 10;
            }
            if ((int)(card.Values) == 9)
            {
                cardValue = 10;
            }
            if ((int)(card.Values) == 10)
            {
                cardValue = 10;
            }
            if ((int)(card.Values) == 11)
            {
                cardValue = 10;
            }
            if ((int)(card.Values) == 12)
            {
                cardValue = 1;
            }
            return cardValue;

        }

        public int GettotalOfHand(List<DeckEnums> hand)
        {
            DeckAction deckAction = new();
            int totalCardValues = 0;
            foreach (var item in hand)
            {
                int value = deckAction.ConvertCardToValue(item);
                totalCardValues += value;
            }

            return totalCardValues;
        }

        public bool CheckForAce(List<DeckEnums> hand) //checks for an ace in hand
        {
            bool hasAce = false;
            foreach (var item in hand)
            {
                if ((int)(item.Values) == 12)
                {
                    hasAce = true; ;
                }
            }

            return hasAce;
        }

        public List<DeckEnums> handwithoutAce { get; set; } = new();
        public int GetTotalWithoutAce(List<DeckEnums> hand) //gets total score from hand without the ace
        {
            DeckAction deckAction = new();
            int totalBeforeAce = 0;
            foreach (var item in hand)
            {          
                if ((int)(item.Values) != 12)
                {
                    handwithoutAce.Add(item);                  
                }
            }
            totalBeforeAce = deckAction.GettotalOfHand(handwithoutAce);
            return totalBeforeAce;
        }

        public int dealerHasAceAction(List<DeckEnums> hand,int dealerTotalbeforeAce, int dtotalcardValues, int numDealerHand)
        {
            int amount = 0;
            amount = getAmountofAce(hand);
            if (amount == 1)
            {               
                if (dealerTotalbeforeAce + 11 <= 21)
                {
                    dtotalcardValues = dealerTotalbeforeAce + 11; // adds 11 to total if possible                
                }
                if (dealerTotalbeforeAce + 11 > 21)
                {
                    dtotalcardValues = dealerTotalbeforeAce + 1; // adds 1 to the total if 11 isnt possible
                }              
                return dtotalcardValues;
            }
            
            if (amount > 1) // deals with the ace if there are multiple aces in the hand
            {
               
                foreach (var item in hand)
                {
                    if ((int)(item.Values) == 12)
                    {
                        if (dealerTotalbeforeAce + 11 <= 21)
                        {
                            dtotalcardValues = dealerTotalbeforeAce + 11;
                        }
                        dtotalcardValues += 1;
                    }
                }
                
                return dtotalcardValues;
            }
            return dtotalcardValues; 
        }

        public int getLocationofAce(List<DeckEnums> hand)
        {
            int location = 99;
            while (location == 99)
            {
                foreach (var item in hand)
                {
                    if ((int)(item.Values) == 12)
                    {
                        location = hand.IndexOf(item);
                        break;
                    }
                }
            }
            return (location);
        }

        public int getAmountofAce(List<DeckEnums> hand)
        {
            int howManyAce = 0;
            foreach (var item in hand)
            {
                if ((int)(item.Values) == 12)
                {
                    howManyAce++;
                }
            }
            return (howManyAce);
        }

    }
}

