using System.Linq;
using System.Threading.Tasks;
using Deckbuilder.App.Models;
using Deckbuilder.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Deckbuilder.App.Controllers
{
	[ApiController]
	[Route("board")]
	public class BoardController : ControllerBase
	{
		protected BoardSingletonRepo _boardRepository;
		protected IBoardUpdater _boardUpdater;
		protected IBoardGenerator _boardGenerator;

		public BoardController(BoardSingletonRepo boardRepository, IBoardUpdater boardUpdater, IBoardGenerator boardGenerator)
		{
			_boardRepository = boardRepository;
			_boardUpdater = boardUpdater;
			_boardGenerator = boardGenerator;
		}

		[HttpPost("initialize")]
		public async Task<IActionResult> InitializeBoard()
		{
			var board = _boardGenerator.GenerateBoard();

			var id = _boardRepository.AddBoard(board);

			await _boardUpdater.UpdateBoard(id, board);

			return Accepted();
		}

		[HttpGet("random")]
		public BoardModel GetRandomBoard()
			=> _boardGenerator.GenerateBoard();

		[HttpGet("{id}")]
		public IActionResult GetById([FromRoute] int id)
		{
			var board = _boardRepository.GetBoard(id);

			if (board is null)
				return NotFound();

			return Ok(board);
		}

		[HttpGet("{id}/player/{playerNumber}")]
		public IActionResult GetBoardPlayer([FromRoute] int id, [FromRoute] int playerNumber)
		{
			var board = _boardRepository.GetBoard(id);

			if (board is null)
				return NotFound();

			var player = board.Players.SingleOrDefault(p => p.Number == playerNumber);

			if (player is null)
				return NotFound();

			return Ok(board);
		}
	}
}
