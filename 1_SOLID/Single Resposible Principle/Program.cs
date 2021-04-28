using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Single_Resposible_Principle
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        //public void Save(string filename)
        //{
        //    File.WriteAllText(filename, ToString());
        //}
    }

    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, j.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            Console.WriteLine(j);

            var persistence = new Persistence();
            var filename = Path.Combine(Directory.GetCurrentDirectory(), "journals.txt");
            persistence.SaveToFile(j, filename, true);
            Process.Start(filename);
        }
    }
}
