using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Enums;
using Deckbuilder.Core.Models;
using Deckbuilder.Core.Models.CardTypes;

namespace Deckbuilder.Core.Builders
{
	public static class Cards
	{
		public static SpellCard Spell(
			int id,
			string name,
			int price,
			CardAction? effect = null,
			IEnumerable<Ability>? abilities = null,
			FactionCode? faction = null,
			IEnumerable<KeywordCode>? keywords = null)
		{
			return new SpellCard(
				id,
				name,
				name.Replace(' ', '_').ToLower(),
				price,
				effect,
				abilities,
				faction: faction,
				keywords: keywords);
		}

		public static HeroCard Hero(
			int id,
			string name,
			FactionCode faction,
			CardAction? effect = null,
			IEnumerable<Ability>? abilities = null)
		{
			return new HeroCard(
				id,
				name,
				name.Replace(' ', '_').ToLower(),
				faction,
				effect,
				abilities);
		}

		public static MonsterCard Monster(
			int id,
			string name,
			int power,
			CardAction bounty,
			IEnumerable<KeywordCode>? keywords = null)
		{
			return new MonsterCard(
				id,
				name,
				name.Replace(' ', '_').ToLower(),
				power,
				bounty,
				keywords);
		}
	}
}
