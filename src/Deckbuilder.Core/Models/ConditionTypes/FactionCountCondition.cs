using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.ConditionTypes
{
	public class FactionCountCondition : BoardCondition
	{
		public FactionCountCondition(int value, OperatorCode @operator, FactionCode faction)
		{
			Value = value;
			Operator = @operator;
			Faction = faction;
		}

		public int Value { get; }
		public OperatorCode Operator { get; }
		public FactionCode Faction { get; }
		public override ConditionType Type => ConditionType.FactionCount;

		public override string Description
			=> $"You control {OperatorString(Operator, Value)} {Faction} cards";
	}
}
