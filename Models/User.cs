using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public int UserGroupId { get; set; }
}
