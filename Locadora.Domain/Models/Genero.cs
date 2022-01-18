namespace Locadora.Domain
{
    public class Genero : Entidade
    {
        public string Nome { get; set; } 
        public virtual List<Filme> Filmes { get; set; }
    }
}
