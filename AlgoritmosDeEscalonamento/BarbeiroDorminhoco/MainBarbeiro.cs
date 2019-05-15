using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoritmosDeEscalonamento.BarbeiroDorminhoco
{
    public class MainBarbeiro
    {
        public static Barbeiro Barbeiro = new Barbeiro();

        public static List<Cadeira> ListCadeira = new List<Cadeira>();

        public static int[] Clientes;

        public static Random Rand = new Random();
    }
}