using System;
using System.Collections.Generic;

namespace Database_01.Models;

public partial class TblBlog
{
    public int BlogId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string AuthorName { get; set; } = null!;

    public bool DeleteFlag { get; set; }
}
