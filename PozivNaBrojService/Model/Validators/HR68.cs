using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBrojService.Model.Calculators;

namespace PozivNaBrojService.Model.Validators
{
    public class HR68:BaseValidator
    {
        private MOD11INI _calculator;
        private ISO7064MOD1110 _calculator2;

        public HR68()
        {
            _calculator = new MOD11INI();
            _calculator2 = new ISO7064MOD1110();
            _maxPodaciCount = 4;
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            if (_podaci.Count < 2)
            {
                Error = "Poziv na broj mora imati najmanje 2 podatka.";
                return false;
            }

            foreach (var podatak in _podaci)
            {
                if (podatak.Index == 1)
                {
                    if (!podatak.Validate(4, 4, calculator: _calculator))
                        return false;
                }
                else if (podatak.Index == 2)
                {
                    if (!podatak.Validate(11, 11, calculator: _calculator2))
                        return false;
                }
                else
                {
                    if (!podatak.Validate(5))
                        return false;
                }
            }


            return true;
        }

        public override string Kreiraj()
        {
            if (_podaci.Count < 1)
                return string.Empty;

            var clone = new HR68();
            clone.PozivNaBroj = PozivNaBroj;

            if (clone._podaci[0].Broj.Length < 4)
            {
                var k = _calculator.Calculate(clone._podaci[0].Broj, false);
                clone._podaci[0].Broj = clone._podaci[0].Broj + k;
            }

            if (clone._podaci.Count > 1 && clone._podaci[1].Broj.Length < 11)
            {
                var k = _calculator2.Calculate(clone._podaci[1].Broj, false);
                clone._podaci[1].Broj = clone._podaci[1].Broj + k;
            }

            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
