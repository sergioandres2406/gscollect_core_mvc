using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class AppPlan
{
    public string AppPlanId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Type { get; set; }

    public string Description { get; set; } = null!;

    public DateTime? StartDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<AppPlanService> AppPlanServices { get; set; } = new List<AppPlanService>();
}
