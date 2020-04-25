using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deckbuilder.App.Models;

namespace Deckbuilder.App.Services
{
	public class BoardSingletonRepo
	{
		protected readonly Dictionary<int, BoardModel> Boards;
		protected int NextId;

		public BoardSingletonRepo()
		{
			Boards = new Dictionary<int, BoardModel>();
			NextId = 1;
		}

		public int AddBoard(BoardModel board)
		{
			int id = NextId;
			Boards[id] = board;
			NextId++;
			return id;
		}

		public BoardModel? GetBoard(int id)
		{
			return Boards.TryGetValue(id, out var board)
				? board
				: null;
		}

		public void UpdateBoard(int id, BoardModel board)
		{
			Boards[id] = board;
		}

		public IEnumerable<BoardModel> GetAllBoards()
		{
			return Boards.Values;
		}
	}
}
