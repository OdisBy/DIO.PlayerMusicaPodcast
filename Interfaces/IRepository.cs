using System.Collections.Generic;

namespace DIO.PlayerMusica.Interfaces
{
    public interface IRepository<T>
    {
         List<T> Lista();
         T RetornaPorId(int id);
         void Insere(T entidade);
         void Excluir(int id);
         void Atualiza(int id, T entidade);
         int ProximoId();
         void PopulaDados(int AdicionaAtualiza);
    }
}