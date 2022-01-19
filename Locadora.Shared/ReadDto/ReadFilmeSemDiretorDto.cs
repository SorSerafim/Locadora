namespace Locadora.Shared.ReadDto
{
    public class ReadFilmeSemDiretorDto
    {
        public string Nome { get; set; }
        public int Ano { get; set; }
        public int Duracao { get; set; }
        public virtual ReadDiretorDto Diretor { get; set; }
        public virtual ReadGeneroDto Genero { get; set; }
    }
}
