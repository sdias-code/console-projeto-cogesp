using System;
using System.Collections.Generic;
using System.Text;

namespace AppRelacionamento.Models
{
    class ContaModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int Agencia { get; set; }
        public int Numero { get; set; }
        public double Saldo { get; set; }
    }
}
