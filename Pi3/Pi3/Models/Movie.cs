using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pi3.Models
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // ID gerado pelo MongoDB

        [BsonElement("IdTmdb")]
        public int IdTmdb { get; set; } // ID do TMDb

        [BsonElement("Titulo")]
        public string Titulo { get; set; } = string.Empty; // Título do filme

        [BsonElement("Sinopse")]
        public string Sinopse { get; set; } = string.Empty; // Sinopse

        [BsonElement("DataLancamento")]
        public DateTime DataLancamento { get; set; } // Data de lançamento

        [BsonElement("Duracao")]
        public int Duracao { get; set; } // Duração em minutos

        [BsonElement("MediaVotos")]
        public double MediaVotos { get; set; } // Média dos votos

        [BsonElement("ContagemVotos")]
        public int ContagemVotos { get; set; } // Contagem de votos

        [BsonElement("CaminhoPoster")]
        public string CaminhoPoster { get; set; } = string.Empty; // Caminho para o poster

        [BsonElement("CaminhoBackdrop")]
        public string CaminhoBackdrop { get; set; } = string.Empty; // Caminho para a imagem de fundo

        [BsonElement("Generos")]
        public List<string> Generos { get; set; } = new List<string>(); // Gêneros

        [BsonElement("Trailers")]
        public List<Trailer> Trailers { get; set; } = new List<Trailer>(); // Lista de trailers

        [BsonElement("Elenco")]
        public List<Ator> Elenco { get; set; } = new List<Ator>(); // Lista de atores

        [BsonElement("ComissaoTecnica")]
        public List<CrewMember> ComissaoTecnica { get; set; } = new List<CrewMember>(); // Lista de equipe técnica

        [BsonElement("Orcamento")]
        public long Orcamento { get; set; } // Orçamento do filme

        [BsonElement("Receita")]
        public long Receita { get; set; } // Receita do filme

        [BsonElement("Providers")]
        public List<Provider> Providers { get; set; } = new List<Provider>(); // Plataformas de onde assistir

        [BsonElement("PalavrasChave")]
        public List<string> PalavrasChave { get; set; } = new List<string>(); // Palavras-chave do filme
    }


    public class CrewMember
    {
        [BsonElement("Id")]
        public int Id { get; set; } // ID do membro da equipe no TMDb

        [BsonElement("Nome")]
        public string Nome { get; set; } = string.Empty; // Nome do membro da equipe

        [BsonElement("Cargo")]
        public string Cargo { get; set; } = string.Empty; // Função na equipe (ex: Diretor, Roteirista)

        [BsonElement("Departamento")]
        public string Departamento { get; set; } = string.Empty; // Departamento (ex: Direção, Roteiro)
    }
    
}

