using System;
using DIO.PlayerMusica.Enum;

namespace DIO.PlayerMusica
{
    public class Podcast : EntidadeBase
    {
        //Atributos
        private string Titulo { get; set;}
        private string Duracao {get; set;}
        private string Apresentador {get; set;}
        private string Feat {get; set;}
        private string Descricao { get; set;}
        private GeneroPodcast Genero { get; set;}
        private int Ano {get; set;}
        private bool Excluido {get; set;}

        public Podcast(int id, string titulo, string duracao, string apresentador, string feat, string descricao, GeneroPodcast genero, int ano)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Duracao = duracao;
            this.Apresentador = apresentador;
            this.Feat = feat;
            this.Descricao = descricao;
            this.Genero = genero;
            this.Ano = ano;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Duração: " + this.Duracao + Environment.NewLine;
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Apresentador: " + this.Apresentador + Environment.NewLine;
            if(Feat != null || Feat != "")
                retorno += "Feat: " + this.Feat + Environment.NewLine;

            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
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
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
    }
}