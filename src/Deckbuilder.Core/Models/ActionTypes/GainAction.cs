using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.ActionTypes
{
	public class GainAction : CardAction
	{
		public GainAction(ResourceList resources)
		{
			Resources = resources;
		}

		public ResourceList Resources { get; }

		public override ActionType Type => ActionType.Gain;

		public override string Description => $"Gain {Resources.Description}";
	}
}
