using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBroj.Model.Calculators
{
    public class MOD10X : BaseCalculator
    {
        public override int Calculate(string broj, bool check = true)
        {
            var nums = broj.Select(c => int.Parse(c.ToString())).ToList();

            int mult = 2;
            int sum = 0;

            for (int i = nums.Count - 1; i >= 0; --i)
            {
                if (check && (i == nums.Count - 1))
                    continue;


                sum += mult * nums[i];

                if (mult == 1)
                    mult = 2;
                else
                    mult = 1;
            }

            sum = sum % 10;

            if (sum == 0)
                return 0;

            return 10 - sum;
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
