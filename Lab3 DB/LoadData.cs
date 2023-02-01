﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_DB
{
    public static class LoadData
    {
        public static Book[] ReadBooks(string nameFile)
        {
            string[] lines = File.ReadAllLines(nameFile);
            Book[] books = new Book[lines.Length];

            for (int i = 0; i < books.Length; i++)
            {
                string[] line = lines[i].Split(';');
                CheckInputData.InputErrorRightCountColumns(line, 6, nameFile);
                CheckInputData.CheckInputBook(line);
                books[i] = new Book(int.Parse(line[0]), line[1], line[2], int.Parse(line[3]), int.Parse(line[4]), int.Parse(line[5]));
            }
            return books;
        }
        public static Reader[] ReadReaders(string nameFileReaders, string nameFileReadersBooks)
        {
            string[] linesReadersBooks = File.ReadAllLines(nameFileReadersBooks);

            string[] linesReaders = File.ReadAllLines(nameFileReaders);
            Reader[] readers = new Reader[linesReaders.Length];

            for (int i = 0; i < readers.Length; i++)
            {
                string[] line = linesReaders[i].Split(';');
                CheckInputData.InputErrorRightCountColumns(line, 3, nameFileReaders);
                CheckInputData.CheckInputReader(line);
                Dictionary<int, DateTime> dateTake = new Dictionary<int, DateTime>();
                Dictionary<int, DateTime> dateReturn = new Dictionary<int, DateTime>();
                for (int j = 0; j < linesReadersBooks.Length; j++)
                {

                    string[] lineDates = linesReadersBooks[j].Split(';');
                    CheckInputData.InputErrorRightCountColumns(lineDates, 4, nameFileReadersBooks);
                    CheckInputData.CheckInputRiderBooks(lineDates);
                    if (line[0] == lineDates[0])
                    {
                        int id = int.Parse(lineDates[1]);
                        dateTake[id] = DateTime.Parse(lineDates[2]);
                        dateReturn[id] = DateTime.Parse(lineDates[3]);
                    }
                }
                readers[i] = new Reader(int.Parse(line[0]), line[1], int.Parse(line[2]), dateTake, dateReturn);
            }
            return readers;
        }

    }
}
