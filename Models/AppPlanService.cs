using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class AppPlanService
{
    public string AppPlanServiceId { get; set; } = null!;

    public string AppPlanId { get; set; } = null!;

    public string? AppServiceId { get; set; }

    public string Name { get; set; } = null!;

    public decimal ActivationPrice { get; set; }

    public decimal RecurringBasePrice { get; set; }

    public decimal RecurringUnitPrice { get; set; }

    public string? Unit { get; set; }

    public int? MinUnits { get; set; }

    public int? MaxUnits { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual AppPlan AppPlan { get; set; } = null!;

    public virtual AppService? AppService { get; set; }
}
