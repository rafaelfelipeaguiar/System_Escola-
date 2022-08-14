using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Escola.Models
{
    public class Curso
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CargaHoraria { get; set; }

        public string Descricao { get; set; }

        public string Turno { get; set; }
        public Escola Escola { get; set; } = new Escola();
    }
}
