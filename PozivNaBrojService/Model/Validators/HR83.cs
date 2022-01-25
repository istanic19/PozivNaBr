using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBrojService.Model.Calculators;

namespace PozivNaBrojService.Model.Validators
{
    public class HR83: BaseValidator
    {
        private MOD11INI _calculator;

        public HR83()
        {
            _calculator = new MOD11INI();
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
                    if (podatak.Broj.Length != 5 && podatak.Broj.Length != 7 && podatak.Broj.Length != 16)
                    {
                        Error = "Podatak 2 mora sadržavati 5,7 ili 16 znakova.";
                        return false;
                    }
                    if (!podatak.Broj.StartsWith("0") && !podatak.Broj.StartsWith("3"))
                    {
                        Error = "Podatak 2: prva znamenka mora biti 0 ili 3.";
                        return false;
                    }
                    if (!podatak.Validate(16))
                        return false;
                }
                else
                {
                    if (!podatak.Broj.StartsWith("1") && !podatak.Broj.StartsWith("2"))
                    {
                        Error = "Podatak 3: prva znamenka mora biti 1 ili 2.";
                        return false;
                    }
                    if (!podatak.Validate(6, 6))
                        return false;
                    if (_podaci[1].Broj.Length != 5)
                    {
                        Error = "Podatak 3 se popunjava samo ako Podatak 2 ima 5 znamenaka";
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

            var clone = new HR83();
            clone.PozivNaBroj = PozivNaBroj;

            if (clone._podaci[0].Broj.Length < 4)
            {
                var k = _calculator.Calculate(clone._podaci[0].Broj, false);
                clone._podaci[0].Broj = clone._podaci[0].Broj + k;
            }


            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
