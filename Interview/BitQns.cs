using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Interview
{
    public class BitQns
    {
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
