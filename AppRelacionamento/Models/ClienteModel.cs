using System;
using System.Collections.Generic;
using System.Text;

namespace AppRelacionamento.Models
{
    class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
    }
}
