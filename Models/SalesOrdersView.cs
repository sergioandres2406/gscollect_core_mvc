using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class SalesOrdersView
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

    public int PersonId { get; set; }

    public long IdentifierNumber { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string? SecondLastName { get; set; }

    public string? Address { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? HomePhone { get; set; }

    public string? OfficePhone { get; set; }

    public string? MobilePhone { get; set; }

    public string? Comments { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal? TotalPaid { get; set; }

    public decimal? Balance { get; set; }

    public DateTime? FirstDateOfPayment { get; set; }

    public decimal? DownPayment { get; set; }

    public string? SalesPerson { get; set; }

    public decimal? TotalUnits { get; set; }

    public decimal? TotalUnitsRemoved { get; set; }

    public decimal? PaymentAmount { get; set; }

    public int? SaleOrderStatusId { get; set; }
}
