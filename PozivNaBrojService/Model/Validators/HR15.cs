using PozivNaBrojService.Model.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBrojService.Model.Validators
{
    public class HR15 : BaseValidator
    {
        private MOD10 _calculator;
        public HR15()
        {
            _calculator = new MOD10();
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            if (_podaci.Count > 2)
            {
                Error = "Poziv na broj može imati maksimalno 2 podatka.";
                return false;
            }

            int poz = 0;
            foreach (var podatak in _podaci)
            {
                if (poz == 0)
                {
                    if (!podatak.Validate(8, 8, _calculator))
                        return false;
                }
                else
                {
                    if (!podatak.Validate(11, 11, _calculator))
                        return false;
                }

                poz++;
            }

            return true;

        }

        public override string Kreiraj()
        {
            if (_podaci.Count < 1)
                return string.Empty;

            var clone = new HR15();
            clone.PozivNaBroj = PozivNaBroj;

            if (clone._podaci[0].Broj.Length < 8)
            {
                var k = _calculator.Calculate(clone._podaci[0].Broj, false);
                clone._podaci[0].Broj = clone._podaci[0].Broj + k;
            }

            if (clone._podaci.Count > 1 && clone._podaci[1].Broj.Length < 11)
            {
                var k1 = _calculator.Calculate(clone._podaci[1].Broj, false);
                clone._podaci[1].Broj = clone._podaci[1].Broj + k1;
            }

            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
