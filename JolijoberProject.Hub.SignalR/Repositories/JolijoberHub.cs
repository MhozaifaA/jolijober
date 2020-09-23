using JolijoberProject.Hub.SignalR.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JolijoberProject.Hub.SignalR.Repositories
{
  //  [Authorize]
    public class JolijoberHub : Hub<ISendOnHub>, IJolijoberHub
    {
        public async Task NewPost(string id)
        {
             await  Clients.Others.OnNewPost(id);
        }
    }
}
