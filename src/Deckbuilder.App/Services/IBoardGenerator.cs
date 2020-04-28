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

			var player1 = new PlayerModel(
				number: 1,
				name: "Player 1",
				hand: new HandModel(
					name: "Player 1 Hand",
					cards: storeDeck.DrawMany(random.Next(3, 8))),
				deck: new DeckModel(
					name: "Player 1 Deck",
					cards: storeDeck.DrawMany(random.Next(1, 20))),
				discard: new DiscardModel(
					name: "Player 1 Discard",
					cards: storeDeck.DrawMany(random.Next(1, 20))),
				hero: new BoardObjectModel(storeDeck.Draw()!, "active"),
				boardObjects: storeDeck.DrawMany(random.Next(1, 8))
					.Select(card => new BoardObjectModel(card, "active")));

			var player2 = new PlayerModel(
				number: 2,
				name: "Player 2",
				hand: new HandModel(
					name: "Player 2 Hand",
					cards: storeDeck.DrawMany(random.Next(3, 8))),
				deck: new DeckModel(
					name: "Player 2 Deck",
					cards: storeDeck.DrawMany(random.Next(1, 20))),
				discard: new DiscardModel(
					name: "Player 2 Discard",
					cards: storeDeck.DrawMany(random.Next(1, 20))),
				hero: new BoardObjectModel(storeDeck.Draw()!, "active"),
				boardObjects: storeDeck.DrawMany(random.Next(1, 8))
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
