using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.ConditionTypes
{
	public class ResourceCountCondition : BoardCondition
	{
		public ResourceCountCondition(int value, OperatorCode @operator, ResourceType resource)
		{
			Value = value;
			Operator = @operator;
			Resource = resource;
		}

		public int Value { get; }
		public OperatorCode Operator { get; }
		public ResourceType Resource { get; }
		public override ConditionType Type => ConditionType.ResourceCount;

		public override string Description
			=> $"You have {OperatorString(Operator, Value)} {Resource}";
	}
}
