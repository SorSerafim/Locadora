using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Shared.ReadDto
{
    public class ReadDiretorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<ReadFilmeDto> Filmes { get; set; }
    }
}
