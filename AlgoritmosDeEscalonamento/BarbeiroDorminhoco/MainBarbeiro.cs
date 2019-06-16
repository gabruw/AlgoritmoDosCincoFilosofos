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

        public void AbrirBarbearia()
        {
            while (Clientes.Count() > 0)
            {
                

                if (VerificarCadeiraBarbeiro() == false && VerificarCadeirasVazias() == true)
                {
                    Console.WriteLine("O barbeiro está cortando o cabelo de um cliente...");

                    Barbeiro.Cadeira.EstaOcupada = true;

                    TempoEspera();

                    Barbeiro.Cadeira.EstaOcupada = false;
                }
                else if(VerificarCadeiraBarbeiro() == false && VerificarCadeirasVazias() == true)
                {
                    DesocuparCadeira();

                    Console.WriteLine("O barbeiro está cortando o cabelo de um cliente...");

                    Barbeiro.Cadeira.EstaOcupada = true;

                    TempoEspera();

                    Barbeiro.Cadeira.EstaOcupada = false;
                }
                else if(VerificarCadeiraBarbeiro() == true && VerificarCadeirasVazias() == true)
                {
                    OcuparCadeira();
                }
            }

            BarbeiroDorme();
        }

        public void ColocarCadeiras(int qtdCadeira)
        {
            var i = 0;

            while (i < qtdCadeira)
            {
                Cadeira newCadeira = new Cadeira();
                ListCadeira.Add(newCadeira);
            }
        }

        public void AdicionarClientes(int qtdCliente)
        {
            for (int i = 0; i < qtdCliente; i++)
            {
                Clientes[i] = i;
            }
        }

        public bool VerificarCadeiraBarbeiro()
        {
            if(Barbeiro.Cadeira.EstaOcupada == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificarBarbeiroDormindo()
        {
            if (Barbeiro.EstaDormindo == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificarCadeirasVazias()
        {
            foreach(var cadeira in ListCadeira)
            {
                if(cadeira.EstaOcupada == true)
                {
                    return true;
                }
            }

            return false;
        }

        public string VerificaCadeiras()
        {
            var count = 0;

            foreach (var cadeira in ListCadeira)
            {
                if (cadeira.EstaOcupada == true)
                {
                    count++;
                }
            }

            if(ListCadeira.Count == count)
            {
                Console.WriteLine("Todas as cadeirtas estam cheias.");
                Console.WriteLine("O cliente vai embora...");
            }
            else if ()
            {

            }
        }

        public void OcuparCadeira()
        {
            foreach (var cadeira in ListCadeira)
            {
                if (cadeira.EstaOcupada == false)
                {
                    cadeira.EstaOcupada = true;
                    break;
                }
            }
        }

        public void DesocuparCadeira()
        {
            foreach (var cadeira in ListCadeira)
            {
                if (cadeira.EstaOcupada == true)
                {
                    cadeira.EstaOcupada = false;
                    break;
                }
            }
        }

        public int TempoEspera()
        {
            return Rand.Next(2000, 5000);
        }

        public void ClienteEntra()
        {
            Console.WriteLine("Um cliente entrou na barbearia.");

            if(VerificarCadeirasVazias() == true)
            {
                OcuparCadeira();
            }
            else
            {

            }
        }

        public void BarbeiroDorme()
        {
            Console.WriteLine("O barbeiro está dormindo enquanto os clientes não chegam...");

            TempoEspera();

            Console.WriteLine("Deseja adicionar novos clientes? Y/N");
            Console.Write("->>");
            var ops = Console.ReadLine();

            Console.Clear();

            if (ops.ToLower().Equals("Y"))
            {
                Console.WriteLine("Quantas clientes vão a barbearia?");
                Console.Write("->>");

                var qtdCli = Int16.Parse(Console.ReadLine());
                Console.Clear();

                AdicionarClientes(qtdCli);
                AbrirBarbearia();
            }
        }
    }
}