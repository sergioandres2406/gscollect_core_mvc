using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class MenuItem
{
    public int MenuItemId { get; set; }

    public string Name { get; set; } = null!;

    public int MenuCategoryId { get; set; }

    public virtual MenuCategory MenuItemNavigation { get; set; } = null!;
}
