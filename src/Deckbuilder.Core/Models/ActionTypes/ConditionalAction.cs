using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Enums;
using Deckbuilder.Core.Extensions;

namespace Deckbuilder.Core.Models.ActionTypes
{
	public class ConditionalAction : CardAction
	{
		public ConditionalAction(CardAction action, BoardCondition condition)
		{
			Action = action;
			Condition = condition;
		}

		public CardAction Action { get; }
		public BoardCondition Condition { get; }
		public override ActionType Type => ActionType.Conditional;

		public override string Description => $"If {Condition.Description.ToLowerFirst()}, then {Action.Description.ToLowerFirst()}";
	}
}
