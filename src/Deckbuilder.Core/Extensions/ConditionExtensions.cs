using System.Collections.Generic;
using Deckbuilder.Core.Models;
using Deckbuilder.Core.Models.ConditionTypes;

namespace Deckbuilder.Core.Extensions
{
	public static class ConditionExtensions
	{
		public static OrCondition Or(this BoardCondition leftCondition, BoardCondition rightCondition)
		{
			List<BoardCondition> conditions = new List<BoardCondition>();

			if (leftCondition is OrCondition leftOrConditions)
				conditions.AddRange(leftOrConditions.Conditions);
			else
				conditions.Add(leftCondition);

			if (rightCondition is OrCondition rightOrConditions)
				conditions.AddRange(rightOrConditions.Conditions);
			else
				conditions.Add(rightCondition);

			return new OrCondition(conditions);
		}

		public static AndCondition And(this BoardCondition leftCondition, BoardCondition rightCondition)
		{
			List<BoardCondition> conditions = new List<BoardCondition>();

			if (leftCondition is AndCondition leftOrConditions)
				conditions.AddRange(leftOrConditions.Conditions);
			else
				conditions.Add(leftCondition);

			if (rightCondition is AndCondition rightOrConditions)
				conditions.AddRange(rightOrConditions.Conditions);
			else
				conditions.Add(rightCondition);

			return new AndCondition(conditions);
		}
	}
}
