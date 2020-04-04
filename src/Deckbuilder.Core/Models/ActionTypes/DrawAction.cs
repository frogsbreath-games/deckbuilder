using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.ActionTypes
{
	public class DrawAction : CardAction
	{
		public DrawAction(int count)
		{
			Count = count;
		}

		public int Count { get; }

		public override ActionType Type => ActionType.Draw;

		public override string Description => $"Draw {Count} card(s)";
	}
}
