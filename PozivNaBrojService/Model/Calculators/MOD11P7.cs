using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBrojService.Model.Calculators
{
    public class MOD11P7 : BaseCalculator
    {
        public override int Calculate(string broj, bool check = true)
        {
            var nums = broj.Select(c => int.Parse(c.ToString())).ToList();

            int mult = 1;
            int sum = 0;

            for (int i = nums.Count - 1; i >= 0; --i)
            {
                if (check && (i == nums.Count - 1))
                    continue;

                mult++;
                if (mult > 7)
                    mult = 2;

                sum += mult * nums[i];
            }

            sum = sum % 11;

            if (sum == 0)
                return 5;
            else if (sum == 1)
                return 0;
            else 
                return 11- sum;

        }

        public int GetRest(string broj)
        {
            var nums = broj.Select(c => int.Parse(c.ToString())).ToList();

            int mult = 1;
            int sum = 0;

            for (int i = nums.Count - 1; i >= 0; --i)
            {

                mult++;
                if (mult > 7)
                    mult = 2;

                sum += mult * nums[i];
            }

            sum = sum % 11;

            return sum;
        }

        public override string Create(string broj)
        {
            return broj + Calculate(broj).ToString();
        }

        public override bool Check(string broj)
        {
            if (!broj.StartsWith("3"))
                return false;
            var kz = Calculate(broj, true);

            if (broj.Last().ToString() == kz.ToString())
                return true;
            return false;
        }
    }
}
