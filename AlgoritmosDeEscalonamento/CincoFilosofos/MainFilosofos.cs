using System;
using System.Threading;

namespace AlgoritmosDeEscalonamento
{
    public class MainFilosofos
    {
        public static Filosofo Filosofo1 = new Filosofo();
        public static Filosofo Filosofo2 = new Filosofo();
        public static Filosofo Filosofo3 = new Filosofo();
        public static Filosofo Filosofo4 = new Filosofo();
        public static Filosofo Filosofo5 = new Filosofo();

        public static Garfo Garfo1 = new Garfo();
        public static Garfo Garfo2 = new Garfo();
        public static Garfo Garfo3 = new Garfo();
        public static Garfo Garfo4 = new Garfo();
        public static Garfo Garfo5 = new Garfo();

        public static Random Rand = new Random();

        /// <summary>
        /// Executa o algoritmo
        /// </summary>
        public void ServirJantar(int qtdRef)
        {
            Index newIndex = new Index();

            Thread threadPrincipal = new Thread(new ThreadStart(Start));
            threadPrincipal.Start();

            for(var i = 0; i < qtdRef + 1; i++)
            {
                if (i != 0)
                {
                    Console.WriteLine(string.Format("<> {0}º Refeição:", i));
                }
                else
                {
                    Console.WriteLine("<> Os Filosofos sentam em suas cadeiras <>");
                }

                SituacaoDaMesa();

                if (qtdRef != i)
                {
                    Console.WriteLine(string.Format("Aguardando a {0}º Refeição...\n", i + 1));
                }

                Thread.Sleep(3000);
            }

            Console.WriteLine("\n<> Jantar Finalizado <>");
            Console.WriteLine("Tecle para voltar ao menu...");
            Console.ReadKey();

            newIndex.Opcoes();
        }

        /// <summary>
        /// Mostrará as mudanças da mesa
        /// </summary>
        public static void SituacaoDaMesa()
        {
            var situacaoFilosofo1 = Filosofo1.EstaPensando ? "PENSANDO" : "COMENDO";
            Console.WriteLine(string.Format("Filósofo 1 está: {0}", situacaoFilosofo1));

            var situacaoFilosofo2 = Filosofo2.EstaPensando ? "PENSANDO" : "COMENDO";
            Console.WriteLine(string.Format("Filósofo 2 está: {0}", situacaoFilosofo2));

            var situacaoFilosofo3 = Filosofo3.EstaPensando ? "PENSANDO" : "COMENDO";
            Console.WriteLine(string.Format("Filósofo 3 está: {0}", situacaoFilosofo3));

            var situacaoFilosofo4 = Filosofo4.EstaPensando ? "PENSANDO" : "COMENDO";
            Console.WriteLine(string.Format("Filósofo 4 está: {0}", situacaoFilosofo4));

            var situacaoFilosofo5 = Filosofo5.EstaPensando ? "PENSANDO" : "COMENDO";
            Console.WriteLine(string.Format("Filósofo 5 está: {0}", situacaoFilosofo5));

            Console.WriteLine("");
        }

        /// <summary>
        /// Gerência a ordem de execução dos filósofos
        /// </summary>
        public static void Start()
        {
            Thread threadFilosofo1 = new Thread(new ThreadStart(Filosofo1Come));
            Thread threadFilosofo2 = new Thread(new ThreadStart(Filosofo2Come));
            Thread threadFilosofo3 = new Thread(new ThreadStart(Filosofo3Come));
            Thread threadFilosofo4 = new Thread(new ThreadStart(Filosofo4Come));
            Thread threadFilosofo5 = new Thread(new ThreadStart(Filosofo5Come));

            while (true)
            {
                if (!threadFilosofo1.IsAlive)
                {
                    threadFilosofo1 = new Thread(new ThreadStart(Filosofo1Come));
                    threadFilosofo1.Start();
                }

                if (!threadFilosofo2.IsAlive)
                {
                    threadFilosofo2 = new Thread(new ThreadStart(Filosofo2Come));
                    threadFilosofo2.Start();
                }

                if (!threadFilosofo3.IsAlive)
                {
                    threadFilosofo3 = new Thread(new ThreadStart(Filosofo3Come));
                    threadFilosofo3.Start();
                }

                if (!threadFilosofo4.IsAlive)
                {
                    threadFilosofo4 = new Thread(new ThreadStart(Filosofo4Come));
                    threadFilosofo4.Start();
                }

                if (!threadFilosofo5.IsAlive)
                {
                    threadFilosofo5 = new Thread(new ThreadStart(Filosofo5Come));
                    threadFilosofo5.Start();
                }
            }
        }

        public static void Filosofo1Come()
        {
            if (Garfo1.EstaEmUso || Garfo5.EstaEmUso)
            {
                return;
            }

            Garfo1.EstaEmUso = true;
            Garfo5.EstaEmUso = true;

            var tempoComendo = Rand.Next(2000, 5000);

            Filosofo1.EstaPensando = false;
            Thread.Sleep(tempoComendo);
            Filosofo1.EstaPensando = true;

            Garfo1.EstaEmUso = false;
            Garfo5.EstaEmUso = false;
        }

        public static void Filosofo2Come()
        {
            if (Garfo1.EstaEmUso || Garfo2.EstaEmUso)
            {
                return;
            }

            Garfo1.EstaEmUso = true;
            Garfo2.EstaEmUso = true;

            var tempoComendo = Rand.Next(2000, 5000);

            Filosofo2.EstaPensando = false;
            Thread.Sleep(tempoComendo);
            Filosofo2.EstaPensando = true;

            Garfo1.EstaEmUso = false;
            Garfo2.EstaEmUso = false;
        }

        public static void Filosofo3Come()
        {
            if (Garfo2.EstaEmUso || Garfo3.EstaEmUso)
            {
                return;
            }

            Garfo2.EstaEmUso = true;
            Garfo3.EstaEmUso = true;

            var tempoComendo = Rand.Next(2000, 5000);

            Filosofo3.EstaPensando = false;
            Thread.Sleep(tempoComendo);
            Filosofo3.EstaPensando = true;

            Garfo2.EstaEmUso = false;
            Garfo3.EstaEmUso = false;
        }

        public static void Filosofo4Come()
        {
            if (Garfo3.EstaEmUso || Garfo4.EstaEmUso)
            {
                return;
            }

            Garfo3.EstaEmUso = true;
            Garfo4.EstaEmUso = true;

            var tempoComendo = Rand.Next(2000, 5000);

            Filosofo4.EstaPensando = false;
            Thread.Sleep(tempoComendo);
            Filosofo4.EstaPensando = true;

            Garfo3.EstaEmUso = false;
            Garfo4.EstaEmUso = false;
        }

        public static void Filosofo5Come()
        {
            if (Garfo4.EstaEmUso || Garfo5.EstaEmUso)
            {
                return;
            }

            Garfo4.EstaEmUso = true;
            Garfo5.EstaEmUso = true;

            var tempoComendo = Rand.Next(2000, 5000);

            Filosofo5.EstaPensando = false;
            Thread.Sleep(tempoComendo);
            Filosofo5.EstaPensando = true;

            Garfo4.EstaEmUso = false;
            Garfo5.EstaEmUso = false;
        }
    }
}