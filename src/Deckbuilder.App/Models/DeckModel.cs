using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deckbuilder.App.Models
{
	public class DeckModel : ICardSet
	{
		public DeckModel(string name, params CardModel[] cards)
			: this(name, cards.AsEnumerable()) { }

		public DeckModel(string name, IEnumerable<CardModel> cards)
		{
			Name = name;
			Cards = cards.ToList();
		}

		public string Name { get; }
		public bool Visible => false;
		public List<CardModel> Cards { get; }
		public int Count => Cards.Count;

		public void Add(CardModel card)
		{
			Cards.Add(card);
		}

		public CardModel? Draw()
		{
			if (Count < 1)
				return null;

			var ret = Cards.ElementAt(0);

			Cards.RemoveAt(0);

			return ret;
		}

		public List<CardModel> DrawMany(int count)
		{
			var ret = new List<CardModel>();

			for(int i = 0; i < count; i++)
			{
				var card = Draw();

				if (card is null)
					break;

				ret.Add(card);
			}

			return ret;
		}
	}
}
