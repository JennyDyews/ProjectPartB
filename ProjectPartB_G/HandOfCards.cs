using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    
    class HandOfCards : DeckOfCards, IHandOfCards
    {
        List<PlayingCard> hand = new List<PlayingCard>();
        #region Pick and Add related
        public void Add(PlayingCard card)
        {
            hand.Add(card);
        }
        #endregion

        public new void Sort()
        {
            bool itemMoved = false;
            do
            {
                itemMoved = false;
                for (int i = 0; i < Count - 1; i++)
                {
                    //if (input[i] > input[i + 1])
                    if (hand[i].CompareTo(hand[i + 1]) == 1)
                    {
                        PlayingCard lowerValue = hand[i + 1];
                        hand[i + 1] = hand[i];
                        hand[i] = lowerValue;
                        itemMoved = true;
                    }
                }
            } while (itemMoved);
        }
        public override void Clear()
        {
            hand.Clear();
        }

        #region Highest Card related
        public PlayingCard Highest
        {
            get
            {
                hand.Sort();
                PlayingCard highest = hand.Last();
                return highest;
            }
         }
        public PlayingCard Lowest
        {
            get
            {
                hand.Sort();
                PlayingCard lowest = hand.First();
                return lowest;
            }
        }
        public override string ToString()
        {
            string sRet = ""; for (int i = 0; i < hand.Count; i++)
            { sRet += $"{hand[i]}"; }
            return sRet;
        }

        #endregion
    }
}
