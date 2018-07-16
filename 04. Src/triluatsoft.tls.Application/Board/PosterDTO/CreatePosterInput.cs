using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triluatsoft.tls.Board.PosterDTO
{
    [AutoMapTo(typeof(Poster))]
    public class CreatePosterInput
    {
        public string PosterName { get; set; }
        public int PosterId { get; set; }
    }
}
