using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class SalesPerson
{
    public int SalesPersonId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Commission { get; set; }

    public virtual ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();
}
