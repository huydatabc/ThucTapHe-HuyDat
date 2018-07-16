using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using triluatsoft.tls.Board.ThreadDTO;


namespace triluatsoft.tls.Board
{
    public interface IThreadAppService : IApplicationService
    {
        Task Create(CreateThreadInput input);
        void Update(UpdateThreadInput input);
        void Delete(DeleteThreadInput input);
        GetThreadOutput GetThreadById(GetThreadInput input);
        Array ListAll();
    }
}
