using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Interview
{
    public class BitQns
    {
        public static int CountSmallestSubSetForMaxBitWiseOR(params int[] n)
        {
            var c = 0;

            var map = new Dictionary<int, List<int>>();

            n.ToList().ForEach(x =>
            {
                var i = x;
                var power = 0;
                while (i > 0)
                {
                    if (i % 2 == 1)
                    {
                        if (!map.ContainsKey(x))
                        {
                            map.Add(x, new List<int>());
                        }
                        if(!map[x].Contains(power))
                            map[x].Add(power);
                    }
                    power++;
                    i /= 2;
                }
            });

            var groups = map.OrderByDescending(x => x.Value.Count()).Select(x => x.Value).ToList();

            var powers = new HashSet<int>();
            int oldCount = 0;
            groups.ForEach(x =>
            {
                x.ForEach(y =>
                {
                    powers.Add(y);
                });

                if (oldCount < powers.Count)
                {
                    oldCount = powers.Count;
                    c++;
                }
            });

            return c;
        }

        public enum Allergen
        {
            Eggs = 1,
            Peanuts = 2,
            Shellfish = 4,
            Strawberries = 8,
            Tomatoes = 16,
            Chocolate = 32,
            Pollen = 64,
            Cats = 128
        }

        public class Allergies
        {
            int _mask = 0;
            public Allergies(int mask)
            {
                _mask = mask;
            }

            public bool IsAllergicTo(Allergen allergen)
            {
                int bitwiseAnd = _mask & (int)allergen;
                return bitwiseAnd == (int)allergen;
            }

            public Allergen[] List()
            {
                Allergen[] allergens = (Allergen[])Enum.GetValues(typeof(Allergen));
                return allergens.Where(aller => IsAllergicTo(aller)).Select(aller => aller).ToArray();
            }
        }
    }
}
