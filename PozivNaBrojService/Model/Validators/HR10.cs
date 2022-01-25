using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBrojService.Model.Calculators;

namespace PozivNaBrojService.Model.Validators
{
    public class HR10 : BaseValidator
    {
        private MOD11INI _calculator;
        public HR10()
        {
            _calculator = new MOD11INI();
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            if (!_podaci[0].Validate(calculator: _calculator))
                return false;

            if (_podaci.Count == 3)
            {
                if (_podaci[2].Broj.StartsWith("0"))
                {
                    Error = $"Podatak 3 ne smije imati početne nule.";
                    return false;
                }
                var grupa = _podaci[1].Broj + _podaci[2].Broj;
                if (!_calculator.Check(grupa))
                {
                    Error = $"Pogreška {_calculator.GetName()} za grupu podataka 2 i 3.";
                    return false;
                }
            }
            else if (_podaci.Count == 2)
            {
                if (!_podaci[1].Validate(calculator: _calculator))
                    return false;
            }

            return true;

        }

        public override string Kreiraj()
        {

            var clone = new HR10();
            clone.PozivNaBroj = PozivNaBroj;
            
            var k = _calculator.Calculate(clone._podaci[0].Broj, false);
            clone._podaci[0].Broj = clone._podaci[0].Broj + k;

            if (clone._podaci.Count == 2)
            {
                var k1 = _calculator.Calculate(clone._podaci[1].Broj, false);
                clone._podaci[1].Broj = clone._podaci[1].Broj + k1;
            }
            else if (clone._podaci.Count == 3)
            {
                var grupa = clone._podaci[1].Broj + clone._podaci[2].Broj;
                var k1 = _calculator.Calculate(grupa, false);
                clone._podaci[2].Broj = clone._podaci[2].Broj + k1.ToString();

            }

            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
