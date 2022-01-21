using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBroj.Model.Calculators;

namespace PozivNaBroj.Model.Validators
{
    public class HR02 : BaseValidator
    {
        private MOD11INICalculator _calculator;
        public HR02()
        {
            _calculator = new MOD11INICalculator();
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            int poz = 0;
            foreach (var podatak in _podaci)
            {
                if (poz == 0)
                {
                    if (!podatak.Validate())
                        return false;
                }
                else
                {
                    if (!podatak.Validate(calculator: _calculator))
                        return false;
                }

                poz++;
            }

            return true;

        }

        public override string Kreiraj()
        {

            if (_podaci.Count < 2)
                return PozivNaBroj;

            var clone = new HR02();
            clone.PozivNaBroj = PozivNaBroj;

            var k= _calculator.Calculate(clone._podaci[1].Broj, false);
            clone._podaci[1].Broj = clone._podaci[1].Broj + k;

            if (clone._podaci.Count == 3)
            {
                var k2 = _calculator.Calculate(clone._podaci[2].Broj, false);
                clone._podaci[2].Broj = clone._podaci[2].Broj + k2;
            }

            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
