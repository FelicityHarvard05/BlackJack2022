using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCommandLine
{
    public enum CardSuits
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }

    public enum CardsNorm
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace

    }

    public class DeckEnums
    {
        public DeckEnums(CardSuits cardSuits, CardsNorm cardsNorm)
        {
            Suits = cardSuits;
            Values = cardsNorm;
        }
        public CardSuits Suits { get; }
        public CardsNorm Values { get; }


    }
}
