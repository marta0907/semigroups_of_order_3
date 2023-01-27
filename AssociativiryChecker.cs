using System;
using System.Collections.Generic;

namespace semigroups_with_3_elements
{
    public static class AssociativityChecker
    {
        private static bool CheckAssosiativity(int[,] mult_table) 
        {
            /*| 0 1 2
             ________
            0 | a b c
            1 | d e f
            2 | g h i  */

            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        // check (jk)l = j(kl)
                        int a1 = mult_table[j, k];
                        int a2 = mult_table[a1, l];
                        int a3 = mult_table[k, l];
                        int a4 = mult_table[j, a3];
                        if (a2 != a4) return false;
                    }
                }
            }
            return true;
        }

        public static List<Semigroup> GetSemigroups()
        {
            List<Semigroup> semigroups = new List<Semigroup>();
            for (int a = 0; a < 3; a++)
                for (int b = 0; b < 3; b++)
                    for (int c = 0; c < 3; c++)
                        for (int d = 0; d < 3; d++)
                            for (int e = 0; e < 3; e++)
                                for (int f = 0; f < 3; f++)
                                    for (int g = 0; g < 3; g++)
                                        for (int h = 0; h < 3; h++)
                                            for (int i = 0; i < 3; i++)
                                            {
                
                                                int[,] mult_table = { { a, b, c }, { d, e, f }, { g, h, i } };
                                                var res = CheckAssosiativity(mult_table);
                                                if (res)
                                                {
                                                    Semigroup semigroup = new Semigroup(mult_table);
                                                    semigroups.Add(semigroup);
                                                }

                                            }
                                        
            return semigroups;
        }

    }
}
