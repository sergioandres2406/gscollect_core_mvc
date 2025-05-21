using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class PersonContact
{
    public int PersonContactId { get; set; }

    public int PersonId { get; set; }

    public int ContactId { get; set; }

    public string Relationship { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
