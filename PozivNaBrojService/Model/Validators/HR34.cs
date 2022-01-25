using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBrojService.Model.Calculators;

namespace PozivNaBrojService.Model.Validators
{
    public class HR34: BaseValidator
    {
        private ISO7064MOD1110 _calculator;
        public HR34()
        {
            _calculator = new ISO7064MOD1110();
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

            foreach (var podatak in _podaci)
            {
                if (podatak.Index == 1)
                {
                    if (!podatak.Validate(6, calculator: _calculator))
                        return false;
                }
                else if (podatak.Index == 2)
                {
                    if (!podatak.Validate(7, calculator: _calculator))
                        return false;
                }
                else
                {
                    if (!podatak.Validate(5, calculator: _calculator))
                        return false;
                    if (podatak.Broj.StartsWith("0"))
                    {
                        Error = $"Podatak 3 ne smije imati početne nule.";
                        return false;
                    }
                }
            }


            return true;
        }

        public override string Kreiraj()
        {
            if (_podaci.Count < 1)
                return string.Empty;

            var clone = new HR34();
            clone.PozivNaBroj = PozivNaBroj;

            if (clone._podaci[0].Broj.Length < 6)
            {
                var k = _calculator.Calculate(clone._podaci[0].Broj, false);
                clone._podaci[0].Broj = clone._podaci[0].Broj + k;
            }

            if (clone._podaci.Count > 1 && clone._podaci[1].Broj.Length < 7)
            {
                var k = _calculator.Calculate(clone._podaci[1].Broj, false);
                clone._podaci[1].Broj = clone._podaci[1].Broj + k;
            }

            if (clone._podaci.Count > 2 && clone._podaci[2].Broj.Length < 5)
            {
                var k = _calculator.Calculate(clone._podaci[2].Broj, false);
                clone._podaci[2].Broj = clone._podaci[2].Broj + k;
            }


            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
