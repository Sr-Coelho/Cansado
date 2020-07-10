using System;
using System.Collections.Generic;
using System.Text;

namespace Cansado.Tables
{
    public class TableDeRegistro
    {
        public Guid IdUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
        public int Idade {get;set;}
    }
}
