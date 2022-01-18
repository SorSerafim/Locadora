namespace Locadora.Domain
{
    public class Diretor : Entidade
    {
        public string Nome { get; set; }
        public virtual List<Filme> Filmes { get; set; }
    }
}
