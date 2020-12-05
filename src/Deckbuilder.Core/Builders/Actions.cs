using Deckbuilder.Core.Models;
using Deckbuilder.Core.Models.ActionTypes;

namespace Deckbuilder.Core.Builders
{
	public static class Actions
	{
		public static ConditionalAction Conditional(BoardCondition @if, CardAction then)
			=> new ConditionalAction(then, @if);

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

		public static LoseAction Lose(ResourceList resources)
			=> new LoseAction(resources);

		public static LoseAction LoseGold(int count)
			=> Lose(Resources.Gold(count));

		public static LoseAction LoseDamage(int count)
			=> Lose(Resources.Damage(count));

		public static LoseAction LoseGlory(int count)
			=> Lose(Resources.Glory(count));

		public static LoseAction LoseHealth(int count)
			=> Lose(Resources.Health(count));

		public static DrawAction Draw(int count)
			=> new DrawAction(count, false);

		public static DrawAction DrawUpTo(int count)
			=> new DrawAction(count, true);

		public static DiscardAction Discard(int count)
			=> new DiscardAction(count, false);

		public static DiscardAction DiscardUpTo(int count)
			=> new DiscardAction(count, true);
	}
}
