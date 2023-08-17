using System;
using System.Collections.Generic;

namespace GeneratedDataAccess.Models2;

public partial class BookCopy
{
    public int Id { get; set; }

    public int? BookId { get; set; }

    public string? Status { get; set; }

    public string? CopyNumber { get; set; }

    public virtual Book? Book { get; set; }

    public virtual ICollection<BorrowedBook> BorrowedBooks { get; set; } = new List<BorrowedBook>();
}
