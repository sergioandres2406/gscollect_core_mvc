using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class CollectOrderLine
{
    public int CollectOrderLineId { get; set; }

    public int CollectOrderId { get; set; }

    public int SaleOrderProjectedPaymentId { get; set; }

    public decimal Amount { get; set; }

    public DateTime DateCreated { get; set; }

    public bool Planned { get; set; }

    public DateTime? DateProcessed { get; set; }

    public virtual CollectOrder CollectOrder { get; set; } = null!;

    public virtual ICollection<SaleOrderPayment> SaleOrderPayments { get; set; } = new List<SaleOrderPayment>();

    public virtual SaleOrderProjectedPayment SaleOrderProjectedPayment { get; set; } = null!;
}
