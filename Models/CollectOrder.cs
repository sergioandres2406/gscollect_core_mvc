using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class CollectOrder
{
    public int CollectOrderId { get; set; }

    public DateTime CollectDateFrom { get; set; }

    public DateTime CollectDateTo { get; set; }

    public int PaymentCollectorId { get; set; }

    public string? Reference { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? DateProcessed { get; set; }

    public virtual ICollection<CollectOrderLine> CollectOrderLines { get; set; } = new List<CollectOrderLine>();

    public virtual SalePaymentCollector PaymentCollector { get; set; } = null!;
}
