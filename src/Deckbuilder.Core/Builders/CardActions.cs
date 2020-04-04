using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Enums;
using Deckbuilder.Core.Models;
using Deckbuilder.Core.Models.ActionTypes;

namespace Deckbuilder.Core.Builders
{
	public static class CardActions
	{
		public static GainAction Gain(ResourceList resources)
			=> new GainAction(resources);

		public static GainAction GainGold(int count)
			=> Gain(Resources.Gold(count));

		public static GainAction GainDamage(int count)
			=> Gain(Resources.Damage(count));

		public static GainAction GainGlory(int count)
			=> Gain(Resources.Glory(count));

		public static GainAction GainHealth(int count)
			=> Gain(Resources.Health(count));

		public static DrawAction Draw(int count)
			=> new DrawAction(count);
	}
}
