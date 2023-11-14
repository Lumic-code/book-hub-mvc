namespace BookHub.Client.ViewModels
{
    public class BookItemViewModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? ISBN { get; set; }
        public string? Author { get; set; }
        public int TotalPages { get; set; }
        public string? Portrait { get; set; }
    }
}
