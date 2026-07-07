using Library;

IBookRepository bookRepository = new JsonBookRepo();
IMemberRepository memberRepository = new JsonMemberRepo();
LibraryService libraryService = new LibraryService(bookRepository, memberRepository);

Console.WriteLine("Hello, World!");

Console.WriteLine("Hello, The Librarian");
bool loop = true;
while (loop)
{
    Console.WriteLine("Please select from the following options");
    Console.WriteLine("1. Add Book");
    Console.WriteLine("2. Create a new Member Account");
    Console.WriteLine("3. View all available books");
    Console.WriteLine("4. Lend a book to a member");
    Console.WriteLine("5. Search for a book");
    Console.WriteLine("6. View all member details");
    Console.WriteLine("7. Exit");
    string? choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            Console.WriteLine("enter the title of the book: ");
            string? title = Console.ReadLine();
            Console.WriteLine("Enter the Author's name: ");
            string? author = Console.ReadLine();
            Console.WriteLine("Enter the number of copies: ");
            int copies = Convert.ToInt32(Console.ReadLine());
            libraryService.AddBook(title, author, copies);

            break;

        case "2":
            Console.WriteLine("Enter the name of the member: ");
            string? name = Console.ReadLine();
            libraryService.CreateMember(name);
            break;

        case "3":
            libraryService.ViewAvailableBooks();
            break;

        case "4":
            Console.WriteLine("See the available books and enter the Book Id: ");
            string? input = Console.ReadLine();
            Guid.TryParse(input, out Guid result);
            Console.WriteLine("Enter the member id: ");
            int memberId = Convert.ToInt32(Console.ReadLine());
            libraryService.LendBook(memberId, result);

            break;

        case "5":
            Console.WriteLine("This feature is not implemented");
            break;

        case "6":
            libraryService.ViewAllMembers();
            break;

        case "7":
            loop = false;
            Console.WriteLine("Exiting..");
            break;

    }

}


