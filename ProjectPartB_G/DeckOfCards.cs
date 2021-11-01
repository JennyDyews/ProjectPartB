using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class DeckOfCards : IDeckOfCards
    {
        #region cards List related
        protected const int MaxNrOfCards = 52;
        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards);

        public PlayingCard this[int idx] => null;
        public int Count => cards.Count;
        #endregion

        #region ToString() related
        public override string ToString()
        {
            String retVal = "";
            for (int i= 0; i < Count; i++ )
            {
                retVal = retVal + cards[i].ToString();
                if ((i+1) % 13 == 0)
                    retVal = retVal + "\n";
            }
            return retVal;
        }
        #endregion

        #region Shuffle and Sorting
        public void Shuffle()
        {
            Random r = new Random();
            for (int n = Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                PlayingCard temp = cards[n];
                cards[n] = cards[k];
                cards[k] = temp;
            }
        }
        public void Sort()
        {
            bool itemMoved = false;
            do
            {
                itemMoved = false;
                for (int i = 0; i < Count - 1; i++)
                {
                    //if (input[i] > input[i + 1])
                    if (cards[i].CompareTo(cards[i + 1]) == 1)
                    {
                        PlayingCard lowerValue = cards[i + 1];
                        cards[i + 1] = cards[i];
                        cards[i] = lowerValue;
                        itemMoved = true;
                    }
                }
            } while (itemMoved);
        }
        #endregion

        #region Creating a fresh Deck
        public virtual void Clear()
        {
            cards.Clear();
        }
        public void CreateFreshDeck()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j < 15; j++)
                {
                    PlayingCard card = new PlayingCard {Color = (PlayingCardColor)i, Value = (PlayingCardValue)j};
                    cards.Add(card);           
                }

            }
        }
        #endregion
        #region Dealing
        public PlayingCard RemoveTopCard()
        {
            PlayingCard temp1 = cards[^1];
            cards = cards.Take(cards.Count() - 1).ToList();
            return temp1;
            // return null;
        }
        #endregion
    }
}
