using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class AppAccount
{
    public string AppAccountId { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Status { get; set; }

    public string AdministratorId { get; set; } = null!;

    public string? CreditCardId { get; set; }

    public string? BillingMode { get; set; }

    public int? BillingDay { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual CreditCard? CreditCard { get; set; }
}
