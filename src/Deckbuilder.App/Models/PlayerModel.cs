using System.Collections.Generic;
using System.Linq;

namespace Deckbuilder.App.Models
{
	public class PlayerModel
	{
		public PlayerModel(
			int number,
			string name,
			HandModel hand,
			DeckModel deck,
			DiscardModel discard,
			BoardObjectModel hero,
			IEnumerable<BoardObjectModel>? boardObjects = null,
			Dictionary<string, int>? counters = null)
		{
			Number = number;
			Name = name;
			Hand = hand;
			Deck = deck;
			Discard = discard;
			Hero = hero;
			BoardObjects = boardObjects?.ToList() ?? new List<BoardObjectModel>();
			Counters = counters ?? new Dictionary<string, int>();
		}

		public int Number { get; }
		public string Name { get; }
		public HandModel Hand { get; }
		public DeckModel Deck { get; }
		public DiscardModel Discard { get; }
		public BoardObjectModel Hero { get; }
		public List<BoardObjectModel> BoardObjects { get; }
		public Dictionary<string, int> Counters { get; }
	}
}
