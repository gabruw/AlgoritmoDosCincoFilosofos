namespace AlgoritmosDeEscalonamento.BarbeiroDorminhoco
{
    public class Barbeiro
    {
        public bool EstaDormindo { get; set; }
        public Cadeira Cadeira { get; set; }

        public Barbeiro()
        {
            EstaDormindo = false;
            Cadeira.EstaOcupada = false;
        }
    }
}