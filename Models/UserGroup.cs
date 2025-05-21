using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class UserGroup
{
    public int UserGroupId { get; set; }

    public string Name { get; set; } = null!;

    public bool SystemAdministrator { get; set; }
}
