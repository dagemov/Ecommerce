using System;
using System.Collections.Generic;

namespace Ecommerce.Model;

public partial class Sale
{
    public int Id { get; set; }

    public int? IdSale { get; set; }

    public decimal? Total { get; set; }

    public DateTime? DateBegin { get; set; }

    public virtual User? IdSaleNavigation { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
