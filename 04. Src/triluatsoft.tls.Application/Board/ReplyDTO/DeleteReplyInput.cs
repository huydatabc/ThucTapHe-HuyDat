using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triluatsoft.tls.Board.ReplyDTO
{
    [AutoMapTo(typeof(Reply))]
    public class DeleteReplyInput
    {
        public int Id { get; set; }
    }
}
