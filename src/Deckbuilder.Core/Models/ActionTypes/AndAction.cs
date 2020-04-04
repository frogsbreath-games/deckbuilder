using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.ActionTypes
{
	public class AndAction : CardAction
	{
		public AndAction(List<CardAction> actions)
		{
			Actions = actions;
		}

		public List<CardAction> Actions { get; }
		public override ActionType Type => ActionType.And;

		public override string Description =>
			string.Join(" AND ", Actions.Select(a => $"<{a.Description}>"));
	}
}
