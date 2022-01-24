using PozivNaBroj.Model.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBroj.Model.Validators
{
    public class HR24 : BaseValidator
    {
        private MOD11INI _calculator;
        public HR24()
        {
            _calculator = new MOD11INI();
            _maxPodaciCount = 4;
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            for (int i = 0; i < _podaci.Count; ++i)
            {
                if (i == 0)
                {
                    if (!_podaci[i].Validate(4, 4, _calculator))
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
            if (_podaci.Count < 1)
                return string.Empty;

            var clone = new HR24();
            clone.PozivNaBroj = PozivNaBroj;

            var k = _calculator.Calculate(clone._podaci[0].Broj, false);
            clone._podaci[0].Broj = clone._podaci[0].Broj + k;

            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
