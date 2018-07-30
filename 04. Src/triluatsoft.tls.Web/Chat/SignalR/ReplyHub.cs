using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abp.Dependency;
using Abp.Runtime.Session;
using Castle.Core.Logging;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using triluatsoft.tls.Board;

namespace triluatsoft.tls.Web.App.tenant.views.imageboard.hub
{
    public class ReplyHub : Hub, ITransientDependency
    {
        public IAbpSession AbpSession { get; set; }
        public ReplyAppService _replyAppService;

        public ILogger Logger { get; set; }
        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<BoardHub>();

        public ReplyHub(ReplyAppService replyAppService)
        {
            _replyAppService = replyAppService;
            AbpSession = NullAbpSession.Instance;
            Logger = NullLogger.Instance;
        }
        public void Hello()
        {
            Clients.All.hello();
        }
        public void SendMessage(string message)
        {
            Clients.All.getMessage(string.Format("User {0}: {1}", AbpSession.UserId, message));
        }

        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
            _replyAppService.ListAll();
        }
        public void UpdateReply()
        {
            Clients.All.getReply();
        }

    }
}