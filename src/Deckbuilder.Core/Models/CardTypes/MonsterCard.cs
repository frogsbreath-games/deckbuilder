using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.CardTypes
{
	public class MonsterCard : Card
	{
		public MonsterCard(
			int id,
			string name,
			string code,
			int monsterPower,
			CardAction bounty)
			: base(id, name, code)
		{
			MonsterPower = monsterPower;
			Bounty = bounty;
		}

		public override CardType Type => CardType.Monster;

		public override int? PurchasePrice => null;

		public override CardAction? BoardEffect => null;

		public override List<Ability>? BoardAbilities => null;

		public override int? MonsterPower { get; }

		public override CardAction? Bounty { get; }

		public override int? Defense => null;

		public override bool? Permanent => null;

		public override List<CardUpgrade>? Upgrades => null;
	}
}
