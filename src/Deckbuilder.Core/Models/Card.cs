using System.Collections.Generic;
using System.Linq;
using Deckbuilder.Core.Enums;

namespace Deckbuilder.Core.Models
{
	public abstract class Card
	{
		protected Card(
			int id,
			string name,
			string code,
			FactionCode? faction,
			IEnumerable<KeywordCode>? keywords,
			BoardCardMeta? board = null,
			StoreCardMeta? store = null)
		{
			Id = id;
			Name = name;
			Code = code;
			Faction = faction;
			Keywords = keywords?.ToList() ?? new List<KeywordCode>();
			Board = board;
			Store = store;
		}

		public int Id { get; protected set; }
		public string Name { get; protected set; }
		public string Code { get; protected set; }
		public virtual int Version => 1;
		public virtual string Form => "default";
		public FactionCode? Faction { get; protected set; }
		public KeywordList<KeywordCode> Keywords { get; protected set; }

		public BoardCardMeta? Board { get; }
		public StoreCardMeta? Store { get; }
		public abstract CardType Type { get; }
		/*
		public abstract ResourceList? StoreCost { get; }
		public abstract CardAction? BoardEffect { get; }
		public abstract List<Ability>? BoardAbilities { get; }
		public abstract CardAction? Bounty { get; }
		public abstract ResourceList? RemovalCost { get; }
		public abstract bool? Permanent { get; }
		*/
		public abstract List<CardUpgrade>? Upgrades { get; }

		public string Description
			=> $"{string.Join(" ", ((IEnumerable<KeywordCode>)Keywords).Select(k => k.ToString()))} {Type}";
	}
}
