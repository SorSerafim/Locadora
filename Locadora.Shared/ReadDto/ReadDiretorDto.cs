namespace Locadora.Shared.ReadDto
{
    public class ReadDiretorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<ReadFilmeDto> Filmes { get; set; }
    }
}
