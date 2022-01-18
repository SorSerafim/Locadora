namespace Locadora.Domain
{
    public class Filme : Entidade
    {
        public string Nome { get; set; }
        public int Ano { get; set; }
        public int Duracao { get; set; }
        public virtual Diretor Diretor { get; set; }
        public int DiretorId { get; set; }
        public virtual Genero Genero { get; set; }
        public int GeneroId { get; set; }
    }
}
