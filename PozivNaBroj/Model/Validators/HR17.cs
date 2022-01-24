using PozivNaBroj.Model.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBroj.Model.Validators
{
    public class HR17:BaseValidator
    {
        private ISO7064MOD1110 _calculator;

        public HR17()
        {
            _calculator = new ISO7064MOD1110();
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
            if (_podaci.Count < 1)
                return string.Empty;

            var clone = new HR17();
            clone.PozivNaBroj = PozivNaBroj;

            var k = _calculator.Calculate(clone._podaci[0].Broj, false);
            clone._podaci[0].Broj = clone._podaci[0].Broj + k;


            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
