using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models
{
	public interface IResourceList : IReadOnlyDictionary<ResourceType, int>
	{
	}

	public class ResourceList : Dictionary<ResourceType, int>, IResourceList
	{
		public static ResourceList operator +(ResourceList leftResources, ResourceList rightResources)
		{
			foreach (var keyValue in rightResources)
			{
				if (leftResources.ContainsKey(keyValue.Key))
					leftResources[keyValue.Key] += keyValue.Value;
				else
					leftResources[keyValue.Key] = keyValue.Value;
			}

			return leftResources;
		}

		public string Description =>
			string.Join(", ", this.Select(kv => $"{kv.Value} {kv.Key}"));
	}
}
