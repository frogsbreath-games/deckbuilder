using System;
using System.Threading;

namespace Deckbuilder.App.Services
{
	public interface IRandomAccessor
	{
		Random Random { get; }
	}

	public class RandomAccessor : IRandomAccessor
	{
		protected readonly Random _rand;

		public RandomAccessor()
		{
			_rand = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId));
		}

		public Random Random => _rand;
	}
}
