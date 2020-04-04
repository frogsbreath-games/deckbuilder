using System;
using System.Collections.Generic;
using System.Text;
using Deckbuilder.Core.Enums;
using Deckbuilder.Core.Models;

namespace Deckbuilder.Core.Builders
{
	public class Resources
	{
		public static ResourceList Gold(int count)
			=> new ResourceList { [ResourceType.Gold] = count };

		public static ResourceList Glory(int count)
			=> new ResourceList { [ResourceType.Glory] = count };

		public static ResourceList Health(int count)
			=> new ResourceList { [ResourceType.Health] = count };

		public static ResourceList Damage(int count)
			=> new ResourceList { [ResourceType.Damage] = count };
	}
}
