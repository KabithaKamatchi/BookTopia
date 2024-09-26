using System;

namespace BookTopia
{
    public class Book
    {
        public int BookId { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public DateTime DateOfPublication { get; set; }
    }
}