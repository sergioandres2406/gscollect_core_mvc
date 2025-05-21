using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class AppService
{
    public string AppServiceId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public decimal ActivationPrice { get; set; }

    public decimal RecurringBasePrice { get; set; }

    public decimal RecurringUnitPrice { get; set; }

    public string? Unit { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<AppPlanService> AppPlanServices { get; set; } = new List<AppPlanService>();
}
