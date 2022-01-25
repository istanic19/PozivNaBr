using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBrojService.Helpers;
using PozivNaBrojService.Model.Calculators;

namespace PozivNaBrojService.Model.Validators
{
    public class HR06 : BaseValidator
    {
        private MOD11INI _calculator;
        public HR06()
        {
            _calculator = new MOD11INI();
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            if (!_podaci[0].Validate())
                return false;

            if (_podaci.Count == 2)
            {
                if (!_podaci[1].Validate(calculator:_calculator))
                    return false;
            }

            if (_podaci.Count == 3)
            {
                if (_podaci[2].Broj.StartsWith("0"))
                {
                    Error = $"Podatak 3 ne smije imati početne nule.";
                    return false;
                }

                var group = _podaci[1].Broj + _podaci[2].Broj;
                if (!_calculator.Check(group))
                {
                    Error = $"Pogreška {_calculator.GetName()} za grupu podataka 2 i 3.";
                    return false;
                }
            }

            return true;

        }

        public override string Kreiraj()
        {
            if (_podaci.Count < 2)
                return PozivNaBroj;

            var clone = new HR06();
            clone.PozivNaBroj = PozivNaBroj;

           
            if (clone._podaci.Count == 2)
            {
                var k1 = _calculator.Calculate(clone._podaci[1].Broj, false);
                clone._podaci[1].Broj = clone._podaci[1].Broj + k1;
            }

            if (clone._podaci.Count == 3)
            {
                var group = clone._podaci[1].Broj + clone._podaci[2].Broj;
                clone._podaci[2].Broj += _calculator.Calculate(group, false).ToString();
            }

            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
