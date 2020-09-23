using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JolijoberProject.Hub.SignalR.Interfaces
{
    public interface IJolijoberHub
    {
        /// <summary>
        /// <para>_</para>
        /// Invoke by client  who added the new post
        /// </summary>
        /// <param name=")"></param>
        /// <returns></returns>
        Task NewPost(string id);
    }
}
