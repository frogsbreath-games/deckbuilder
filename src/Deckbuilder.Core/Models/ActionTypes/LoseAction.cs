using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.ActionTypes
{
	public class LoseAction : CardAction
	{
		public LoseAction(ResourceList resources)
		{
			Resources = resources;
		}

		public ResourceList Resources { get; }

		public override ActionType Type => ActionType.Lose;

		public override string Description => $"Lose {Resources.Description}";
	}
}
