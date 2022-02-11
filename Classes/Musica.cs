using System;

namespace DIO.PlayerMusica
{
    public class Musica : EntidadeBase
    {
        //Atributos
        private string Titulo { get; set;}
        private DateTime Duracao {get; set;}
        private string Cantor {get; set;}
        private string Feat {get; set;}
        private int Ano { get; set;}
        private GeneroMusica Genero { get; set;}
        private bool Excluido {get; set;}


        public Musica(int id, GeneroMusica genero, string Titulo, string cantor, DateTime duracao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = Titulo;
            this.Duracao = duracao;
            this.Ano = ano;
            this.Cantor = cantor;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Duração: " + this.Duracao + Environment.NewLine;
            retorno += "Cantor: " + this.Cantor + Environment.NewLine;
            if(Feat != null || Feat != "")
                retorno += "Feat: " + this.Feat + Environment.NewLine;

            retorno += "Ano: " + this.Ano + Environment.NewLine;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaId()
        {
            return this.Id;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}