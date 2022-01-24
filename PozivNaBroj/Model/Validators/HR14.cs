using PozivNaBroj.Model.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBroj.Model.Validators
{
    public class HR14 : BaseValidator
    {
        private MOD10ZB _calculator;
        public HR14()
        {
            _calculator = new MOD10ZB();
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
                    if (!podatak.Validate(10, 10, _calculator))
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
            if (_podaci.Count < 1)
                return string.Empty;

            var clone = new HR14();
            clone.PozivNaBroj = PozivNaBroj;

            var k = _calculator.Calculate(clone._podaci[0].Broj, false);
            clone._podaci[0].Broj = clone._podaci[0].Broj + k;

            
            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
