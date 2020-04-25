using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deckbuilder.App.Clients;
using Deckbuilder.App.Hubs;
using Deckbuilder.App.Models;
using Microsoft.AspNetCore.SignalR;

namespace Deckbuilder.App.Services
{
	public interface IBoardUpdater
	{
		Task UpdateBoard(int id, BoardModel board);
	}

	public class BoardUpdater : IBoardUpdater
	{
		protected readonly IHubContext<BoardHub, IBoardClient> _boardContext;
		protected readonly BoardSingletonRepo _boardRepository;

		public BoardUpdater(IHubContext<BoardHub, IBoardClient> boardContext, BoardSingletonRepo boardRepository)
		{
			_boardContext = boardContext;
			_boardRepository = boardRepository;
		}

		public async Task UpdateBoard(int id, BoardModel board)
		{
			_boardRepository.UpdateBoard(id, board);

			await _boardContext.Clients.All.BoardUpdated(id, board);
		}
	}
}
