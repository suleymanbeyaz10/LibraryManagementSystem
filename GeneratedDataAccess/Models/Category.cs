using System;
using System.Collections.Generic;

namespace GeneratedDataAccess.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
}
