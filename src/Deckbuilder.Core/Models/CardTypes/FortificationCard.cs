using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.CardTypes
{
	public class FortificationCard : Card
	{
		public FortificationCard(
			int id,
			string name,
			string code,
			int purchasePrice,
			int defense,
			CardAction boardEffect,
			IEnumerable<Ability>? boardAbilities = null,
			IEnumerable<CardUpgrade>? upgrades = null,
			FactionCode? faction = null,
			IEnumerable<KeywordCode>? keywords = null)
			: base(id, name, code, faction, keywords)
		{
			PurchasePrice = purchasePrice;
			Defense = defense;
			BoardEffect = boardEffect;
			BoardAbilities = boardAbilities?.ToList() ?? new List<Ability>();
			Upgrades = upgrades?.ToList() ?? new List<CardUpgrade>();
		}

		public override CardType Type => CardType.Fortification;

		public override int? PurchasePrice { get; }

		public override CardAction BoardEffect { get; }

		public override List<Ability> BoardAbilities { get; }

		public override int? MonsterPower => null;

		public override CardAction? Bounty => null;

		public override int? Defense { get; }

		public override bool? Permanent => true;

		public override List<CardUpgrade> Upgrades { get; }
	}
}
