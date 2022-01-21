using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBroj.Model.Calculators
{
    public class MOD11JMBJMBG: BaseCalculator
    {
        public override int Calculate(string broj, bool check = true)
        {
            var nums = broj.Select(c => int.Parse(c.ToString())).ToList();

            int mult = 1;
            int sum = 0;

            for (int i = nums.Count - 2; i >= 0; --i)
            {
                mult++;
                if (mult > 7)
                    mult = 2;

                sum += mult * nums[i];
            }

            sum = sum % 11;

            if (sum != 0)
                return 11 - sum;

            return sum;
        }

        public override string Create(string broj)
        {
            return broj + Calculate(broj).ToString();
        }

        public override bool Check(string broj)
        {
            var kz = Calculate(broj, true);

            if (broj.Last().ToString() == kz.ToString())
                return true;
            return false;
        }
    }
}
