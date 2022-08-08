using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCommandLine
{
    class Calulations
    {
        public void calRound(bool action, List<DeckEnums> deck, List<DeckEnums> playerhand, List<DeckEnums> dealerhand, int playerAceDec, int pAcelocation, int flag)
        {
            // if the player chose to 'hit' action will = true,if they chose 'pass' action = false

            BlackJackCommandLine.Results results = new(); // create these to acces other files
            BlackJackCommandLine.PlayGame playGame = new();
            BlackJackCommandLine.DeckAction deckAction = new();

            bool pStartHand = true;
            bool dStartHand = true;
            int ptotalcardValues = deckAction.GettotalOfHand(playerhand); // Gets total of dealers starting hand
            int dtotalcardValues = deckAction.GettotalOfHand(dealerhand);// Gets total of players starting hand


            /////here
            if (flag == 2)
            {
                ptotalcardValues = playerAceDec;
            }

            //need to check to see if dealer has an ace in starting hand
            var dealerAce = deckAction.CheckForAce(dealerhand);
            var numDealHand = 0;

            if (dealerAce == true)
            {
                int dtotalbeforAce = deckAction.GetTotalWithoutAce(dealerhand);
                dtotalcardValues = deckAction.dealerHasAceAction(dealerhand, dtotalbeforAce, dtotalcardValues, numDealHand);
                var numDealerHand = deckAction.getAmountofAce(dealerhand);
                if (numDealerHand == 1) { numDealHand = deckAction.getLocationofAce(dealerhand); }
                if (numDealerHand > 1) { numDealHand = 2; }

            }


            //need to hadle if the player has an ace in first hand
            if (playerAceDec != 0 && flag == 0)
            {
                int playTotalValNoAce = deckAction.GetTotalWithoutAce(playerhand);
                ptotalcardValues = playTotalValNoAce + playerAceDec;
                Console.WriteLine("Players card value after ace " + ptotalcardValues); // correct 

            }

            if (action == true)
            {

                deckAction.AddCard(deck, playerhand); //draws player a card if the chose to hit
                if ((int)playerhand[2].Values == 12)
                {
                    var newCardValue = playGame.playerAceChoices(playerhand, playerAceDec, 3);
                    ptotalcardValues = ptotalcardValues + newCardValue;
                    pAcelocation = 2;
                }

                ptotalcardValues = deckAction.ConvertCardToValue(playerhand[2]) + ptotalcardValues; //updates player total
                pStartHand = false;
            }

            Console.WriteLine(pStartHand);
            Console.WriteLine("player total card value is " + ptotalcardValues);

            if (ptotalcardValues == 21 && pStartHand == true) // player got blackjack
            {
                results.TheResults(1, playerhand, dealerhand, ptotalcardValues, dtotalcardValues);
            }
            if (ptotalcardValues > 21) // Player busted
            {
                results.TheResults(4, playerhand, dealerhand, ptotalcardValues, dtotalcardValues);
            }
            if (action == false) // will only draw the dealer a card if the player as passed since the dealer only draw after the player has complpeted there turn
            {
                while (dtotalcardValues < 17)
                {
                    dtotalcardValues = addDealerCardAction(dtotalcardValues, deck, dealerhand, numDealHand);
                }
                dStartHand = false;

            }


            if (ptotalcardValues == 21) // player got 21
            {
                results.TheResults(8, playerhand, dealerhand, ptotalcardValues, dtotalcardValues);
            }

            if (dtotalcardValues == 21 && dStartHand == true) //Dealer got BlackJack
            {
                results.TheResults(9, playerhand, dealerhand, ptotalcardValues, dtotalcardValues);
            }
            if (dtotalcardValues == 21) //Dealer got 21
            {
                results.TheResults(2, playerhand, dealerhand, ptotalcardValues, dtotalcardValues);
            }
            if (dtotalcardValues > 21) // Dealer busted
            {
                results.TheResults(3, playerhand, dealerhand, ptotalcardValues, dtotalcardValues);
            }
            if (dtotalcardValues > ptotalcardValues && action == false)  // Dealer had # closest to 21
            {
                results.TheResults(5, playerhand, dealerhand, ptotalcardValues, dtotalcardValues);
            }
            if (dtotalcardValues < ptotalcardValues && action == false) // Player had # closest to 21
            {
                results.TheResults(6, playerhand, dealerhand, ptotalcardValues, dtotalcardValues);
            }
            if (dtotalcardValues == ptotalcardValues && action == false)//Draw
            {
                results.TheResults(7, playerhand, dealerhand, ptotalcardValues, dtotalcardValues);
            }

            if (ptotalcardValues < 21)
            {
                playGame.intro(deck, playerhand, dealerhand, pAcelocation); // loads game if another card has to be drawn }

            }
        }


        public int addDealerCardAction(int dtotalcardValues, List<DeckEnums> deck, List<DeckEnums> dealerhand, int numDealHand)
        {
            BlackJackCommandLine.DeckAction deckAction = new(); 

            if (dtotalcardValues < 17) // draws the dealer a card if his total is under 17
            {
                
                deckAction.AddCard(deck, dealerhand);
                
                bool dealerHasAce = deckAction.CheckForAce(dealerhand); //checks to see if dealer has ace then does action based on value
                var value = (int)dealerhand[2].Values == 12;           
                var amount = deckAction.getAmountofAce(dealerhand);
                
                if (value == true && amount > 1) // if there hand already has a ace and the new card is an ace
                {
                    dtotalcardValues = dtotalcardValues + 1;               
                    return dtotalcardValues;
                }
                if(amount == 1 && value == true)// if the new card is the only ace 
                {
                    int totalWithout = deckAction.GetTotalWithoutAce(dealerhand);
                    if((totalWithout + 11) > 21)
                    {
                        totalWithout += 1;                    
                        return totalWithout;
                    }
                    if ((totalWithout + 11) <= 21)
                    {
                        totalWithout += 11;
                        return totalWithout;
                    }
                }
                if(amount == 1 && value == false)// if the dealer had a ace in is starting hand but no ace in the new card
                {
                    dtotalcardValues = deckAction.ConvertCardToValue(dealerhand[2]) + dtotalcardValues;
                    return dtotalcardValues;
                }
                if (dealerHasAce != true) // if there are no aces in there hand
                {
                    dtotalcardValues = deckAction.GettotalOfHand(dealerhand);                 
                    return dtotalcardValues;
                }
                
            }

            return dtotalcardValues;
        }
    }
}
