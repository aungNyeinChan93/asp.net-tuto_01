namespace Ado.WebApplication1.DataModels
{
    public class BlogDataModel
    {
        public int BlogId { get; set; }

        public string? Title { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public string? AuthorName { get; set; } = null!;

        public bool DeleteFlag { get; set; }
    }
}
