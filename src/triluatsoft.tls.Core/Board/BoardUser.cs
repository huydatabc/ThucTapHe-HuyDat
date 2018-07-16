using Abp.Dependency;
using Abp.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triluatsoft.tls.Board
{
    public class BoardUser : ITransientDependency
    {
        public IAbpSession AbpSession { get; set; }

        public BoardUser()
        {
            AbpSession = NullAbpSession.Instance;
        }

        public void MyMethod()
        {
            var UserId = AbpSession.UserId;
            //...
        }
    }
}
