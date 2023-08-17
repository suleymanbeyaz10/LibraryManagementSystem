using System;
using System.Collections.Generic;

namespace GeneratedDataAccess.Models2;

public partial class BorrowedBook
{
    public int Id { get; set; }

    public int BookCopyId { get; set; }

    public int MemberId { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime ReturnDate { get; set; }

    public virtual BookCopy BookCopy { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
