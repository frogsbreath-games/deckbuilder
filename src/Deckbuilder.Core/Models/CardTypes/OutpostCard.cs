using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.CardTypes
{
	public class OutpostCard : Card
	{
		public OutpostCard(
			int id,
			string name,
			string code,
			int purchasePrice,
			int defense,
			CardAction boardEffect,
			List<Ability>? boardAbilities = null,
			List<CardUpgrade>? upgrades = null)
			: base(id, name, code)
		{
			PurchasePrice = purchasePrice;
			Defense = defense;
			BoardEffect = boardEffect;
			BoardAbilities = boardAbilities ?? new List<Ability>();
			Upgrades = upgrades ?? new List<CardUpgrade>();
		}

		public override CardType Type => CardType.Outpost;

		public override int? PurchasePrice { get; }

		public override CardAction? BoardEffect { get; }

		public override List<Ability> BoardAbilities { get; }

		public override int? MonsterPower => null;

		public override CardAction? Bounty => null;

		public override int? Defense { get; }

		public override bool? Permanent => true;

		public override List<CardUpgrade> Upgrades { get; }
	}
}
