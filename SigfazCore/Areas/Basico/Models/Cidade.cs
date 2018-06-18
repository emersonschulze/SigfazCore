using SigfazCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SigfazCore.Areas.Basico.Models
{
    public class Cidade : Entidade
    {
        public string Nome { get; set; }

        public virtual int EstadoId { get; set; }

        public virtual Estado Estado { get; set; }

    }
}
