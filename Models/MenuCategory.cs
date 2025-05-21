using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class MenuCategory
{
    public int MenuCategoryId { get; set; }

    public string? Name { get; set; }

    public virtual MenuItem? MenuItem { get; set; }
}
