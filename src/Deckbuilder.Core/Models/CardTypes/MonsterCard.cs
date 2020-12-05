using System.Collections.Generic;
using Deckbuilder.Core.Builders;
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
			CardAction bounty,
			IEnumerable<KeywordCode>? keywords = null)
			: base(id, name, code, null, keywords,
				  store: new StoreCardMeta(
					  cost: Resources.Damage(monsterPower),
					  bounty: bounty,
					  acquire: false),
				  board: null)
		{
		}

		public override CardType Type => CardType.Monster;

		public override List<CardUpgrade>? Upgrades => null;
	}
}
