using System;
using System.Collections.Generic;
using System.Text;

namespace Deckbuilder.Core.Models
{
	public class Trigger
	{
		public Trigger(
			BoardEvent triggerEvent,
			Ability ability,
			BoardEvent? expirationEvent = null,
			bool unlimited = false)
		{
			TriggerEvent = triggerEvent;
			Ability = ability;
			ExpirationEvent = expirationEvent;
			Unlimited = unlimited;
		}

		public BoardEvent TriggerEvent { get; }
		public Ability Ability { get; }
		public BoardEvent? ExpirationEvent { get; }
		public bool Unlimited { get; }
	}
}
