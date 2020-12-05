using System.Collections.Generic;
using System.Linq;

namespace Deckbuilder.App.Models
{
	public class DiscardModel : ICardSet
	{
		public DiscardModel(string name, params CardModel[] cards)
			: this(name, cards.AsEnumerable()) { }

		public DiscardModel(string name, IEnumerable<CardModel> cards)
		{
			Name = name;
			Cards = cards.ToList();
		}

		public string Name { get; }
		public bool Visible => true;
		public List<CardModel> Cards { get; }
		public int Count => Cards.Count;

		public void Add(CardModel card)
		{
			Cards.Add(card);
		}
	}
}
