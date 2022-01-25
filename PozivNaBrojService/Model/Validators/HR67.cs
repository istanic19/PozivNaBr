using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBrojService.Model.Calculators;

namespace PozivNaBrojService.Model.Validators
{
    public class HR67:BaseValidator
    {
        private ISO7064MOD1110 _calculator;

        public HR67()
        {
            _calculator = new ISO7064MOD1110();
            _maxPodaciCount = 4;
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;


            foreach (var podatak in _podaci)
            {
                if (podatak.Index == 1)
                {
                    if (!podatak.Validate(11, 11, calculator: _calculator))
                        return false;
                }
                else if (podatak.Index == 2)
                {
                    if (!podatak.Validate(10 ))
                        return false;
                }
                else if (podatak.Index == 3)
                {
                    if (!podatak.Validate(8))
                        return false;
                }
            }


            return true;
        }

        public override string Kreiraj()
        {
            if (_podaci.Count < 1)
                return string.Empty;

            var clone = new HR67();
            clone.PozivNaBroj = PozivNaBroj;

            if (clone._podaci[0].Broj.Length < 11)
            {
                var k = _calculator.Calculate(clone._podaci[0].Broj, false);
                clone._podaci[0].Broj = clone._podaci[0].Broj + k;
            }

            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
