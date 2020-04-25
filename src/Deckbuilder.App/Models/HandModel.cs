using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deckbuilder.App.Models
{
	public class HandModel : ICardSet
	{
		public HandModel(string name, params CardModel[] cards)
			: this(name, cards.AsEnumerable()) { }

		public HandModel(string name, IEnumerable<CardModel> cards)
		{
			Name = name;
			Cards = cards.ToList();
		}

		public string Name { get; }

		public List<CardModel> Cards { get; }

		public bool Visible => true;

		public int Count => Cards.Count;

		public void Add(CardModel card)
		{
			Cards.Add(card);
		}
	}
}
