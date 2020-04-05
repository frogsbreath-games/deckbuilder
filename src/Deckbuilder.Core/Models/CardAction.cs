using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Enums;
using Deckbuilder.Core.Extensions;
using Deckbuilder.Core.Models.ActionTypes;
using Newtonsoft.Json;

namespace Deckbuilder.Core.Models
{
	public abstract class CardAction
	{
		public abstract ActionType Type { get; }

		public abstract string Description { get; }

		public static AndAction operator &(CardAction left, CardAction right)
			=> left.And(right);

		public static OrAction operator |(CardAction left, CardAction right)
			=> left.Or(right);
	}
}
