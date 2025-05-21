using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class SaleOrderLinesView
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

    public decimal? TotalPaid { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal? Balance { get; set; }

    public int? SaleOrderStatusId { get; set; }

    public string? SaleOrderStatus { get; set; }

    public int SaleOrderLineId { get; set; }

    public int ProductId { get; set; }

    public decimal Units { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal? Amount { get; set; }

    public string Product { get; set; } = null!;

    public string ProductCategory { get; set; } = null!;

    public decimal? DefaultPrice { get; set; }

    public int PersonId { get; set; }

    public long IdentifierNumber { get; set; }

    public string? Customer { get; set; }

    public string? CustomerAddress { get; set; }

    public string? CustomerAddress2 { get; set; }

    public string? CustomerMobilePhone { get; set; }

    public string? CustomerHomePhone { get; set; }

    public string? CustomerOfficePhone { get; set; }

    public string? CustomerCity { get; set; }

    public string? CustomerComments { get; set; }

    public string SalePerson { get; set; } = null!;
}
