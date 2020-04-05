using System;
using System.Collections.Generic;
using System.Text;

namespace Deckbuilder.Core.Enums
{
	public enum EventType
	{
		MonsterDefeated,
		CardAcquired,
		PermanentDestroyed,
		CardBanished,
		CardDiscarded,
		CardCasted,
		CardDrawn,
		EnemyDamaged,
		PlayerHealed,

		TurnStarted,
		TurnEnded,
	}
}
