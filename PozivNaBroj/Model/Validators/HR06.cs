using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBroj.Helpers;
using PozivNaBroj.Model.Calculators;

namespace PozivNaBroj.Model.Validators
{
    public class HR06 : BaseValidator
    {
        private MOD11INICalculator _calculator;
        public HR06()
        {
            _calculator = new MOD11INICalculator();
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            if (!_podaci[0].Validate())
                return false;

            if (_podaci.Count == 2)
            {
                if (!_podaci[1].Validate(calculator:_calculator))
                    return false;
            }

            if (_podaci.Count == 3)
            {
                if (_podaci[2].Broj.StartsWith("0"))
                    return false;
                var group = _podaci[1].Broj + _podaci[2].Broj;
                if (!_calculator.Check(group))
                    return false;
            }

            return true;

        }

        public override string Kreiraj()
        {
            if (_podaci.Count < 2)
                return PozivNaBroj;

            var clone = new HR06();
            clone.PozivNaBroj = PozivNaBroj;

           
            if (clone._podaci.Count == 2)
            {
                var k1 = _calculator.Calculate(clone._podaci[1].Broj, false);
                clone._podaci[1].Broj = clone._podaci[1].Broj + k1;
            }

            if (clone._podaci.Count == 3)
            {
                var group = clone._podaci[1].Broj + clone._podaci[2].Broj;
                clone._podaci[2].Broj += _calculator.Calculate(group, false).ToString();
            }

            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
