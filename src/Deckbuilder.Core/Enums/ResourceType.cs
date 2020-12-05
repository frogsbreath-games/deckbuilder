using System.Runtime.Serialization;

namespace Deckbuilder.Core.Enums
{
	public enum ResourceType
	{
		[EnumMember(Value = "gold")]
		Gold,

		[EnumMember(Value = "damage")]
		Damage,

		[EnumMember(Value = "glory")]
		Glory,

		[EnumMember(Value = "health")]
		Health,
	}
}
