using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class SaleOrderPaymentsView
{
    public int SaleOrderId { get; set; }

    public int SaleOrderNumber { get; set; }

    public int CustomerId { get; set; }

    public DateTime DateSold { get; set; }

    public int? SalesPersonId { get; set; }

    public int NumberOfPayments { get; set; }

    public int PaymentDayOfMonth { get; set; }

    public string Period { get; set; } = null!;

    public string? PaymentDayComments { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal? TotalPaid { get; set; }

    public decimal? Balance { get; set; }

    public DateTime? FirstDateOfPayment { get; set; }

    public decimal? DownPayment { get; set; }

    public decimal? TotalUnits { get; set; }

    public decimal? TotalUnitsRemoved { get; set; }

    public decimal? PaymentAmount { get; set; }

    public int? SaleOrderStatusId { get; set; }

    public int? SaleOrderProjectedPaymentId { get; set; }

    public int? SequenceNumber { get; set; }

    public decimal? ProjectedPaymentAmount { get; set; }

    public int? SaleOrderPaymentId { get; set; }

    public decimal? AmountPaid { get; set; }

    public DateTime? ProjectedPaymentDate { get; set; }

    public DateTime? PaymentDate { get; set; }

    public int? PaymentCollectorId { get; set; }

    public string? Collector { get; set; }
}
