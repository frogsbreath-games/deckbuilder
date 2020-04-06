using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.FilterTypes
{
	public class OrFilter : CardFilter
	{
		public OrFilter(List<CardFilter> filters)
		{
			Filters = filters;
		}

		public List<CardFilter> Filters { get; }
		public override FilterType Type => FilterType.Or;

		public override string? Adjective => null; //TODO

		public override string? Attribute => null; //TODO
	}
}
