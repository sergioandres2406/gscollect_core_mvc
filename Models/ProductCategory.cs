﻿using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class ProductCategory
{
    public int ProductCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
