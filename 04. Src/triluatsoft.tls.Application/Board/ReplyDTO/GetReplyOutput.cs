using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triluatsoft.tls.Board.ReplyDTO
{
    [AutoMapTo(typeof(Reply))]
    public class GetReplyOutput
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public long CreatorId { get; set; }
        public int? ThreadId { get; set; }
        public string MediaPath { get; set; }
        public string FileExtension { get; set; }
        public string PosterName { get; set; }

    }
}
