using System;
using System.Collections.Generic;

namespace Ecommerce.Model;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LasName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Rol { get; set; }

    public DateTime? DateBegind { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
