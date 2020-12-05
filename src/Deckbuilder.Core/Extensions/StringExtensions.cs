namespace Deckbuilder.Core.Extensions
{
	public static class StringExtensions
	{
		public static string ToLowerFirst(this string str)
			=> char.ToLower(str[0]).ToString() + str.Substring(1);
	}
}
