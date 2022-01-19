using System.Text.Json.Serialization;

namespace Locadora.Shared.ReadDto
{
    public class ReadFilmeDto
    {
        public string Nome { get; set; }
        public int Ano { get; set; }
        public int Duracao { get; set; }
        public string Genero { get; set; }
    }
}
