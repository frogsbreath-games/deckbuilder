using System;
using System.Collections.Generic;
using System.Linq;
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
			IEnumerable<Ability>? boardAbilities = null,
			IEnumerable<CardUpgrade>? upgrades = null,
			FactionCode? faction = null,
			IEnumerable<KeywordCode>? keywords = null)
			: base(id, name, code, faction, keywords)
		{
			PurchasePrice = purchasePrice;
			BoardEffect = boardEffect;
			BoardAbilities = boardAbilities?.ToList() ?? new List<Ability>();
			Upgrades = upgrades?.ToList() ?? new List<CardUpgrade>();
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
