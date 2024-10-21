namespace Pi3.Models
{
    public class Avaliacao
    {
        public Guid Id { get; set; }

        public string Notas { get; set; }

        public List<string> Comentarios { get; set; } = new List<string>();

        public Boolean Curtida { get; set; }

        public void Comentario(string comentario)
        {
            Comentarios.Add(comentario);
        }
    }
}
