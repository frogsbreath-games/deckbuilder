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
				effect: CardActions.GainDamage(3)));

			ret.Add(Cards.Spell(
				id: 1,
				name: "Gain Some Stuff",
				price: 3,
				effect: CardActions.Gain(Resources.Damage(2) + Resources.Gold(2))));

			ret.Add(Cards.Spell(
				id: 2,
				name: "Warlock",
				price: 3,
				effect: CardActions.Draw(1).And(CardActions.GainGold(2))));

			ret.Add(Cards.Hero(
				id: 3,
				name: "Greg The Hero",
				effect: CardActions.Draw(1),
				abilities: new List<Ability>
				{
					Abilities.OncePerTurn(
						pay: Resources.Glory(2),
						then: CardActions.GainGold(3)),
					Abilities.OncePerTurn(
						pay: Resources.Glory(10),
						then: CardActions.Draw(10))
				}));

			ret.Add(Cards.Monster(
				id: 4,
				name: "Rat",
				power: 2,
				bounty: CardActions.GainGlory(1)));

			ret.Add(Cards.Monster(
				id: 5,
				name: "Snake",
				power: 3,
				bounty: CardActions.GainGlory(2)));

			return ret;
		}
	}
}
