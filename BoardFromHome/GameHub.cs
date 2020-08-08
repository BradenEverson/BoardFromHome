using BoardFromHome.Core;
using BoardFromHome.Database;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardFromHome
{
    public class GameHub : Hub
    {
        private readonly ICardGameData games;
        public GameHub(ICardGameData games)
        {
            this.games = games;
        }
        public async Task userJoined(string gameId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
            await Clients.Group(gameId).SendAsync("Update", $"{Context.ConnectionId} joined");
        }
        public async Task userRemoved(string gameId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, gameId);
            await Clients.Group(gameId).SendAsync("Update", $"{Context.ConnectionId} left");
        }
        public async Task moveMade(string gameId, string cardMovedId)
        {
            await Clients.Group(gameId).SendAsync("MoveMade", cardMovedId);
        }
        public async Task cardDrawn(string gameId, string cardDetails)
        {
            await Clients.Group(gameId).SendAsync("CardDrawn", cardDetails, Context.ConnectionId);
        }
    }
}
