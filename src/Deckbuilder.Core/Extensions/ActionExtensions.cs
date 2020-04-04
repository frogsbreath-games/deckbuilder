using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Models;
using Deckbuilder.Core.Models.ActionTypes;

namespace Deckbuilder.Core.Extensions
{
	public static class ActionExtensions
	{
		public static OrAction Or(this CardAction leftAction, CardAction rightAction)
		{
			List<CardAction> actions = new List<CardAction>();

			if (leftAction is OrAction leftOrActions)
				actions.AddRange(leftOrActions.Actions);
			else
				actions.Add(leftAction);

			if (rightAction is OrAction rightOrActions)
				actions.AddRange(rightOrActions.Actions);
			else
				actions.Add(rightAction);

			return new OrAction(actions);
		}

		public static AndAction And(this CardAction leftAction, CardAction rightAction)
		{
			List<CardAction> actions = new List<CardAction>();

			if (leftAction is AndAction leftOrActions)
				actions.AddRange(leftOrActions.Actions);
			else
				actions.Add(leftAction);

			if (rightAction is AndAction rightOrActions)
				actions.AddRange(rightOrActions.Actions);
			else
				actions.Add(rightAction);

			return new AndAction(actions);
		}
	}
}
