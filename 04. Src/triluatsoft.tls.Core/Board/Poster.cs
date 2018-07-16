using Abp.Dependency;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using triluatsoft.tls.Authorization.Users;

namespace triluatsoft.tls.Board
{
    public class Poster : FullAuditedEntity
    {

        [Required]
        public string PosterName { get; set; }
        public int PosterId { get; set; }

        //public int UserId { get; set; }
        //[ForeignKey("UserId")]
        //public virtual User User { get; set; }

    }
}
