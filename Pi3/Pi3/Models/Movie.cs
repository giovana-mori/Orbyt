using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Pi3.Models
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } 

        [BsonElement("IdTmdb")]
        public int IdTmdb { get; set; } 

        [BsonElement("Titulo")]
        public string Titulo { get; set; } = string.Empty; 

        [BsonElement("Sinopse")]
        public string Sinopse { get; set; } = string.Empty; 

        [BsonElement("DataLancamento")]
        public DateTime DataLancamento { get; set; }

        [BsonElement("Duracao")]
        public int Duracao { get; set; } 

        [BsonElement("MediaVotos")]
        public double MediaVotos { get; set; } 

        [BsonElement("ContagemVotos")]
        public int ContagemVotos { get; set; } 

        [BsonElement("CaminhoPoster")]
        public string CaminhoPoster { get; set; } = string.Empty; 

        [BsonElement("CaminhoBackdrop")]
        public string CaminhoBackdrop { get; set; } = string.Empty; 

        [BsonElement("Generos")]
        public List<string> Generos { get; set; } = new List<string>(); 

        [BsonElement("Trailers")]
        public List<Trailer> Trailers { get; set; } = new List<Trailer>(); 

        [BsonElement("Elenco")]
        public List<Ator> Elenco { get; set; } = new List<Ator>(); 

        [BsonElement("ComissaoTecnica")]
        public List<CrewMember> ComissaoTecnica { get; set; } = new List<CrewMember>();

        [BsonElement("Orcamento")]
        public long Orcamento { get; set; } 

        [BsonElement("Receita")]
        public long Receita { get; set; } 

        [BsonElement("Providers")]
        public List<Provider> Providers { get; set; } = new List<Provider>(); 

        [BsonElement("PalavrasChave")]
        public List<string> PalavrasChave { get; set; } = new List<string>(); 
    }
}

