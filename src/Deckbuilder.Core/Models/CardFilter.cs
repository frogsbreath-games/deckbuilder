using Deckbuilder.Core.Enums;
using Deckbuilder.Core.Extensions;
using Deckbuilder.Core.Models.FilterTypes;

namespace Deckbuilder.Core.Models
{
	public abstract class CardFilter
	{
		public abstract FilterType Type { get; }

		public abstract string? Adjective { get; }
		public abstract string? Attribute { get; }

		public static AndFilter operator &(CardFilter left, CardFilter right)
			=> left.And(right);

		public static OrFilter operator |(CardFilter left, CardFilter right)
			=> left.Or(right);
	}
}
