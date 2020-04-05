using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Enums;
using Deckbuilder.Core.Models.ConditionTypes;

namespace Deckbuilder.Core.Builders
{
	public static class Conditions
	{
		public static FactionCountCondition FactionCount(FactionCode faction, int count)
			=> FactionCount(faction, OperatorCode.Equals, count);

		public static FactionCountCondition FactionCount(FactionCode faction, OperatorCode @operator, int value)
			=> new FactionCountCondition(value, @operator, faction);

		public static KeywordCountCondition KeywordCount(KeywordCode keyword, int count)
			=> KeywordCount(keyword, OperatorCode.Equals, count);

		public static KeywordCountCondition KeywordCount(KeywordCode keyword, OperatorCode @operator, int value)
			=> new KeywordCountCondition(value, @operator, keyword);
	}
}
