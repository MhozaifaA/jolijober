using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JolijoberProject.Hub.SignalR.Interfaces
{
    public interface ISendOnHub
    {
        /// <summary>
        /// <para>_</para>
        ///  SendMessage to clients real time listening if post added
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task OnNewPost(string id);
    }
}
