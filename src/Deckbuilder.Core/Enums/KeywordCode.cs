using System.Runtime.Serialization;

namespace Deckbuilder.Core.Enums
{
	public enum KeywordCode
	{
		[EnumMember(Value = "angel")]
		Angel,

		[EnumMember(Value = "demon")]
		Demon,

		[EnumMember(Value = "soldier")]
		Soldier,

		[EnumMember(Value = "vermin")]
		Vermin,

		[EnumMember(Value = "wizard")]
		Wizard,
	}
}
