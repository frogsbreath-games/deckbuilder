using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.ActionTypes
{
	public class OrAction : CardAction
	{
		public OrAction(List<CardAction> actions)
		{
			Actions = actions;
		}

		public List<CardAction> Actions { get; }
		public override ActionType Type => ActionType.Or;

		public override string Description =>
			string.Join(" OR ", Actions.Select(a => $"<{a.Description}>"));
	}
}
