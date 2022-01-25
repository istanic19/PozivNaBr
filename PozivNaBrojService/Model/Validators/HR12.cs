using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBrojService.Model.Calculators;

namespace PozivNaBrojService.Model.Validators
{
    public class HR12 : BaseValidator
    {
        private MOD11JMBJMBG _calculator;

        public HR12()
        {
            _calculator = new MOD11JMBJMBG();
        }
        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            for (int i = 0; i < _podaci.Count; ++i)
            {
                if (i == 0)
                {
                    if (!_podaci[i].Validate(13,13,calculator: _calculator))
                        return false;
                }
                else
                {
                    if (!_podaci[i].Validate())
                        return false;
                }
            }

            return true;

        }

        public override string Kreiraj()
        {
            var clone = new HR12();
            clone.PozivNaBroj = PozivNaBroj;

            if (clone._podaci[0].Broj.Length == 13)
            {
                var k= _calculator.Calculate(clone._podaci[0].Broj, false);
                clone._podaci[0].Broj = clone._podaci[0].Broj.Substring(0, 12) + k.ToString();
            }
            else
            {
                var k = _calculator.Calculate(clone._podaci[0].Broj, false);
                clone._podaci[0].Broj = clone._podaci[0].Broj + k.ToString();
            }


            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
