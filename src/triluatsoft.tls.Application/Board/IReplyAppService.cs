using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using triluatsoft.tls.Board.ReplyDTO;

namespace triluatsoft.tls.Board
{
    public interface IReplyAppService : IApplicationService
    {
        Task Create(CreateReplyInput input);
        void Update(UpdateReplyInput input);
        void Delete(DeleteReplyInput input);
        GetReplyOutput GetReplyById(GetReplyInput input);
        Array ListAll();
        Array GetReplyByThreadId(GetReplyByThreadIdInput input); //GetReplyByThreadIdInput inpu
    }
}
