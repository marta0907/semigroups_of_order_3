using System;
using System.Collections.Generic;

namespace semigroups_with_3_elements
{
    public class Semigroup
    {
        private readonly int[,] multiplication_table;
        private  List<int[,]> isomorphic_tables;

        public int[,] Table => multiplication_table;

        public Semigroup(int[,] arr)
        {
            multiplication_table = arr;
        }

        public override string ToString()
        {
            string res = "*| 0 1 2 \n";
            res += "________\n";
            for (int i = 0; i < 3; i++)
            {
                res += $"{i}|";
                for (int j = 0; j < 3; j++)
                {
                    res += $" {multiplication_table[i,j]}";
                }
                res += "\n";
            }
            return res;
        }

        public bool IsIsomorphicTo(Semigroup semigroup)
        {
            if(isomorphic_tables is null)
            {
                isomorphic_tables = new List<int[,]>();
                int[] A = { 0, 1, 2 };
                Set(A, 0, 3);
            }

            for(int k = 0; k< isomorphic_tables.Count; k++)
            {
                var table = isomorphic_tables[k];
                var equal = CompareTables(table, semigroup.Table);
                if (equal) return equal;
            }
            return false;
        }


        private bool CompareTables(int[,] a, int[,] b)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (a[i, j] != b[i, j])
                        return false;
            return true;
        }



        private void Set(int[] a, int n, int l)
        {
            for (int i = 0; i < l; i++)
            {
                int j;
                for (j = 0; j < n; j++)
                    if (a[j] == i) break;
                if (j == n)
                {
                    a[n] = i;
                    if (n < l - 1)
                        Set(a, n + 1, l);
                    else
                    {
                        Dictionary<int, int> dict = new Dictionary<int, int>();

                        for (int k = 0; k < l; k++)
                        {
                            dict.Add(k, a[k]);
                        }
                        Map(dict);
                    }
                }
            }
        }

        private void Map(Dictionary<int, int> dict)
        {
            int[,] perm = new int[3, 3];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    perm[i, j] = multiplication_table[dict[i], dict[j]];


            int[,] map = new int[3, 3];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    map[i, j] = dict[perm[i, j]];

            isomorphic_tables.Add(map);
        }

    }
}
