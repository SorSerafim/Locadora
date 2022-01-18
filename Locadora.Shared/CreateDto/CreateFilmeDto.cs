using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Shared
{
    public class CreateFilmeDto
    {
        public string Nome { get; set; }
        public int Ano { get; set; }
        public int Duracao { get; set; }
        public int DiretorId { get; set; }
        public int GeneroId { get; set; }
    }
}
