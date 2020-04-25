using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models
{
	public class KeywordList<TEnum> : Dictionary<TEnum, bool>, IEnumerable<TEnum>
		where TEnum : Enum
	{
		public KeywordList(IEnumerable<TEnum> keywords)
		{
			foreach (var k in keywords)
				this[k] = true;
		}

		public KeywordList(params TEnum[] keywords)
			: this((IEnumerable<TEnum>)keywords) { }

		public static implicit operator KeywordList<TEnum>(List<TEnum> keywords)
			=> new KeywordList<TEnum>(keywords);

		public static implicit operator KeywordList<TEnum>(TEnum[] keywords)
			=> new KeywordList<TEnum>(keywords);

		public static implicit operator List<TEnum>(KeywordList<TEnum> list)
			=> list.Keys.ToList();

		public void Add(TEnum keyword)
		{
			this[keyword] = true;
		}

		IEnumerator<TEnum> IEnumerable<TEnum>.GetEnumerator()
			=> Keys.GetEnumerator();
	}
}
