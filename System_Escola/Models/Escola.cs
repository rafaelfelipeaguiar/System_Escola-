using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Escola.Models
{
    public class Escola
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Razao { get; set; }

        public string Cnpj { get; set; }

        public string Inscricao { get; set; }

        public string _tipo;
        public string Tipo => _tipo;
        public void SetTipo(bool t)
        {
            _tipo = t ? "Público" : "Privado";
        }

        public DateTime? Data { get; set; }

        public string Responsavel { get; set; }

        public string TelefoneResponsavel { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Rua { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Complemento { get; set; }

        public string Cep { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }
    }
}
