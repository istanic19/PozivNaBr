using PozivNaBrojService.Model.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBrojService.Model.Validators
{
    public class HR28:BaseValidator
    {
        private MOD11INI _calculator;

        public HR28()
        {
            _calculator = new MOD11INI();
            _maxPodaciCount = 4;
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            if (_podaci.Count < 3)
            {
                Error = "Poziv na broj mora imati minimalno 3 podatka.";
                return false;
            }

            if (!_podaci[0].Validate(4, 4, _calculator))
                return false;

            if (!_podaci[1].Validate(3, 3, _calculator))
                return false;

            if (!_podaci[2].Validate(6, 6, _calculator))
                return false;

            if (_podaci.Count > 3)
            {
                if (!_podaci[3].Validate(6))
                    return false;
            }


            return true;
        }

        public override string Kreiraj()
        {
            if (_podaci.Count < 1)
                return string.Empty;

            var clone = new HR28();
            clone.PozivNaBroj = PozivNaBroj;

            if (clone._podaci[0].Broj.Length < 4)
            {
                var k = _calculator.Calculate(clone._podaci[0].Broj, false);
                clone._podaci[0].Broj = clone._podaci[0].Broj + k;
            }

            if (clone._podaci.Count > 1)
            {
                if (clone._podaci[1].Broj.Length < 3)
                {
                    var k1 = _calculator.Calculate(clone._podaci[1].Broj, false);
                    clone._podaci[1].Broj = clone._podaci[1].Broj + k1;
                }
            }

            if (clone._podaci.Count > 2)
            {
                if (clone._podaci[2].Broj.Length < 6)
                {
                    var k2 = _calculator.Calculate(clone._podaci[2].Broj, false);
                    clone._podaci[2].Broj = clone._podaci[2].Broj + k2;
                }
            }

            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
