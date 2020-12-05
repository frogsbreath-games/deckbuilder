using System.Collections.Generic;

namespace Deckbuilder.App.Models
{
	public interface ICardSet
	{
		string Name { get; }
		bool Visible { get; }
		int Count { get; }
		List<CardModel> Cards { get; }

		void Add(CardModel card);
	}
}
