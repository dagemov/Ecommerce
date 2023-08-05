using System;
using System.Collections.Generic;

namespace Ecommerce.Model;

public partial class Product
{
    public int IdProducto { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? IdCategory { get; set; }

    public decimal? Price { get; set; }

    public decimal? OfertPrice { get; set; }

    public int? Quantity { get; set; }

    public string? Imagen { get; set; }

    public DateTime? DateBegin { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
