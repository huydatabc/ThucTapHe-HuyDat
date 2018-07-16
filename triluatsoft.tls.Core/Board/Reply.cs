﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triluatsoft.tls.Board
{
    public class Reply : FullAuditedEntity
    {
        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }
        public string MediaPath { get; set; }
        public string FileExtension { get; set; }
        public long CreatorId { get; set; }
        public string PosterName { get; set; }
        //public int? CreatorId { get; set; }
        //[ForeignKey("CreatorId")]
        //public virtual Poster Poster { get; set; }

        public int? ThreadId { get; set; }
        [ForeignKey("ThreadId")]
        public virtual Thread Thread { get; set; }


    }
}
