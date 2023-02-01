﻿using System.Reflection.PortableExecutable;

namespace Lab3_DB
{
    class Program
    {
        static void Main()
        {
            Book[] books = LoadData.ReadBooks("books.csv");
            Reader[] readers = LoadData.ReadReaders("readers.csv", "readerBooks.csv");
            //foreach(Reader reader in readers)
            //{
            //    Console.WriteLine(reader.ToString(books[19]));
            //    Console.WriteLine();
            //}
            //foreach(Book book in books)
            //{
            //    Console.WriteLine(book.ToString(books[19]));
            //    Console.WriteLine();
            //}
            //Console.WriteLine(Reader.ToString(readers, books[12]));
            Table.WriteTable(books, readers);
        }
    }
}