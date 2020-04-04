using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.CardTypes
{
	public class HeroCard : Card
	{
		public HeroCard(
			int id,
			string name,
			string code,
			CardAction? boardEffect,
			List<Ability>? boardAbilities)
			: base(id, name, code)
		{
			BoardEffect = boardEffect;
			BoardAbilities = boardAbilities;
		}

		public override CardType Type => CardType.Hero;

		public override int? PurchasePrice => null;

		public override CardAction? BoardEffect { get; }

		public override List<Ability>? BoardAbilities { get; }

		public override int? MonsterPower => null;

		public override CardAction? Bounty => null;

		public override int? Defense => null;

		public override bool? Permanent => true;

		public override List<CardUpgrade> Upgrades => new List<CardUpgrade>();
	}
}
