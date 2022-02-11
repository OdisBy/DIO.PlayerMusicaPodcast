using System;

namespace DIO.PlayerMusica
{
    class Program
    {
        static MusicaRepository musicaRepositorio = new MusicaRepository();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarMusicas();
						break;
					case "2":
						InserirMusica();
						break;
					case "3":
						//AtualizarSerie();
						break;
					case "4":
						//ExcluirSerie();
						break;
					case "5":
						//VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();

            
        }

        

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar músicas");
			Console.WriteLine("2- Inserir nova música");
			Console.WriteLine("3- Atualizar música");
			Console.WriteLine("4- Excluir música");
			Console.WriteLine("5- Visualizar música");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

        


        private static void ListarMusicas()
		{
			Console.WriteLine("Listar músicas");

			var lista = musicaRepositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma música cadastrada.");
				return;
			}

			foreach (var musica in lista)
			{
                //var excluido = musica.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1}", musica.retornaId(), musica.retornaTitulo());//, (excluido ? "*Excluído*" : ""));
			}

            
		}

        private static void InserirMusica()
		{
			Console.WriteLine("Inserir nova música");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in GeneroMusica.GetValues(typeof(GeneroMusica)))
			{
				Console.WriteLine("{0}-{1}", i, GeneroMusica.GetName(typeof(GeneroMusica), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Lançamento: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite o Cantor da música: ");
			string entradaCantor = Console.ReadLine();

            System.Console.Write("Digite a duração da música: ");
            DateTime entradaDuracao = Convert.ToDateTime(Console.ReadLine());


			Musica novaMusica = new Musica(id: musicaRepositorio.ProximoId(),
										genero: (GeneroMusica)entradaGenero,
										Titulo: entradaTitulo,
										ano: entradaAno,
										cantor: entradaCantor,
                                        duracao: entradaDuracao);

			musicaRepositorio.Insere(novaMusica);
		}

        
    }
}
