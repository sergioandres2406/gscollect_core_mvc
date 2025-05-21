using System;
using System.Collections.Generic;

namespace GSCollect_MVC.Models;

public partial class CollectOrderLinesAmountPaidView
{
    public int? CollectOrderLineId { get; set; }

    public decimal AmountPaid { get; set; }

    public int? NumberOfPayments { get; set; }
}
