using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public long IdentifierNumber { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string? SecondLastName { get; set; }

    public string? FullName { get; set; }

    public string? Address { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? HomePhone { get; set; }

    public string? OfficePhone { get; set; }

    public string? MobilePhone { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? Comments { get; set; }

    public virtual ICollection<PersonContact> PersonContacts { get; set; } = new List<PersonContact>();

    public virtual ICollection<PersonCustomer> PersonCustomers { get; set; } = new List<PersonCustomer>();
}
