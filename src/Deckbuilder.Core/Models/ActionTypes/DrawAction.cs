using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.ActionTypes
{
	public class DrawAction : CardAction
	{
		public DrawAction(int count, bool optional = false)
		{
			Count = count;
			Optional = optional;
		}

		public int Count { get; }

		public bool Optional { get; }

		public override ActionType Type => ActionType.Draw;

		public override string Description => Optional
			? $"Draw up to {Count} card(s)"
			: $"Draw {Count} card(s)";
	}
}
