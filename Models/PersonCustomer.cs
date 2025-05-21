using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class PersonCustomer
{
    public int PersonCustomerId { get; set; }

    public int PersonId { get; set; }

    public int? CustomerStatusId { get; set; }

    public virtual CustomerStatus? CustomerStatus { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();
}
