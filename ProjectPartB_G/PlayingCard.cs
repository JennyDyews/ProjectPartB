using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
	public class PlayingCard:IComparable<PlayingCard>, IPlayingCard
	{
		public PlayingCardColor Color { get; init; }
		public PlayingCardValue Value { get; init; }

		#region IComparable Implementation
		//Need only to compare value in the project
		public int CompareTo(PlayingCard card1) // return 1 if other card is larger
        {
			if (Value > card1.Value)
				return 1;
			else if (Value == card1.Value)
				return 0;
			else
				return -1;
        }
		#endregion

        #region ToString() related
		string ShortDescription
		{
			//Use switch statment or switch expression //return "Short Description of the card";
			//https://en.wikipedia.org/wiki/Playing_cards_in_Unicode
			get
			{
				char c = Color switch
				{
					PlayingCardColor.Clubs => '\u2663',
					PlayingCardColor.Spades => '\u2660',
					PlayingCardColor.Hearts => '\u2665',
					PlayingCardColor.Diamonds => '\u2666'
				};
				return $"{c} {Value.ToString(),-7}";
					
			}
		}

		public override string ToString() => ShortDescription;
        #endregion
    }
}
