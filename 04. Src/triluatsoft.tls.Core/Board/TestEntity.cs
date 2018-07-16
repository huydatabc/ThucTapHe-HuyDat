using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triluatsoft.tls.Board
{
    public class TestEntity
    {
        [Required]
        [Key]
        public int A { get; set; }
        public int B { get; set; }
    }
}
