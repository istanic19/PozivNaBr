using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBroj.Model.Calculators;

namespace PozivNaBroj.Model.Validators
{
    public class HR42:BaseValidator
    {
        private MOD11JMBJMBG _calculator;

        public HR42()
        {
            _calculator = new MOD11JMBJMBG();
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;


            foreach (var podatak in _podaci)
            {
                if (!podatak.Validate())
                    return false;
            }

            if (!_calculator.Check(_allNumbers))
            {
                Error = $"Pogreška validacije {_calculator.GetName()}";
                return false;
            }

            return true;

        }

        public override string Kreiraj()
        {
            var result = PozivNaBroj + _calculator.Calculate(_allNumbers, false).ToString();

            return result;
        }
    }
}
