using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class CreditCard
{
    public string CreditCardId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Metadata { get; set; } = null!;

    public string Expiration { get; set; } = null!;

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? PhoneNumber { get; set; }

    public string Email { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<AppAccount> AppAccounts { get; set; } = new List<AppAccount>();
}
