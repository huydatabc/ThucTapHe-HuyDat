using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using triluatsoft.tls.Board.PosterDTO;

namespace triluatsoft.tls.Board
{
    public interface IPosterAppService : IApplicationService
    {
        Task Create(CreatePosterInput input);
        void Update(UpdatePosterInput input);
        void Delete(DeletePosterInput input);
        GetPosterOutput GetPosterById(GetPosterInput input);
        Array ListAll();
    }
}
