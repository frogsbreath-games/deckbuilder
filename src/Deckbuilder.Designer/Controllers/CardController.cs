using System;
using System.Collections.Generic;
using System.Linq;
using Deckbuilder.Core.Builders;
using Deckbuilder.Core.Enums;
using Deckbuilder.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Deckbuilder.Designer.Controllers
{
	[ApiController]
	[Route("api/cards")]
	public class CardController : ControllerBase
	{
		private readonly ILogger<CardController> _logger;

		public CardController(ILogger<CardController> logger)
		{
			_logger = logger;
		}

		[HttpGet("{id}")]
		public Card? GetCardById(int id)
		{
			return GetAllCards()
				.SingleOrDefault(c => c.Id == id);
		}

		[HttpGet]
		public IEnumerable<Card> Get(
			FactionCode? faction = null,
			KeywordCode? keyword = null,
			CardType? cardType = null)
		{
			IEnumerable<Card> ret = GetAllCards();

			if (faction is FactionCode f)
				ret = ret.Where(c => c.Faction == f);

			if (keyword is KeywordCode kw)
				ret = ret.Where(c => c.Keywords.Contains(kw));

			if (cardType is CardType ct)
				ret = ret.Where(c => c.Type == ct);

			return ret;
		}

		protected List<Card> GetAllCards()
		{
			var ret = new List<Card>();

			int id = 0;

			ret.Add(Cards.Spell(
				id: id++,
				name: "Fireball",
				price: 2,
				effect: Actions.GainDamage(3)));

			ret.Add(Cards.Spell(
				id: id++,
				name: "Gain Some Stuff",
				price: 3,
				effect: Actions.Gain(Resources.Damage(2) + Resources.Gold(2))));

			ret.Add(Cards.Spell(
				id: id++,
				name: "Warlock",
				faction: FactionCode.River,
				price: 3,
				effect: Actions.GainGold(2) & Actions.Draw(1),
				keywords: new[]
				{
					KeywordCode.Soldier,
					KeywordCode.Wizard
				}));

			ret.Add(Cards.Hero(
				id: id++,
				name: "Greg The Hero",
				faction: FactionCode.Mountain,
				effect: Actions.Draw(1)
					& Actions.Conditional(
						@if: Conditions.FactionCount(FactionCode.Mountain, 2),
						then: Actions.GainDamage(1)),
				abilities: new[]
				{
					Abilities.OncePerTurn(
						pay: Resources.Glory(2),
						then: Actions.GainGold(3)),
					Abilities.OncePerTurn(
						pay: Resources.Glory(10),
						then: Actions.DrawUpTo(10))
				}));

			ret.Add(Cards.Monster(
				id: id++,
				name: "Rat",
				power: 2,
				bounty: Actions.GainGlory(1),
				keywords: new[] { KeywordCode.Vermin }));

			ret.Add(Cards.Spell(
				id: id++,
				name: "Fighter",
				faction: FactionCode.Sea,
				price: 2,
				effect: Actions.GainDamage(1) & Actions.Draw(1),
				keywords: new[]
				{
					KeywordCode.Soldier
				}));

			ret.Add(Cards.Monster(
				id: id++,
				name: "Viper",
				power: 3,
				bounty: Actions.GainGlory(3) & Actions.LoseHealth(1)));

			ret.Add(Cards.Spell(
				id: id++,
				name: "Coin Purse",
				faction: FactionCode.Jungle,
				price: 2,
				effect: Actions.GainGold(3)));

			ret.Add(Cards.Monster(
				id: id++,
				name: "Lucky Dragon",
				power: 8,
				bounty: Actions.GainGlory(6) & Actions.Draw(2)));

			ret.Add(Cards.Spell(
				id: id++,
				name: "Common Mercenary",
				price: 2,
				effect: Actions.GainDamage(1),
				abilities: new[]
				{
					Abilities.OncePerTurn(
						pay: Resources.Gold(4),
						then: Actions.GainDamage(3))
				}));

			ret.Add(Cards.Hero(
				id: id++,
				name: "Desert Hero",
				faction: FactionCode.Desert,
				effect: Actions.GainDamage(2)
					& Actions.Conditional(
						@if: Conditions.FactionCount(FactionCode.Desert, 2),
						then: Actions.Draw(1)),
				abilities: new[]
				{
					Abilities.OncePerTurn(
						pay: Resources.Glory(2),
						then: Actions.GainDamage(3)),
					Abilities.OncePerTurn(
						pay: Resources.Glory(10),
						then: Actions.GainDamage(20))
				}));

			return ret;
		}
	}
}
