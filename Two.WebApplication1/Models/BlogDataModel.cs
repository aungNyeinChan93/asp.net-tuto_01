namespace Two.WebApplication1.Models
{
    public class BlogDataModel
    {
        public int BLogId { get; set; }

        public string? Title { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public string? AuthorName { get; set; } = string.Empty;

        public bool DeleteFlag { get; set; } = false;
    }
}
