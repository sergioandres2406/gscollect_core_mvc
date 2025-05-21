using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class SaleOrderLine
{
    public int SaleOrderLineId { get; set; }

    public int SaleOrderId { get; set; }

    public int ProductId { get; set; }

    public decimal Units { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal? Amount { get; set; }

    public decimal? UnitsRemoved { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual SalesOrder SaleOrder { get; set; } = null!;
}
