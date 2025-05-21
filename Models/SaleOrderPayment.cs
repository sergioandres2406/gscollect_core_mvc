using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class SaleOrderPayment
{
    public int SaleOrderPaymentId { get; set; }

    public int SaleOrderProjectedPaymentId { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; }

    public DateTime CreationDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public int? PaymentCollectorId { get; set; }

    public DateTime? DatePaid { get; set; }

    public int? CollectOrderLineId { get; set; }

    public virtual CollectOrderLine? CollectOrderLine { get; set; }

    public virtual SalePaymentCollector? PaymentCollector { get; set; }

    public virtual SaleOrderProjectedPayment SaleOrderProjectedPayment { get; set; } = null!;
}
