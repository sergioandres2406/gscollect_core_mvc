using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class BusinessUnit
{
    public int BusinessUnitId { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }
}
