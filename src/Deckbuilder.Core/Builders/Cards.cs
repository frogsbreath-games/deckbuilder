using System;
using System.Collections.Generic;
using System.Text;
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
			List<Ability>? abilities = null)
		{
			return new SpellCard(
				id,
				name,
				name.Replace(' ', '_').ToLower(),
				price,
				effect,
				abilities);
		}

		public static HeroCard Hero(
			int id,
			string name,
			CardAction? effect = null,
			List<Ability>? abilities = null)
		{
			return new HeroCard(
				id,
				name,
				name.Replace(' ', '_').ToLower(),
				effect,
				abilities);
		}

		public static MonsterCard Monster(
			int id,
			string name,
			int power,
			CardAction bounty)
		{
			return new MonsterCard(
				id,
				name,
				name.Replace(' ', '_').ToLower(),
				power,
				bounty);
		}
	}
}
