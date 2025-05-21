using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class CollectOrderLinesView
{
    public int CollectOrderId { get; set; }

    public DateTime CollectDateFrom { get; set; }

    public DateTime CollectDateTo { get; set; }

    public int PaymentCollectorId { get; set; }

    public string? Reference { get; set; }

    public int CollectOrderLineId { get; set; }

    public int SaleOrderProjectedPaymentId { get; set; }

    public decimal Amount { get; set; }

    public DateTime DateCreated { get; set; }

    public bool Planned { get; set; }

    public int ProjectedPaymentSequenceNumber { get; set; }

    public int SaleOrderId { get; set; }

    public DateTime ProjectPaymentDate { get; set; }

    public int SaleOrderNumber { get; set; }

    public int CustomerId { get; set; }

    public DateTime? DateProcessed { get; set; }

    public DateTime? CollectOrderDateProcessed { get; set; }

    public decimal AmountPaid { get; set; }
}
