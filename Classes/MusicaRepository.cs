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

        public void ExcluiK(int id)
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