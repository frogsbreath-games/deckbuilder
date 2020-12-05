using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.ActionTypes
{
	public class DiscardAction : CardAction
	{
		public DiscardAction(int count, bool optional = false)
		{
			Count = count;
			Optional = optional;
		}

		public int Count { get; }

		public bool Optional { get; }

		public override ActionType Type => ActionType.Discard;

		public override string Description => Optional
			? $"Discard up to {Count} card(s)"
			: $"Discard {Count} card(s)";
	}
}
