using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triluatsoft.tls.Board.ThreadDTO
{
    [AutoMapTo(typeof(Thread))]
    public class CreateThreadInput
    {
        public string Content { get; set; }
        public long CreatorId { get; set; }
        public string MediaPath { get; set; }
        public string FileExtension { get; set; }
        public string PosterName { get; set; }

    }
}
