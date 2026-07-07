using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Member
    {
        public string Name { get; set; } = string.Empty;

        public int MemberId { get; set; }
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();



    }
}
