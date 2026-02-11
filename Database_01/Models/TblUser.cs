using System;
using System.Collections.Generic;

namespace Database_01.Models;

public partial class TblUser
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;
}
