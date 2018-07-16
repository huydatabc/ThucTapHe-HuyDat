using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triluatsoft.tls.Board.PosterDTO
{
    [AutoMapTo(typeof(Poster))]

    public class DeletePosterInput
    {
        public int Id { get; set; }

    }
}
