﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pi3.Models
{
    public class Filme
    {
        [BsonId]
        [BsonElement("id"), BsonRepresentation(BsonType.ObjectId)]
        private string Id { get; set; }

        private string Nome { get; set; }

        private string Data { get; set; }

        private string Autor { get; set; }

        private string Genero { get; set; }

        private string Sinopse { get; set; }

        private string Trailer { get; set; }

        private List<Avaliacao> Avaliacao { get; set; } = new List<Avaliacao>();

        private bool Destaque { get; set; }

        private bool Lancamento { get; set; }


        public void AddListAvaliacao(Avaliacao avaliacao)
        {
            Avaliacao.Add(avaliacao);
        }

    }
}
