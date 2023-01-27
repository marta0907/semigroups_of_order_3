using System;
using System.Collections.Generic;

namespace semigroups_with_3_elements
{
    public static class IsomorphismChecker
    {
        public static void ReduceUpToIsomorphism(ref List<Semigroup> semigroups)
        {
            List<Semigroup> semigroups_to_remove = new List<Semigroup>();

            for (int i = 0; i < semigroups.Count; i++)
            {
                for (int j = i + 1; j < semigroups.Count; j++)
                {
                    if (semigroups_to_remove.Contains(semigroups[j]))
                        continue;
                    else
                    {
                        var res = semigroups[i].IsIsomorphicTo(semigroups[j]);
                        if (res)
                            semigroups_to_remove.Add(semigroups[j]);
                    }
                }
            }

            for (int i = 0; i < semigroups_to_remove.Count; i++)
            {
                semigroups.Remove(semigroups_to_remove[i]);
            }
        }
    }
}
