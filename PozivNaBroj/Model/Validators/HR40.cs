using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBroj.Model.Calculators;

namespace PozivNaBroj.Model.Validators
{
    public class HR40: BaseValidator
    {
        private MOD11P7 _calculator;
        private MOD10 _calculator2;

        public HR40()
        {
            _calculator = new MOD11P7();
            _calculator2 = new MOD10();
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;


            foreach (var podatak in _podaci)
            {
                if (podatak.Index == 1)
                {
                    if (!podatak.Validate(11, 11))
                        return false;
                    if (!podatak.Broj.StartsWith("0"))
                    {
                        Error = $"Prva znamenka mora biti 0.";
                        return false;
                    }
                    if(CheckRepeatings(podatak.Broj.Substring(0, 9)))
                    {
                        Error = $"Podak 1: neispravna sekvenca, sadrži 3 ista znaka u nizu.";
                        return false;
                    }
                    if (_calculator.GetRest(podatak.Broj.Substring(0, 9)) == 0)
                    {
                        Error = $"Podak 1: pogreška validacije {_calculator.GetName()}."; ;
                    }
                    if (podatak.Broj != CalculateK(podatak.Broj.Substring(0, 9)))
                    {
                        Error = $"Podak 1: pogreška validacije {_calculator.GetName()} ili {_calculator2.GetName()}."; ;
                        return false;
                    }
                }
                else
                {
                    if (!podatak.Validate())
                        return false;
                }
            }


            return true;
        }

        private string CalculateK(string broj)
        {
            var result = broj;

            var k1 = _calculator2.Calculate(broj, false);
            var k2= _calculator.Calculate(broj, false);

            return $"{broj}{k1}{k2}";
        }

        public bool CheckRepeatings(string broj)
        {
            int count = 1;

            for (int i = 0; i < broj.Length; ++i)
            {
                if (i > 0 && broj[i] == broj[i - 1])
                    count++;
                else
                    count = 1;

                if (count >= 3)
                    return true;
            }

            return false;
        }

        public override string Kreiraj()
        {
            if (_podaci.Count < 1)
                return string.Empty;

            var clone = new HR40();
            clone.PozivNaBroj = PozivNaBroj;

            if (clone._podaci[0].Broj.Length == 9)
            {
                var k = CalculateK(clone._podaci[0].Broj.Substring(0,9));
                clone._podaci[0].Broj = k;
            }


            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
