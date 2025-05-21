using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class SalesPaymentCollectorCommissionView
{
    public int SaleOrderNumber { get; set; }

    public DateTime DateSold { get; set; }

    public int NumberOfPayments { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal? Balance { get; set; }

    public DateTime? DatePaid { get; set; }

    public decimal? AmountPaid { get; set; }

    public int? PaymentCollectorId { get; set; }

    public string PaymentCollector { get; set; } = null!;

    public decimal CommissionPercentage { get; set; }

    public decimal? TotalPaid { get; set; }

    public decimal TotalPaidBySaleOrder { get; set; }

    public int SequenceNumber { get; set; }
}
