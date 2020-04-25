using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deckbuilder.Core.Builders;
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
			: base(id, name, code, faction, keywords,
				  store: new StoreCardMeta(
					  cost: Resources.Gold(purchasePrice),
					  bounty: null,
					  acquire: true),
				  board: new BoardCardMeta(
					  effect: boardEffect,
					  abilities: boardAbilities,
					  permanent: null))
		{
			Upgrades = upgrades?.ToList() ?? new List<CardUpgrade>();
		}

		public override CardType Type => CardType.Spell;

		public override List<CardUpgrade> Upgrades { get; }
	}
}
