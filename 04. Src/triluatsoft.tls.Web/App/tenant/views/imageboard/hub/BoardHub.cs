using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace triluatsoft.tls.Web.App.tenant.views.imageboard.hub
{
    [HubName("ImageBoardHub")]
    public class BoardHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}