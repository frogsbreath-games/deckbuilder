using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
