using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models
{
	public abstract class BoardEvent
	{
		public abstract EventType Type { get; }
	}
}
