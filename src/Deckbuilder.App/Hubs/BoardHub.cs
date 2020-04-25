using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deckbuilder.App.Clients;
using Microsoft.AspNetCore.SignalR;

namespace Deckbuilder.App.Hubs
{
	public class BoardHub : Hub<IBoardClient>
	{
	}
}
