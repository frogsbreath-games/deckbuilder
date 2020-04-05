using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.ConditionTypes
{
	public class KeywordCountCondition : BoardCondition
	{
		public KeywordCountCondition(int value, OperatorCode @operator, KeywordCode keyword)
		{
			Value = value;
			Operator = @operator;
			Keyword = keyword;
		}

		public int Value { get; }
		public OperatorCode Operator { get; }
		public KeywordCode Keyword { get; }
		public override ConditionType Type => ConditionType.KeywordCount;

		public override string Description
			=> $"You control {OperatorString(Operator, Value)} {Keyword} cards";
	}
}
