using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int ProductCategoryId { get; set; }

    public decimal? DefaultPrice { get; set; }

    public DateTime CreationDate { get; set; }

    public string? CreatedBy { get; set; }

    public bool IsActive { get; set; }

    public bool IsBuiltIn { get; set; }

    public virtual ProductCategory ProductCategory { get; set; } = null!;

    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; set; } = new List<SaleOrderLine>();
}
