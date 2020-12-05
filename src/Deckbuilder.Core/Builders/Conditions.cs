using Deckbuilder.Core.Enums;
using Deckbuilder.Core.Models.ConditionTypes;

namespace Deckbuilder.Core.Builders
{
	public static class Conditions
	{
		public static FactionCountCondition FactionCount(FactionCode faction, int count)
			=> FactionCount(faction, OperatorCode.Equals, count);

		public static FactionCountCondition FactionCount(FactionCode faction, OperatorCode @operator, int value)
			=> new FactionCountCondition(value, @operator, faction);

		public static KeywordCountCondition KeywordCount(KeywordCode keyword, int count)
			=> KeywordCount(keyword, OperatorCode.Equals, count);

		public static KeywordCountCondition KeywordCount(KeywordCode keyword, OperatorCode @operator, int value)
			=> new KeywordCountCondition(value, @operator, keyword);

		public static CardTypeCountCondition CardTypeCount(CardType cardType, int count)
			=> CardTypeCount(cardType, OperatorCode.Equals, count);

		public static CardTypeCountCondition CardTypeCount(CardType cardType, OperatorCode @operator, int value)
			=> new CardTypeCountCondition(value, @operator, cardType);

		public static ResourceCountCondition ResourceCount(ResourceType resource, int count)
			=> ResourceCount(resource, OperatorCode.Equals, count);

		public static ResourceCountCondition ResourceCount(ResourceType resource, OperatorCode @operator, int value)
			=> new ResourceCountCondition(value, @operator, resource);
	}
}
