namespace Deckbuilder.Core.Models
{
	public class PermanentCardMeta
	{
		public PermanentCardMeta(ResourceList? removalCost, bool fortification)
		{
			RemovalCost = removalCost;
			Fortification = fortification;
		}

		public ResourceList? RemovalCost { get; }
		public bool Fortification { get; }
	}
}
