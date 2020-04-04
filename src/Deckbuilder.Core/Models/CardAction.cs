using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Enums;
using Newtonsoft.Json;

namespace Deckbuilder.Core.Models
{
	public abstract class CardAction
	{
		public abstract ActionType Type { get; }

		public abstract string Description { get; }
	}
}
