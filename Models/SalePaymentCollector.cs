using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class SalePaymentCollector
{
    public int SalePaymentCollectorId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Commission { get; set; }

    public virtual ICollection<CollectOrder> CollectOrders { get; set; } = new List<CollectOrder>();

    public virtual ICollection<SaleOrderPayment> SaleOrderPayments { get; set; } = new List<SaleOrderPayment>();
}
