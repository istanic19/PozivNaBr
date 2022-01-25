using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBrojService.Model.Calculators;

namespace PozivNaBrojService.Model.Validators
{
    public class HR29: BaseValidator
    {
        private MOD11INI _calculator;

        public HR29()
        {
            _calculator = new MOD11INI();
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            if (_podaci.Count != 3)
            {
                Error = "Poziv na broj mora imati 3 podatka.";
                return false;
            }

            if (!_podaci[0].Validate(4, 4, _calculator))
                return false;

            if (!_podaci[1].Validate(calculator: _calculator))
                return false;

            if (!_podaci[2].Validate(calculator: _calculator))
                return false;


            return true;
        }

        public override string Kreiraj()
        {
            if (_podaci.Count < 1)
                return string.Empty;

            var clone = new HR29();
            clone.PozivNaBroj = PozivNaBroj;

            if (clone._podaci[0].Broj.Length < 4)
            {
                var k = _calculator.Calculate(clone._podaci[0].Broj, false);
                clone._podaci[0].Broj = clone._podaci[0].Broj + k;
            }

            if (clone._podaci.Count > 1)
            {
                if (clone._podaci[1].Broj.Length < 12)
                {
                    var k1 = _calculator.Calculate(clone._podaci[1].Broj, false);
                    clone._podaci[1].Broj = clone._podaci[1].Broj + k1;
                }
            }

            if (clone._podaci.Count > 2)
            {
                if (clone._podaci[2].Broj.Length < 12)
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
