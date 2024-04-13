﻿using Gestor_de_Eventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gestor_de_Eventos.Views
{
    internal class SingletonViewMenus
    {
        private static SingletonViewMenus? _instanciaGlobal;
        private static readonly object lockObject = new();

        private SingletonViewMenus() {}

        public static SingletonViewMenus GetInstancia()
        {
            lock (lockObject)
            {
                if (_instanciaGlobal == null)
                {
                    _instanciaGlobal = new SingletonViewMenus();
                }
            }
            return _instanciaGlobal;
        }

        private int CapturaOpcaoDigitada()
        {
            int numero;
            string entrada;
            int quantidadeTentativas = 0;

            do
            {
                quantidadeTentativas++;
                if (quantidadeTentativas > 1)
                {
                    Console.WriteLine("Insira apenas números inteiros!");
                }
                Console.WriteLine("Escolha uma opção >>> ");
                entrada = Console.ReadLine()!;
                Console.WriteLine(" ");
            } while (!int.TryParse(entrada, out numero));

            return numero;
        }

        private string CapturaValorDigitado()
        {
            string valor;
            int quantidadeTentativas = 0;
            Console.WriteLine("Digite o novo valor para a opção escolhida");
            do
            {
                quantidadeTentativas++;
                if (quantidadeTentativas > 1)
                {
                    Console.WriteLine("O valor não pode ficar vazio");
                }
                Console.Write("Digite o valor >>> ");
                valor = Console.ReadLine()!;

            } while (string.IsNullOrEmpty(valor));

            return valor;
        }

        public int ObtemOpcoesMenuPrincipal()
        {
            Console.WriteLine("Escolha uma opção no menu abaixo");
            Console.WriteLine("1 - Cadastrar Evento");
            Console.WriteLine("2 - Pesquisar Itens Cadastrados");
            Console.WriteLine("3 - Editar Evento");
            Console.WriteLine("4 - Excluir Evento");
            Console.WriteLine("5 - Exportar Eventos");
            return CapturaOpcaoDigitada();
        }

        public int ObtemOpcoesMenuListarEventos()
        {
            Console.WriteLine("Escolha umas das opções abaixo para pesquisar");
            Console.WriteLine("1 - Pesquisar Eventos Por Período");
            Console.WriteLine("2 - Pesquisar Eventos Em Uma Data Específica");
            Console.WriteLine("3 - Pesquisar Contato Cadastrado");
            return CapturaOpcaoDigitada();
        }

        public Dictionary<int, string> ObtemOpcoesEditarEvento()
        {
            Console.WriteLine("Escolha o que deseja editar no evento");
            Console.WriteLine("1 - Título");
            Console.WriteLine("2 - Data Inicial");
            Console.WriteLine("3 - Data Final");
            Console.WriteLine("4 - Descrição");
            Console.WriteLine("5 - Quantidade Aproximada de Pessoas");
            Console.WriteLine("6 - Quantidade Prevista de Pessoas");
            Console.WriteLine("7 - Público Alvo");
            int numero = CapturaOpcaoDigitada();
            string valor = CapturaValorDigitado();

            Dictionary<int, string> dicionario = new Dictionary<int, string>();
            dicionario[numero] = valor;
            return dicionario;
        }

        public Dictionary<int, string> ObtemOpcoesEditarContato()
        {
            Console.WriteLine("Escolha o que deseja editar no contato");
            Console.WriteLine("1 - Cpf");
            Console.WriteLine("2 - Nome");
            Console.WriteLine("3 - Telefone");
            Console.WriteLine("4 - Email");
            int numero = CapturaOpcaoDigitada();
            string valor = CapturaValorDigitado();

            Dictionary<int, string> dicionario = new Dictionary<int, string>();
            dicionario[numero]  = valor;
            return dicionario;
        }
    }
}