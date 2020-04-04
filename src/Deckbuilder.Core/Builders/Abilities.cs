using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Models;

namespace Deckbuilder.Core.Builders
{
	public static class Abilities
	{
		public static Ability OncePerTurn(ResourceList pay, CardAction then)
			=> new Ability(pay, then, false);

		public static Ability YouMay(ResourceList pay, CardAction then)
			=> new Ability(pay, then, true);

		public static Ability OncePerTurn(CardAction action)
			=> new Ability(null, action, false);

		public static Ability YouMay(CardAction action)
			=> new Ability(null, action, true);
	}
}
