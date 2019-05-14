﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosDeEscalonamento
{
    public class Index
    {
        public static void Main(string[] args)
        {
            Index index = new Index();

            index.Opcoes();     
        }

        public void Opcoes()
        {
            MainFilosofos filosofos = new MainFilosofos();

            Console.Clear();
            Console.WriteLine("Qual algoritmo você deseja executar?");
            Console.WriteLine("1- Algoritmo dos Filósofos");
            Console.WriteLine("5- Sair");
            Console.Write("\n->>");

            var op = Console.ReadLine();
            Console.Clear();

            switch (op)
            {
                case "1":
                    Console.WriteLine("Quantas refeições você deseja servir?");
                    Console.Write("->>");

                    var qtdRef = Int16.Parse(Console.ReadLine());
                    Console.Clear();

                    filosofos.ServirJantar(qtdRef);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Digite uma opção válida!");
                    Console.ReadKey();
                    Console.Clear();

                    this.Opcoes();
                    break;
            }
        }
    }
}
