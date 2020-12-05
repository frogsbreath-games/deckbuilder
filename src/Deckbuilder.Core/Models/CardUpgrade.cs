namespace Deckbuilder.Core.Models
{
	public class CardUpgrade
	{
		public CardUpgrade(ResourceList? cost, string form)
		{
			Cost = cost;
			Form = form;
		}

		public ResourceList? Cost { get; }
		public string Form { get; }
	}
}
