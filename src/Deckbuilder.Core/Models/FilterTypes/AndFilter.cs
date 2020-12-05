using System.Collections.Generic;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.FilterTypes
{
	public class AndFilter : CardFilter
	{
		public AndFilter(List<CardFilter> filters)
		{
			Filters = filters;
		}

		public List<CardFilter> Filters { get; }
		public override FilterType Type => FilterType.And;

		public override string? Adjective => null; //TODO

		public override string? Attribute => null; //TODO
	}
}
