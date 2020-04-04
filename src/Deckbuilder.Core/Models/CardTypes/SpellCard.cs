using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.CardTypes
{
	public class SpellCard : Card
	{
		public SpellCard(
			int id,
			string name,
			string code,
			int purchasePrice,
			CardAction? boardEffect = null,
			List<Ability>? boardAbilities = null,
			List<CardUpgrade>? upgrades = null)
			: base(id, name, code)
		{
			PurchasePrice = purchasePrice;
			BoardEffect = boardEffect;
			BoardAbilities = boardAbilities ?? new List<Ability>();
			Upgrades = upgrades ?? new List<CardUpgrade>();
		}

		public override CardType Type => CardType.Spell;

		public override int? PurchasePrice { get; }

		public override CardAction? BoardEffect { get; }

		public override List<Ability> BoardAbilities { get; }

		public override int? MonsterPower => null;

		public override CardAction? Bounty => null;

		public override int? Defense => null;

		public override bool? Permanent => false;

		public override List<CardUpgrade> Upgrades { get; }
	}
}
