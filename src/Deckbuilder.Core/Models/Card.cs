using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models
{
	public abstract class Card
	{
		protected Card(
			int id,
			string name,
			string code,
			FactionCode? faction = null,
			IEnumerable<KeywordCode>? keywords = null)
		{
			Id = id;
			Name = name;
			Code = code;
			Faction = faction;
			Keywords = keywords?.ToList() ?? new List<KeywordCode>();
		}

		public int Id { get; protected set; }
		public string Name { get; protected set; }
		public string Code { get; protected set; }
		public virtual int Version => 1;
		public virtual string Form => "default";
		public FactionCode? Faction { get; protected set; }
		public List<KeywordCode> Keywords { get; protected set; }
		public abstract CardType Type { get; }
		public abstract int? PurchasePrice { get; }
		public abstract CardAction? BoardEffect { get; }
		public abstract List<Ability>? BoardAbilities { get; }
		public abstract int? MonsterPower { get; }
		public abstract CardAction? Bounty { get; }
		public abstract int? Defense { get; }
		public abstract bool? Permanent { get; }
		public abstract List<CardUpgrade>? Upgrades { get; }
	}
}
