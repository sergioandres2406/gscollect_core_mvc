using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class Setting
{
    public string SettingId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
