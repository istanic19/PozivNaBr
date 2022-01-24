using PozivNaBroj.Model.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBroj.Model.Validators
{
    public class HR16:BaseValidator
    {
        private MOD11INICalculator _calculator;
        public HR16()
        {
            _calculator = new MOD11INICalculator();
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            if (_podaci.Count != 3)
                return false;

            int poz = 0;
            foreach (var podatak in _podaci)
            {
                if (poz == 0)
                {
                    if (!podatak.Validate(5, 5, _calculator))
                        return false;
                }
                else if (poz == 1)
                {
                    if (!podatak.Validate(4, 4, _calculator))
                        return false;
                }
                else
                {
                    if (!podatak.Validate(8, 8))
                        return false;
                }

                poz++;
            }

            return true;
        }

        public override string Kreiraj()
        {
            if (_podaci.Count < 1)
                return string.Empty;

            var clone = new HR16();
            clone.PozivNaBroj = PozivNaBroj;

            if (clone._podaci[0].Broj.Length < 5)
            {
                var k = _calculator.Calculate(clone._podaci[0].Broj, false);
                clone._podaci[0].Broj = clone._podaci[0].Broj + k;
            }

            if (clone._podaci.Count >= 2 && clone._podaci[1].Broj.Length<4)
            {
                var k1 = _calculator.Calculate(clone._podaci[1].Broj, false);
                clone._podaci[1].Broj = clone._podaci[1].Broj + k1;
            }

            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
