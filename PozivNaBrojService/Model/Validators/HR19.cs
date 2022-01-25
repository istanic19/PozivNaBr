using PozivNaBrojService.Model.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBrojService.Model.Validators
{
    public class HR19:BaseValidator
    {
        private MOD11INI _calculator;
        private ISO7064MOD1110 _oibCalculator;
        public HR19()
        {
            _calculator = new MOD11INI();
            _oibCalculator = new ISO7064MOD1110();
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            if (_podaci.Count != 2)
            {
                Error = "Poziv na broj mora imati 2 podatka.";
                return false;
            }

            if (!_podaci[0].Validate(10, calculator: _calculator))
                return false;

            if (!_podaci[1].Validate(11, 11, calculator: _oibCalculator))
                return false;

            return true;

        }

        public override string Kreiraj()
        {
            if (_podaci.Count < 1)
                return string.Empty;

            var clone = new HR19();
            clone.PozivNaBroj = PozivNaBroj;

            var k = _calculator.Calculate(clone._podaci[0].Broj, false);
            clone._podaci[0].Broj = clone._podaci[0].Broj + k;

            if (clone._podaci.Count > 1)
            {
                var k1 = _oibCalculator.Calculate(clone._podaci[1].Broj, false);
                clone._podaci[1].Broj = clone._podaci[1].Broj + k1;
            }

            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}

