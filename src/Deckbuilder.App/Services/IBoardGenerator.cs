using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deckbuilder.App.Models;
using Deckbuilder.Core.Extensions;

namespace Deckbuilder.App.Services
{
	public interface IBoardGenerator
	{
		BoardModel GenerateBoard();
	}

	public class BoardGenerator : IBoardGenerator
	{
		protected readonly IRandomAccessor _rand;

		public BoardGenerator(IRandomAccessor randomAccessor)
		{
			_rand = randomAccessor;
		}

		public BoardModel GenerateBoard()
		{
			var cards = Enumerable.Range(1, 200)
				.Select(i => new CardModel(i))
				.ToList();

			var random = _rand.Random;
			
			cards.Shuffle(random);

			var storeDeck = new DeckModel("StoreDeck", cards);

			var player1 = new PlayerModel(1, "Player 1",
				new HandModel("Player 1 Hand", storeDeck.DrawMany(random.Next(3, 8))),
				new DeckModel("Player 1 Deck", storeDeck.DrawMany(random.Next(1, 20))),
				new DiscardModel("Player 1 Discard", storeDeck.DrawMany(random.Next(1, 20))),
				storeDeck.DrawMany(random.Next(1, 8)).Select(card => new BoardObjectModel(
					card, "active")));

			var player2 = new PlayerModel(2, "Player 2",
				new HandModel("Player 2 Hand", storeDeck.DrawMany(random.Next(3, 8))),
				new DeckModel("Player 2 Deck", storeDeck.DrawMany(random.Next(1, 20))),
				new DiscardModel("Player 2 Discard", storeDeck.DrawMany(random.Next(1, 20))),
				storeDeck.DrawMany(random.Next(1, 8))
					.Select(card => new BoardObjectModel(card, "active")));

			var storeObjects = storeDeck.DrawMany(5)
				.Select(card => new BoardObjectModel(card, "active"))
				.ToList();

			var board = new BoardModel(
				storeDeck,
				storeObjects,
				new List<PlayerModel>
				{
					player1,
					player2
				});

			return board;
		}
	}
}
