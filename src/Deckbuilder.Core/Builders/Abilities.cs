using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Models;

namespace Deckbuilder.Core.Builders
{
	public static class Abilities
	{
		public static Ability OncePerTurn(ResourceList pay, CardAction then)
			=> new Ability(null, pay, then, false);

		public static Ability YouMay(ResourceList pay, CardAction then)
			=> new Ability(null, pay, then, true);

		public static Ability OncePerTurn(CardAction action)
			=> new Ability(null, null, action, false);

		public static Ability YouMay(CardAction action)
			=> new Ability(null, null, action, true);

		public static Ability OncePerTurn(BoardCondition @if, ResourceList pay, CardAction then)
			=> new Ability(@if, pay, then, false);

		public static Ability YouMay(BoardCondition @if, ResourceList pay, CardAction then)
			=> new Ability(@if, pay, then, true);

		public static Ability OncePerTurn(BoardCondition @if, CardAction then)
			=> new Ability(@if, null, then, false);

		public static Ability YouMay(BoardCondition @if, CardAction then)
			=> new Ability(@if, null, then, true);
	}
}
