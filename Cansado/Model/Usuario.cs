using System;
using System.Collections.Generic;
using System.Text;

namespace Cansado.Model
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
        public static bool EstaAutenticado { get; set; }
        public string IdUsuario { get; set; }

        public Usuario()
        {

        }
    }
}
