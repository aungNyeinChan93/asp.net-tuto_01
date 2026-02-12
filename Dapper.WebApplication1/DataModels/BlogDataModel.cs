namespace Dapper.WebApplication1.DataModels
{
    public class BlogDataModel
    {
        public int BlogId { get; set; }

        public string? Title { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public string? AuthorName { get; set; } = string.Empty;

        public bool DeleteFlag { get; set;  } = false;
    }
}
