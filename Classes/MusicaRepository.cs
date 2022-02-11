using System;
using System.Collections.Generic;
using DIO.PlayerMusica.Interfaces;

namespace DIO.PlayerMusica
{
    public class MusicaRepository : IRepository<Musica>
    {
        private List<Musica> listaMusica = new List<Musica>();
        public void Atualiza(int id, Musica entidade)
        {
            listaMusica[id] = entidade;
        }

        public void Excluir(int id)
        {
            listaMusica[id].Excluir();
        }

        public void Insere(Musica entidade)
        {
            listaMusica.Add(entidade);
        }

        public List<Musica> Lista()
        {
            return listaMusica;
        }

        public void PopulaDados(int AdicionaAtualiza)
        {
            switch (AdicionaAtualiza)
            {
                case 1:
                    Console.WriteLine("Inserir nova música");

                    // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
                    // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
                    foreach (int i in GeneroMusica.GetValues(typeof(GeneroMusica)))
                    {
                        Console.WriteLine("{0}-{1}", i, GeneroMusica.GetName(typeof(GeneroMusica), i));
                    }
                    Console.Write("Digite o gênero entre as opções acima: ");
                    int entradaGenero = int.Parse(Console.ReadLine());

                    Console.Write("Digite o Nome da Música: ");
                    string entradaTitulo = Console.ReadLine();

                    Console.Write("Digite o Ano de Lançamento: ");
                    int entradaAno = int.Parse(Console.ReadLine());

                    Console.Write("Digite o Cantor da música: ");
                    string entradaCantor = Console.ReadLine();

                    Console.Write("Feat da música: ");
                    string entradaFeat = Console.ReadLine();

                    System.Console.Write("Digite a duração da música: ");
                    string entradaDuracao = Console.ReadLine();


                    Musica novaMusica = new Musica(id: ProximoId(),
                                                genero: (GeneroMusica)entradaGenero,
                                                Titulo: entradaTitulo,
                                                ano: entradaAno,
                                                cantor: entradaCantor,
                                                duracao: entradaDuracao);

                    Insere(novaMusica);
                    return;

                case 2:
                    Console.Write("Digite o id da música: ");
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

                    Musica atualizaMusica = new Musica(id: indiceMusica,
                                                genero: (GeneroMusica)atualizaGenero,
                                                Titulo: atualizaTitulo,
                                                ano: atualizaAno,
                                                cantor: atualizaCantor,
                                                duracao: atualizaDuracao);
                    Atualiza(indiceMusica, atualizaMusica);
                    return;


                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public int ProximoId()
        {
            return listaMusica.Count;
        }

        public Musica RetornaPorId(int id)
        {
            return listaMusica[id];
        }
    }
}