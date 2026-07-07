using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class LibraryService
    {

        private readonly IBookRepository _bookRepo;
        private readonly IMemberRepository _memberRepo;
        private List<Book> _books;
        private List<Member> _members;

        //Below is very imp, we need to use the Repo object but it should not be instantiated here and it shouldn't be passed for every service call.
        //This constructor helps to keep this fields updated while instantiate this class object.
        public LibraryService(IBookRepository bookRepo, IMemberRepository memberRepo)
        {
            _bookRepo = bookRepo;
            _memberRepo = memberRepo;
            _books = _bookRepo.LoadBook();
            _members = _memberRepo.LoadMember();
        }

        public void AddBook(string title, string author, int copies) //This method will be used to add both new book and returning borrowed book.
        {
            Book newBook = new Book();
            newBook.Author = author;
            newBook.Title = title;
            newBook.Copies = copies;


            _books.Add(newBook);
            _bookRepo.SaveBook(_books);


        }

        public void CreateMember(string name)
        {
            Member newMember = new();
            newMember.Name = name;
            newMember.MemberId = 5000 + _members.Count + 1;
            _members.Add(newMember);
            _memberRepo.SaveMember(_members);

        }


        public void LendBook(int memberId, Guid bookID)
        {
            if (_members.FirstOrDefault(m => m.MemberId == memberId) != null && _books.FirstOrDefault(b => b.BookId == bookID) != null)
            {

                Member member = _members.First(m => m.MemberId == memberId);
                Book book = _books.First(b => b.BookId == bookID);
                if (book.Copies > 0)
                {
                    member.BorrowedBooks.Add(book);
                    int copies = book.Copies - 1;
                    book.Copies = copies;
                    _bookRepo.SaveBook(_books);
                    _memberRepo.SaveMember(_members);

                }
                else
                {
                    _books.Remove(book);
                    Console.WriteLine($"There is no available copies of this {book.Title}");

                }



            }
            else
            {
                Console.WriteLine("Member Id or Book Id is invalid");
            }


        }

        public void ViewAvailableBooks()
        {
            foreach (var book in _books)
            {
                Console.WriteLine($"Title of the Book: {book.Title}");
                Console.WriteLine($"Title of the Book: {book.Author}");
                Console.WriteLine($"Book Id: {book.BookId}");
                Console.WriteLine($"Number of Copies: {book.Copies}");
                Console.WriteLine("==========================\n\n");
            }

        }

        public void ViewAllMembers()
        {
            foreach (var mem in _members)
            {
                Console.WriteLine($"Member Id: {mem.MemberId}");
                Console.WriteLine($"Member Name: {mem.Name}\n");
                List<Book> borrowedBooks = mem.BorrowedBooks;
                Console.WriteLine("Borrowed Books:");
                foreach (var b in borrowedBooks)
                {
                    Console.WriteLine($"Title: {b.Title}");
                    Console.WriteLine($"Author: {b.Author}");
                    Console.WriteLine("-------------------");
                }
                Console.WriteLine("==========================\n\n");
            }

        }



    }

}
