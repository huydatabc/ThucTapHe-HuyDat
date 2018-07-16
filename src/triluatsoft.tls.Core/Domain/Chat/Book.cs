using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triluatsoft.tls.Domain.Chat
{
    [Table("TL_Book")]
    public class Book:FullAuditedEntity<Guid>
    {
        public string Name { get; set; }
    }
}
