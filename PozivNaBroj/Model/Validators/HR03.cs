using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBroj.Model.Calculators;

namespace PozivNaBroj.Model.Validators
{
    public class HR03 : BaseValidator
    {
        private MOD11INI _calculator;
        public HR03()
        {
            _calculator = new MOD11INI();
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            foreach (var podatak in _podaci)
            {
                if (!podatak.Validate(calculator: _calculator))
                    return false;
            }

            return true;

        }

        public override string Kreiraj()
        {

            var clone = new HR03();
            clone.PozivNaBroj = PozivNaBroj;

            if (clone._podaci.Count > 0)
            {
                var k = _calculator.Calculate(clone._podaci[0].Broj, false);
                clone._podaci[0].Broj = clone._podaci[0].Broj + k;
            }


            if (clone._podaci.Count > 1)
            {
                var k1 = _calculator.Calculate(clone._podaci[1].Broj, false);
                clone._podaci[1].Broj = clone._podaci[1].Broj + k1;
            }

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
