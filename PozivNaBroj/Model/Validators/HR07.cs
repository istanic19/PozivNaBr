using PozivNaBroj.Model.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBroj.Model.Validators
{
    public class HR07 : BaseValidator
    {
        private MOD11INI _calculator;
        public HR07()
        {
            _calculator = new MOD11INI();
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            int poz = 0;
            foreach (var podatak in _podaci)
            {
                if (poz == 1)
                {
                    if (!podatak.Validate(calculator: _calculator))
                        return false;
                }
                else
                {
                    if (!podatak.Validate())
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

            var clone = new HR07();
            clone.PozivNaBroj = PozivNaBroj;


            if (clone._podaci.Count >=2)
            {
                var k1 = _calculator.Calculate(clone._podaci[1].Broj, false);
                clone._podaci[1].Broj = clone._podaci[1].Broj + k1;
            }

            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
