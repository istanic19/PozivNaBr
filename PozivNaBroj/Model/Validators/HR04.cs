using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBroj.Model.Calculators;

namespace PozivNaBroj.Model.Validators
{
    public class HR04 : BaseValidator
    {
        private MOD11INICalculator _calculator;
        public HR04()
        {
            _calculator = new MOD11INICalculator();
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            for (int i = 0; i < _podaci.Count; ++i)
            {
                if (i == 1)
                {
                    if (!_podaci[i].Validate())
                        return false;
                }
                else
                {
                    if (!_podaci[i].Validate(calculator: _calculator))
                        return false;
                }

            }

            return true;

        }

        public override string Kreiraj()
        {

            var clone = new HR04();
            clone.PozivNaBroj = PozivNaBroj;

            var k = _calculator.Calculate(clone._podaci[0].Broj, false);
            clone._podaci[0].Broj = clone._podaci[0].Broj + k;

            
            if (clone._podaci.Count > 2)
            {
                var k2 = _calculator.Calculate(clone._podaci[2].Broj, false);
                clone._podaci[2].Broj = clone._podaci[2].Broj + k2;
            }

            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
