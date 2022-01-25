using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBrojService.Model.Calculators;

namespace PozivNaBrojService.Model.Validators
{
    public class HR05 : BaseValidator
    {
        private MOD11INI _calculator;
        private ISO7064MOD1110 _oibValidator;
        public HR05()
        {
            _calculator = new MOD11INI();
            _oibValidator = new ISO7064MOD1110();
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            if (!_podaci[0].Validate(calculator: _calculator))
                return false;

            if (_podaci.Count == 3)
            {
                if (!_podaci[2].Validate())
                    return false;
            }

            return true;

        }

        public override string Kreiraj()
        {

            if (_podaci.Count < 1)
                return PozivNaBroj;

            var clone = new HR05();
            clone.PozivNaBroj = PozivNaBroj;

            var k = _calculator.Calculate(clone._podaci[0].Broj, false);
            clone._podaci[0].Broj = clone._podaci[0].Broj + k;

           

            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
