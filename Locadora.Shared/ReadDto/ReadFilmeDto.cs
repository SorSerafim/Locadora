using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Shared.ReadDto
{
    public class ReadFilmeDto
    {
        public string Nome { get; set; }
        public int Ano { get; set; }
        public int Duracao { get; set; }
        public virtual ReadDiretorDto Diretor { get; set; }
        public virtual ReadGeneroDto Genero { get; set; }
    }
}
