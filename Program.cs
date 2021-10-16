﻿using System;

namespace Series
{
    class Program
    {
        static SRepositorio repositorio = new SRepositorio();
        static void Main(string[] args)
        {
            string Usuario = ObterUsuario();

			while (Usuario.ToUpper() != "X")
			{
				switch (Usuario)
				{
					case "1":
						ListarASeries();
						break;
					case "2":
						InserirASerie();
						break;
					case "3":
						AtualizarASerie();
						break;
					case "4":
						ExcluirASerie();
						break;
					case "5":
						VisualizarASerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				Usuario = ObterUsuario();
			}

			Console.WriteLine("Cadastrado com sucesso");
			Console.ReadLine();
        }

        private static void ExcluirSerie()
		{
			Console.Write("Escreva o ID da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite qual o gênero ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano do lançamento: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a sinopse: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a sinopse: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

        private static string ObterUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Séries Disponivel!");
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine("1- Listar às séries");
			Console.WriteLine("2- Inserir uma nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
