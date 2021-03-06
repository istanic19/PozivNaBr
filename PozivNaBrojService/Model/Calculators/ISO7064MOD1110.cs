using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBrojService.Model.Calculators
{
    public class ISO7064MOD1110 : BaseCalculator
    {
        public override int Calculate(string broj, bool check = true)
        {
            var nums = broj.Select(c => int.Parse(c.ToString())).ToList();

            int ostatak = 10;

            for (int i = 0; i < nums.Count; i++)
            {
                if (check && (i == nums.Count - 1))
                    continue;

                int znamenka = nums[i] + ostatak;

                int meduostatak = znamenka % 10;
                if (meduostatak == 0)
                    meduostatak = 10;

                meduostatak *= 2;

                ostatak = meduostatak % 11;
            }

            int kontrolni = 11 - ostatak;
            if (kontrolni == 10)
                kontrolni = 0;

            return kontrolni;
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
