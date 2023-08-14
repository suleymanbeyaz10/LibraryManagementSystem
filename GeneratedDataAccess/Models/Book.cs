using System;
using System.Collections.Generic;

namespace GeneratedDataAccess.Models;

public partial class Book
{
    public int Id { get; set; }

    public int AuthorId { get; set; }

    public int PublisherId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime PublishDate { get; set; }

    public string Isbn { get; set; } = null!;

    public virtual Author Author { get; set; } = null!;

    public virtual ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();

    public virtual ICollection<BorrowedBook> BorrowedBooks { get; set; } = new List<BorrowedBook>();

    public virtual Publisher Publisher { get; set; } = null!;
}
