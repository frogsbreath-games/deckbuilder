using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models
{
	public abstract class CardFilter
	{
		public abstract FilterType Type { get; }
	}
}
