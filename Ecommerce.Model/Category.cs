using System;
using System.Collections.Generic;

namespace Ecommerce.Model;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? DateBegin { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
