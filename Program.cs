using System;
using System.Collections.Generic;
using System.IO;

namespace semigroups_with_3_elements
{
    class Program
    {
        private static string tables_path = "mult_tables.txt";
        private static string semigroups_path = "semigroups.txt";

        static void Main(string[] args)
        {
            List<Semigroup> semigroups = AssociativityChecker.GetSemigroups();
            WriteToFile(tables_path, semigroups);

            IsomorphismChecker.ReduceUpToIsomorphism(ref semigroups);
            WriteToFile(semigroups_path, semigroups);

            Console.WriteLine("done");
        }

        public static void WriteToFile(string path, List<Semigroup> semigroups)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                for(int i = 0; i < semigroups.Count; i++)
                {
                    writer.WriteLine($"___{i+1}___");
                    writer.WriteLine("");
                    writer.Write(semigroups[i].ToString());
                    writer.WriteLine("");
                }
               
            }
        }
    }  
}

