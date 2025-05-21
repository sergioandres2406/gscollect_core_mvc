using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class SaleOrderProjectedPayment
{
    public int SaleOrderProjectedPaymentId { get; set; }

    public int SequenceNumber { get; set; }

    public int SaleOrderId { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal Amount { get; set; }

    public virtual ICollection<CollectOrderLine> CollectOrderLines { get; set; } = new List<CollectOrderLine>();

    public virtual SalesOrder SaleOrder { get; set; } = null!;

    public virtual ICollection<SaleOrderPayment> SaleOrderPayments { get; set; } = new List<SaleOrderPayment>();
}
