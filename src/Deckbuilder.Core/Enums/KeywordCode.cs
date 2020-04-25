using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

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
