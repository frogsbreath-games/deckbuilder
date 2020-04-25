using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deckbuilder.App.Models
{
	public class CardModel
	{
		public CardModel(int number)
		{
			Number = number;
		}

		public int Number { get; }
	}
}
