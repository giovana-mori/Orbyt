namespace Pi3.Dtos
{
    public class ResponseMovieDto
    {
        public int page { get; set; }
        public IEnumerable<MovieDto> Results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}

