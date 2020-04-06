using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.ConditionTypes
{
	public class CardTypeCountCondition : BoardCondition
	{
		public CardTypeCountCondition(int value, OperatorCode @operator, CardType cardType)
		{
			Value = value;
			Operator = @operator;
			CardType = cardType;
		}

		public int Value { get; }
		public OperatorCode Operator { get; }
		public CardType CardType { get; }
		public override ConditionType Type => ConditionType.CardTypeCount;

		public override string Description
			=> $"You control {OperatorString(Operator, Value)} {CardType} cards";
	}
}
