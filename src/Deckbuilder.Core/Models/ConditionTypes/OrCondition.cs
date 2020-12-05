using System.Collections.Generic;
using System.Linq;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models.ConditionTypes
{
	public class OrCondition : BoardCondition
	{
		public OrCondition(List<BoardCondition> conditions)
		{
			Conditions = conditions;
		}

		public List<BoardCondition> Conditions { get; }
		public override ConditionType Type => ConditionType.Or;

		public override string Description =>
			string.Join(" OR ", Conditions.Select(a => $"<{a.Description}>"));
	}
}
