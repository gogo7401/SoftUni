using System.Collections;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;
        public Library(params Book[] books)
        {
            this.books = books.ToList();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;

            private int currentIndex = -1;

            public LibraryIterator(List<Book> books)
            {
                Reset();
                this.books = books;
                //this.books = new SortedSet<Book>(books).ToList(); // za zadacha 3
                this.books.Sort(new BookComparator());  // za zadacha 4
            }

            public Book Current => books[currentIndex];

            object IEnumerator.Current => Current;

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                return ++currentIndex < books.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }
        }

    }

     
}
