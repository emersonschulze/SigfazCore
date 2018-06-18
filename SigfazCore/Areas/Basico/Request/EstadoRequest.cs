using System;

namespace SigfazCore.Areas.Basico.Request
{
    public class EstadoRequest
    {
           public Int32 EstadoId { get; set; }
           public String Nome { get; set; } 
           public String Sigla { get; set; } 
    }
}