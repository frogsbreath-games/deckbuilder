using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deckbuilder.App.Models
{
	public class BoardObjectModel
	{
		public BoardObjectModel(
			CardModel card,
			string status,
			Dictionary<string, int>? counters = null)
		{
			Card = card;
			Status = status;
			Counters = counters ?? new Dictionary<string, int>();
		}

		public CardModel Card { get; }
		public string Status { get; }
		public Dictionary<string, int> Counters { get; }
	}
}
