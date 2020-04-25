using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deckbuilder.Core.Builders;
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
			CardAction? boardEffect,
			IEnumerable<Ability>? boardAbilities = null,
			IEnumerable<CardUpgrade>? upgrades = null,
			FactionCode? faction = null,
			IEnumerable<KeywordCode>? keywords = null)
			: base(id, name, code, faction, keywords,
				  store: new StoreCardMeta(
					  cost: Resources.Gold(purchasePrice),
					  bounty: null,
					  acquire: true),
				  board: new BoardCardMeta(
					  effect: boardEffect,
					  abilities: boardAbilities,
					  permanent: new PermanentCardMeta(
						  removalCost: Resources.Damage(defense),
						  fortification: true)))
		{
			Upgrades = upgrades?.ToList() ?? new List<CardUpgrade>();
		}

		public override CardType Type => CardType.Fortification;

		public override List<CardUpgrade> Upgrades { get; }
	}
}
