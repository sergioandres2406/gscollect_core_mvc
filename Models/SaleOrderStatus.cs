using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class SaleOrderStatus
{
    public int SaleOrderStatusId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();
}
