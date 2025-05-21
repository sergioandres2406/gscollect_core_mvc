using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class SalesOrder
{
    public int SaleOrderId { get; set; }

    public int SaleOrderNumber { get; set; }

    public int CustomerId { get; set; }

    public DateTime DateSold { get; set; }

    public DateTime CreationDate { get; set; }

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

    public string? Comments { get; set; }

    public virtual PersonCustomer Customer { get; set; } = null!;

    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; set; } = new List<SaleOrderLine>();

    public virtual ICollection<SaleOrderProjectedPayment> SaleOrderProjectedPayments { get; set; } = new List<SaleOrderProjectedPayment>();

    public virtual SaleOrderStatus? SaleOrderStatus { get; set; }

    public virtual SalesPerson? SalesPerson { get; set; }
}
