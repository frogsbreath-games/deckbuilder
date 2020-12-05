using System.Collections.Generic;

namespace Deckbuilder.Core.Models
{
	public class BoardCardMeta
	{
		public BoardCardMeta(
			CardAction? effect,
			IEnumerable<Ability>? abilities,
			PermanentCardMeta? permanent)
		{
			Effect = effect;
			Abilities = abilities;
			Permanent = permanent;
		}

		public CardAction? Effect { get; }
		public IEnumerable<Ability>? Abilities { get; }
		public PermanentCardMeta? Permanent { get; }
	}
}
