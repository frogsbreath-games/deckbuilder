using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Extensions;

namespace Deckbuilder.Core.Models
{
	public class Ability
	{
		public Ability(BoardCondition? condition, ResourceList? cost, CardAction action, bool unlimited = false)
		{
			Condition = condition;
			Cost = cost;
			Action = action;
			Unlimited = unlimited;
		}
		public BoardCondition? Condition { get; }
		public ResourceList? Cost { get; }
		public CardAction Action { get; }
		public bool Unlimited { get; }

		public string Description =>
			(Unlimited
				? "Throughout this turn, "
				: "Once this turn, ")
			+ (Condition is BoardCondition condition
				? $"if {condition.Description.ToLowerFirst()}, "
				: string.Empty)
			+ "you may "
			+ (Cost is ResourceList cost
				? $"pay {cost.Description.ToLowerFirst()}, then "
				: string.Empty)
			+ Action.Description.ToLowerFirst();
	}
}
