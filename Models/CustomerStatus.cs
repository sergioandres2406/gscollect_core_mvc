using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class CustomerStatus
{
    public int CustomerStatusId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<PersonCustomer> PersonCustomers { get; set; } = new List<PersonCustomer>();
}
