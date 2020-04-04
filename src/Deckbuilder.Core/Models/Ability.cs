using System;
using System.Collections.Generic;
using System.Text;

namespace Deckbuilder.Core.Models
{
	public class Ability
	{
		public Ability(ResourceList? cost, CardAction action, bool unlimited = false)
		{
			Cost = cost;
			Action = action;
			Unlimited = unlimited;
		}

		public ResourceList? Cost { get; }
		public CardAction Action { get; }
		public bool Unlimited { get; }

		public string Description =>
			(Unlimited ? "Throughout this turn, you may " : "Once this turn, you may ")
			+ (Cost is ResourceList cost ? $"pay {cost.Description}, then " : string.Empty)
			+ Action.Description;
	}
}
