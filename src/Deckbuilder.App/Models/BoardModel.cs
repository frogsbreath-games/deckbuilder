using System.Collections.Generic;

namespace Deckbuilder.App.Models
{
	public class BoardModel
	{
		public BoardModel(DeckModel storeDeck, List<BoardObjectModel> storeObjects, List<PlayerModel> players)
		{
			StoreDeck = storeDeck;
			StoreObjects = storeObjects;
			Players = players;
		}

		public DeckModel StoreDeck { get; }
		public List<BoardObjectModel> StoreObjects { get; }
		public List<PlayerModel> Players { get; }
	}
}
