using System;
using System.Collections.Generic;
using System.Text;

namespace Deckbuilder.Core.Models
{
	public class StoreCardMeta
	{
		public StoreCardMeta(
			ResourceList cost,
			CardAction? bounty,
			bool acquire)
		{
			Cost = cost;
			Bounty = bounty;
			Acquire = acquire;
		}

		public ResourceList Cost { get; }
		public CardAction? Bounty { get; }
		public bool Acquire { get; }
	}
}
