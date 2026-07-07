using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public interface IBookRepository
    {
        public void SaveBook(List<Book> books);
        public List<Book> LoadBook();
    }

    public interface IMemberRepository
    {
        public void SaveMember(List<Member> members);
        public List<Member> LoadMember();
    }
}
