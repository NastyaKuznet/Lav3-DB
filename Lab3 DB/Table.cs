using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_DB
{
    public static class Table
    {
        public static void WriteTable(Book[] books, Reader[] readers)
        {
            string[][] tableContents = CollectTableContents(books, readers);
            int[] widthColumns = FindWidthColumns(tableContents);
            string[][] straightTableContents = AlignColumns(tableContents, widthColumns);
            OutputTable(straightTableContents);
        }

        private static string[][] CollectTableContents(Book[] books, Reader[] readers)
        {
            string[][] result = new string[books.Length + 1][];
            result[0] = new string[4] { "Автор", "Название", "Читает", "Взял" };
            for (int i = 1; i <= books.Length; i++)
            {
                Book book = books[i - 1];
                result[i] = AssembleString(book, readers);
            }
            return result;
        }
        private static string[] AssembleString(Book book, Reader[] readers)
        {
            foreach (Reader reader in readers)
            {
                if (reader.DateTake.ContainsKey(book.Id))
                {
                    return new string[4] { book.FullNameWriter, book.Name, reader.FullName, reader.DateTake[book.Id].ToString("d") };
                }
            }
            return new string[4] { book.FullNameWriter, book.Name, "", "" };
        }
        private static int[] FindWidthColumns(string[][] tableContents)
        {
            int[] widthColumns = new int[4];
            foreach (string[] line in tableContents)
            {
                for (int i = 0; i < 4; i++)
                {
                    string tableCell = line[i];
                    if (tableCell.Length > widthColumns[i])
                    {
                        widthColumns[i] = tableCell.Length;
                    }
                }
            }
            return widthColumns;
        }
        private static string[][] AlignColumns(string[][] tableContents, int[] widthColumns)
        {
            string[][] results = new string[tableContents.Length][];
            for (int indLine = 0; indLine < tableContents.Length; indLine++)
            {
                results[indLine] = new string[4];
                for (int indCell = 0; indCell < 4; indCell++)
                {
                    StringBuilder result = new StringBuilder();
                    result.Append(tableContents[indLine][indCell]);
                    for (int j = 0; j < widthColumns[indCell] - tableContents[indLine][indCell].Length; j++)
                    { 
                        result.Append(" ");
                    }
                    results[indLine][indCell] = result.ToString();  
                }
            }
            return results;
        }
        private static void OutputTable(string[][] straightTableContents)
        {
            for (int indLine = 0; indLine < straightTableContents.Length; indLine++)
            {
                Console.WriteLine($"|{String.Join("|", straightTableContents[indLine])} |");
                if(indLine == 0)
                {
                    PrintHorizontal(straightTableContents[indLine]);
                }
            }
        }
        private static void PrintHorizontal(string[] line)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.Write("|");
                for (int j = 0; j < line[i].Length; j++)
                {
                    Console.Write("-");
                }
            }
            Console.WriteLine(" |");
        }
    }
}
