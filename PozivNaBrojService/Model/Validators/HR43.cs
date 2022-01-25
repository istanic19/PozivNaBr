using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBrojService.Model.Calculators;

namespace PozivNaBrojService.Model.Validators
{
    public class HR43:BaseValidator
    {
        private MOD11INI _calculator;
        public HR43()
        {
            _calculator = new MOD11INI();
            _maxPodaciCount = 4;
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            if (_podaci.Count != 4)
            {
                Error = "Poziv na broj mora imati 4 podatka.";
                return false;
            }

            if (!_podaci[0].Validate(3, 3))
                return false;

            if (!_podaci[1].Validate(8,8,calculator: _calculator))
                return false;

            if (!_podaci[2].Validate(5,5))
                return false;

            if (!_podaci[3].Validate(3,3))
                return false;


            return true;
        }

        public override string Kreiraj()
        {
            if (_podaci.Count < 1)
                return string.Empty;

            var clone =new  HR43();
            clone.PozivNaBroj = PozivNaBroj;


            if (clone._podaci.Count > 1)
            {
                if (clone._podaci[1].Broj.Length < 8)
                {
                    var k1 = _calculator.Calculate(clone._podaci[1].Broj, false);
                    clone._podaci[1].Broj = clone._podaci[1].Broj + k1;
                }
            }


            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
