using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library
{
    public class JsonBookRepo : IBookRepository
    {

        private const string _bookRepository = @"c:\temp\LibararyBooks.json";


        public void SaveBook(List<Book> book)
        {
            string json = JsonSerializer.Serialize(book, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_bookRepository, json);

        }

        public List<Book> LoadBook()
        {
            if (!File.Exists(_bookRepository) || new FileInfo(_bookRepository).Length == 0)
            {
                return new List<Book>();
            }


            return JsonSerializer.Deserialize<List<Book>>(File.ReadAllText(_bookRepository)) ?? new List<Book>();

        }

    }

    public class JsonMemberRepo : IMemberRepository
    {
        private const string _memberRepository = @"c:\temp\LibararyMembers.json";

        public void SaveMember(List<Member> member)
        {
            string json = JsonSerializer.Serialize(member, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_memberRepository, json);

        }

        public List<Member> LoadMember()
        {
            if (!File.Exists(_memberRepository) || new FileInfo(_memberRepository).Length == 0)
            {
                return new List<Member>();
            }


            return JsonSerializer.Deserialize<List<Member>>(File.ReadAllText(_memberRepository)) ?? new List<Member>();

        }
    }
}
