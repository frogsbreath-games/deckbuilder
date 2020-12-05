using Deckbuilder.App.Clients;
using Microsoft.AspNetCore.SignalR;

namespace Deckbuilder.App.Hubs
{
	public class BoardHub : Hub<IBoardClient>
	{
	}
}
