using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// references: https://blogs.msdn.microsoft.com/msgulfcommunity/2013/03/13/understanding-the-basics-of-mvvm-design-pattern/
namespace mvvmSimpleImplement
{
    public class MainPageViewModel : BindableBase
    {
        private List<Book> books;
        public List<Book> Books
        {
            get
            {
                return books;
            }
            set
            {
                SetProperty(ref books, value);
            }
        }
        public MainPageViewModel()
        {
            Books = new List<Book>();
            Books.Add(new Book
            {
                Ttile = "harry potter",
                Author = "J. K. Rowling",
                Category = "Young-adult fiction",
                Language = "English"
            });
            Books.Add(new Book
            {
                Ttile = "written lives",
                Author = "javier marias",
                Category = "biography",
                Language = "Spanish"
            });
        }
    }
}
