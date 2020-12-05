using System.Collections.Generic;
using System.Linq;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.ConditionTypes
{
	public class AndCondition : BoardCondition
	{
		public AndCondition(List<BoardCondition> conditions)
		{
			Conditions = conditions;
		}

		public List<BoardCondition> Conditions { get; }
		public override ConditionType Type => ConditionType.And;

		public override string Description =>
			string.Join(" AND ", Conditions.Select(a => $"<{a.Description}>"));
	}
}
