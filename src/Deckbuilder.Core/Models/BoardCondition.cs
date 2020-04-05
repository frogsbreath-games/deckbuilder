using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Enums;
using Deckbuilder.Core.Extensions;
using Deckbuilder.Core.Models.ConditionTypes;

namespace Deckbuilder.Core.Models
{
	public abstract class BoardCondition
	{
		public abstract ConditionType Type { get; }
		public abstract string Description { get; }

		public static AndCondition operator &(BoardCondition left, BoardCondition right)
			=> left.And(right);

		public static OrCondition operator |(BoardCondition left, BoardCondition right)
			=> left.Or(right);

		protected static string OperatorString(OperatorCode @operator, int value)
		{
			return @operator switch
			{
				OperatorCode.Equals => $"{value}",
				OperatorCode.GreaterThan => $"more than {value}",
				OperatorCode.GreaterThanOrEqualTo => $"{value} or more",
				OperatorCode.LessThan => $"fewer than {value}",
				OperatorCode.LessThanOrEqualTo => $"{value} or fewer",
				_ => throw new NotImplementedException(),
			};
		}
	}
}
