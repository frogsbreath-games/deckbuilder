using System.Collections.Generic;
using Deckbuilder.Core.Models;
using Deckbuilder.Core.Models.FilterTypes;

namespace Deckbuilder.Core.Extensions
{
	public static class FilterExtensions
	{
		public static OrFilter Or(this CardFilter leftFilter, CardFilter rightFilter)
		{
			List<CardFilter> filters = new List<CardFilter>();

			if (leftFilter is OrFilter leftOrFilters)
				filters.AddRange(leftOrFilters.Filters);
			else
				filters.Add(leftFilter);

			if (rightFilter is OrFilter rightOrFilters)
				filters.AddRange(rightOrFilters.Filters);
			else
				filters.Add(rightFilter);

			return new OrFilter(filters);
		}

		public static AndFilter And(this CardFilter leftFilter, CardFilter rightFilter)
		{
			List<CardFilter> filters = new List<CardFilter>();

			if (leftFilter is AndFilter leftOrFilters)
				filters.AddRange(leftOrFilters.Filters);
			else
				filters.Add(leftFilter);

			if (rightFilter is AndFilter rightOrFilters)
				filters.AddRange(rightOrFilters.Filters);
			else
				filters.Add(rightFilter);

			return new AndFilter(filters);
		}
	}
}
