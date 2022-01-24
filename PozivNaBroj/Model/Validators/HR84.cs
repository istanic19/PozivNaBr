using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBroj.Model.Calculators;

namespace PozivNaBroj.Model.Validators
{
    public class HR84 : BaseValidator
    {
        private MOD11INI _calculator;

        public HR84()
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
                    if (_podaci.Count == 3)
                    {
                        if (!podatak.Validate(4, 4))
                            return false;
                    }
                    else
                    {
                        if (!podatak.Validate(8, 8))
                            return false;
                    }
                    
                }
                else
                {
                    if (!podatak.Validate(10, 10))
                        return false;
                    if (_podaci[1].Broj.Length != 5)
                    {
                        Error = "Podatak 3 se popunjava samo ako Podatak 2 ima 4 znamenke";
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

            var clone = new HR84();
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
