using SigfazCore.Models;
using System.Collections.Generic;

namespace SigfazCore.Areas.Basico.Models
{
    public class Estado : Entidade
    {
        public Estado()
        {
            Cidades = new HashSet<Cidade>();
        }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public int CodigoIbge { get; set; }
        public virtual ICollection<Cidade> Cidades { get; set; }

    }
}
