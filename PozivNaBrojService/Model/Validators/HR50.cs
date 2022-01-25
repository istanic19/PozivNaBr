using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBrojService.Model.Calculators;

namespace PozivNaBrojService.Model.Validators
{
    public class HR50: BaseValidator
    {
        private MOD11P7 _calculator;

        public HR50()
        {
            _calculator = new MOD11P7();
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
                    if (!podatak.Validate(5,5, calculator: _calculator))
                        return false;
                }
                else if (podatak.Index == 2)
                {
                    if (!podatak.Validate(12, 12))
                        return false;
                }
                else
                {
                    if (!podatak.Validate(1, 1))
                        return false;
                }
            }


            return true;
        }

        public override string Kreiraj()
        {
            if (_podaci.Count < 1)
                return string.Empty;

            var clone = new HR50();
            clone.PozivNaBroj = PozivNaBroj;

            if (clone._podaci[0].Broj.Length < 5)
            {
                var k = _calculator.Calculate(clone._podaci[0].Broj, false);
                clone._podaci[0].Broj = clone._podaci[0].Broj + k;
            }

            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
