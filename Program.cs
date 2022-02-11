using System;

namespace DIO.PlayerMusica
{
    class Program
    {
        static MusicaRepository musicaRepositorio = new MusicaRepository();
		static PodcastRepository podcastRepositorio = new PodcastRepository();
        static void Main(string[] args)
        {
			string musicaPodcast = MusicaOuPodcast();

			while(musicaPodcast.ToUpper() != "X")
			{
				switch(musicaPodcast)
				{
					case "1":
						MusicPlayer();
						break;
					case "2":
						PodcastPlayer();
						break;
				}
			}

            
        }

        private static void PodcastPlayer()
        {
            string opcaoUsuario = ObterOpcaoUsuarioPodcast();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarPodcast();
						break;
					case "2":
						InserirPodcast();
						break;
					case "3":
						AtualizarPodcast();
						break;
					case "4":
						ExcluirPodcast();
						break;
					case "5":
						VisualizarPodcast();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuarioPodcast();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void MusicPlayer()
		{
			string opcaoUsuario = ObterOpcaoUsuarioMusica();

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
						AtualizarMusica();
						break;
					case "4":
						ExcluirMusica();
						break;
					case "5":
						VisualizarMusica();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuarioMusica();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

        
		private static string MusicaOuPodcast()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Player a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Player de Música");
			Console.WriteLine("2- Player de Podcast");

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}



		//MUSICA
        private static string ObterOpcaoUsuarioMusica()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Player de Música a seu dispor!!!");
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
                var excluido = musica.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", musica.retornaId(), musica.retornaTitulo(), (excluido ? "*Excluído*" : ""));
				//System.Console.WriteLine("#ID {0} - {1}", musica.retornaId(), musica.ToString());
			}
		}

        private static void InserirMusica()
		{
			musicaRepositorio.PopulaDados(1);
		}

		private static void AtualizarMusica()
		{
			musicaRepositorio.PopulaDados(2);
		}

		private static void ExcluirMusica()
		{
			Console.Write("Digite o id da música: ");
			int indiceMusica = int.Parse(Console.ReadLine());

			musicaRepositorio.Excluir(indiceMusica);
		}

		private static void VisualizarMusica()
		{
			Console.Write("Digite o id da música: ");
			int indiceMusica = int.Parse(Console.ReadLine());

			var musica = musicaRepositorio.RetornaPorId(indiceMusica);

			Console.WriteLine(musica);
		}

        






		//PODCAST

		private static string ObterOpcaoUsuarioPodcast()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Player de Podcast a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Podcasts");
			Console.WriteLine("2- Inserir novo Podcast");
			Console.WriteLine("3- Atualizar Podcast");
			Console.WriteLine("4- Excluir Podcast");
			Console.WriteLine("5- Visualizar Podcast");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		private static void ListarPodcast()
		{
			Console.WriteLine("Listar podcast");

			var lista = podcastRepositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma música cadastrada.");
				return;
			}

			foreach (var podcast in lista)
			{
                var excluido = podcast.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", podcast.retornaId(), podcast.retornaTitulo(), (excluido ? "*Excluído*" : ""));
				//System.Console.WriteLine("#ID {0} - {1}", musica.retornaId(), musica.ToString());
			}
		}

		 private static void InserirPodcast()
		{
			podcastRepositorio.PopulaDados(1);
		}

		private static void AtualizarPodcast()
		{
			podcastRepositorio.PopulaDados(2);
		}

		private static void ExcluirPodcast()
		{
			Console.Write("Digite o id do Podcast: ");
			int indicePodcast = int.Parse(Console.ReadLine());

			podcastRepositorio.Excluir(indicePodcast);
		}

		private static void VisualizarPodcast()
		{
			Console.Write("Digite o id do Podcast: ");
			int indicePodcast = int.Parse(Console.ReadLine());

			var podcast = podcastRepositorio.RetornaPorId(indicePodcast);

			Console.WriteLine(podcast);
		}
    }
}
