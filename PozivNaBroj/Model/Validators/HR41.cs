using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBroj.Model.Calculators;

namespace PozivNaBroj.Model.Validators
{
    public class HR41:BaseValidator
    {
        private MOD11INI _calculator;
        private MOD11JMBJMBG _calculator2;

        public HR41()
        {
            _calculator = new MOD11INI();
            _calculator2 = new MOD11JMBJMBG();
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;


            foreach (var podatak in _podaci)
            {
                if (podatak.Index == 1)
                {
                    if (!podatak.Validate(13, 13, calculator: _calculator2))
                        return false;
                }
                else if (podatak.Index == 2)
                {
                    if (!podatak.Validate(calculator: _calculator))
                        return false;
                }
            }


            return true;
        }

        public override string Kreiraj()
        {
            if (_podaci.Count < 1)
                return string.Empty;

            var clone = new HR41();
            clone.PozivNaBroj = PozivNaBroj;

            if (clone._podaci[0].Broj.Length < 13)
            {
                var k = _calculator2.Calculate(clone._podaci[0].Broj, false);
                clone._podaci[0].Broj = clone._podaci[0].Broj + k;
            }

            if (clone._podaci.Count > 1 && clone._podaci[1].Broj.Length < 12)
            {
                var k = _calculator.Calculate(clone._podaci[1].Broj, false);
                clone._podaci[1].Broj = clone._podaci[1].Broj + k;
            }



            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
