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
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
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

		private static void AtualizarSerie()
		{
			musicaRepositorio.PopulaDados(2);
		}

		private static void ExcluirSerie()
		{
			Console.Write("Digite o id da música: ");
			int indiceMusica = int.Parse(Console.ReadLine());

			musicaRepositorio.Excluir(indiceMusica);
		}

		private static void VisualizarSerie()
		{
			Console.Write("Digite o id da música: ");
			int indiceMusica = int.Parse(Console.ReadLine());

			var musica = musicaRepositorio.RetornaPorId(indiceMusica);

			Console.WriteLine(musica);
		}

        
    }
}
