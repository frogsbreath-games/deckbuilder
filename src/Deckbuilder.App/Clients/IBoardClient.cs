using System.Threading.Tasks;
using Deckbuilder.App.Models;

namespace Deckbuilder.App.Clients
{
	public interface IBoardClient
	{
		Task BoardUpdated(int id, BoardModel boardModel);
	}
}
