using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
			IEnumerable<BoardObjectModel>? boardObjects = null)
		{
			Number = number;
			Name = name;
			Hand = hand;
			Deck = deck;
			Discard = discard;
			Hero = hero;
			BoardObjects = boardObjects?.ToList() ?? new List<BoardObjectModel>();
		}

		public int Number { get; }
		public string Name { get; }		
		public HandModel Hand { get; }
		public DeckModel Deck { get; }
		public DiscardModel Discard { get; }
		public BoardObjectModel Hero { get; }
		public List<BoardObjectModel> BoardObjects { get; }
	}
}
