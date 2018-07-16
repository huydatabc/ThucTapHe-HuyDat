using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triluatsoft.tls.Board.ThreadDTO
{
    [AutoMapTo(typeof(Thread))]
    public class GetThreadInput
    {
        public int Id { get; set; }
    }
}
