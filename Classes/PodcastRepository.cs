using System;
using System.Collections.Generic;
using System.Linq;
using DIO.PlayerMusica.Enum;
using DIO.PlayerMusica.Interfaces;

namespace DIO.PlayerMusica
{
    public class PodcastRepository : IRepository<Podcast>
    {
        private List<Podcast> listaPodcast = new List<Podcast>();
        public void Atualiza(int id, Podcast entidade)
        {
            listaPodcast[id] = entidade;
        }

        public void Excluir(int id)
        {
            listaPodcast[id].Excluir();
        }

        public void Insere(Podcast entidade)
        {
            listaPodcast.Add(entidade);
        }

        public List<Podcast> Lista()
        {
            return listaPodcast;
        }

        public void PopulaDados(int AdicionaAtualiza)
        {
            switch (AdicionaAtualiza)
            {
                case 1:
                    Console.WriteLine("Inserir novo podcast");

                    // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
                    // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
                    foreach (int i in GeneroPodcast.GetValues(typeof(GeneroPodcast)))
                    {
                        Console.WriteLine("{0}-{1}", i, GeneroPodcast.GetName(typeof(GeneroPodcast), i));
                    }
                    Console.Write("Digite o gênero entre as opções acima: ");
                    int entradaGenero = int.Parse(Console.ReadLine());

                    Console.Write("Digite o Nome do Podcast: ");
                    string entradaTitulo = Console.ReadLine();

                    Console.Write("Digite o Ano de Lançamento: ");
                    int entradaAno = int.Parse(Console.ReadLine());

                    Console.Write("Digite o Apresentador do Podcast: ");
                    string entradaCantor = Console.ReadLine();

                    Console.Write("Participações: ");
                    string entradaFeat = Console.ReadLine();

                    System.Console.Write("Digite a duração do Podcast: ");
                    string entradaDuracao = Console.ReadLine();

                    System.Console.WriteLine("Digite a descrição do Podcast: ");
                    string entradaDescricao = Console.ReadLine();


                    Podcast novoPodcast = new Podcast(id: ProximoId(),
                                                genero: (GeneroPodcast)entradaGenero,
                                                titulo: entradaTitulo,
                                                ano: entradaAno,
                                                feat: entradaFeat,
                                                descricao: entradaDescricao,
                                                apresentador: entradaCantor,
                                                duracao: entradaDuracao);

                    Insere(novoPodcast);
                    return;

                case 2:
                    Console.Write("Digite o id do podcast: ");
                    int indiceMusica = int.Parse(Console.ReadLine());

                    // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
                    // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
                    foreach (int i in GeneroMusica.GetValues(typeof(GeneroMusica)))
                    {
                        Console.WriteLine("{0}-{1}", i, GeneroMusica.GetName(typeof(GeneroMusica), i));
                    }
                    Console.Write("Digite o gênero entre as opções acima: ");
                    int atualizaGenero = int.Parse(Console.ReadLine());

                    Console.Write("Digite o Nome da Música: ");
                    string atualizaTitulo = Console.ReadLine();

                    Console.Write("Digite o Ano de Lançamento: ");
                    int atualizaAno = int.Parse(Console.ReadLine());

                    Console.Write("Digite o Cantor da música: ");
                    string atualizaCantor = Console.ReadLine();

                    Console.Write("Feat da música: ");
                    string atualizaFeat = Console.ReadLine();

                    System.Console.Write("Digite a duração da música: ");
                    string atualizaDuracao = Console.ReadLine();

                    System.Console.WriteLine("Digite a descrição do Podcast: ");
                    string atualizaDescricao = Console.ReadLine();

                    Podcast atualizaPodcast = new Podcast(id: indiceMusica,
                                                genero: (GeneroPodcast)atualizaGenero,
                                                titulo: atualizaTitulo,
                                                ano: atualizaAno,
                                                apresentador: atualizaCantor,
                                                feat: atualizaFeat,
                                                descricao: atualizaDescricao,
                                                duracao: atualizaDuracao);
                    Atualiza(indiceMusica, atualizaPodcast);
                    return;


                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public int ProximoId()
        {
            return listaPodcast.Count();
        }

        public Podcast RetornaPorId(int id)
        {
            return listaPodcast[id];
        }
    }
}