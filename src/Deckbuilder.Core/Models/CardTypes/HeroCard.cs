using System.Collections.Generic;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.CardTypes
{
	public class HeroCard : Card
	{
		public HeroCard(
			int id,
			string name,
			string code,
			FactionCode faction,
			CardAction? boardEffect,
			IEnumerable<Ability>? boardAbilities,
			IEnumerable<KeywordCode>? keywords = null)
			: base(id, name, code, faction, keywords,
				  store: null,
				  board: new BoardCardMeta(
					  effect: boardEffect,
					  abilities: boardAbilities,
					  permanent: new PermanentCardMeta(
						  removalCost: null,
						  fortification: false)))
		{
		}

		public override CardType Type => CardType.Hero;

		public override List<CardUpgrade> Upgrades => new List<CardUpgrade>();
	}
}
