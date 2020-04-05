using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deckbuilder.Core.Builders;
using Deckbuilder.Core.Enums;
using Deckbuilder.Core.Extensions;
using Deckbuilder.Core.Models;
using Deckbuilder.Core.Models.ActionTypes;
using Deckbuilder.Core.Models.CardTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Deckbuilder.Designer.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CardController : ControllerBase
	{
		private readonly ILogger<CardController> _logger;

		public CardController(ILogger<CardController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<Card> Get()
		{
			var ret = new List<Card>();

			ret.Add(Cards.Spell(
				id: 0,
				name: "Fireball",
				price: 2,
				effect: Actions.GainDamage(3)));

			ret.Add(Cards.Spell(
				id: 1,
				name: "Gain Some Stuff",
				price: 3,
				effect: Actions.Gain(Resources.Damage(2) + Resources.Gold(2))));

			ret.Add(Cards.Spell(
				id: 2,
				name: "Warlock",
				faction: FactionCode.River,
				price: 3,
				effect: Actions.Draw(1) & Actions.GainGold(2),
				keywords: new[]
				{
					KeywordCode.Soldier,
					KeywordCode.Wizard
				}));

			ret.Add(Cards.Hero(
				id: 3,
				name: "Greg The Hero",
				faction: FactionCode.Mountain,
				effect: Actions.Draw(1)
					& Actions.Conditional(
						@if: Conditions.FactionCount(FactionCode.Mountain, 2),
						then: Actions.GainDamage(1)),
				abilities: new []
				{
					Abilities.OncePerTurn(
						pay: Resources.Glory(2),
						then: Actions.GainGold(3)),
					Abilities.OncePerTurn(
						pay: Resources.Glory(10),
						then: Actions.DrawUpTo(10))
				}));

			ret.Add(Cards.Monster(
				id: 4,
				name: "Rat",
				power: 2,
				bounty: Actions.GainGlory(1),
				keywords: new[] { KeywordCode.Vermin }));

			ret.Add(Cards.Monster(
				id: 5,
				name: "Viper",
				power: 3,
				bounty: Actions.GainGlory(3) & Actions.LoseHealth(1)));

			return ret;
		}
	}
}
