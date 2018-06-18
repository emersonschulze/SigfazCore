using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SigfazCore.Models
{
    public class Entidade
    {
        [Key]
        public virtual int ID { get; set; }
    }
}
