using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBroj.Model.Calculators;

namespace PozivNaBroj.Model.Validators
{
    public class HR01 : BaseValidator
    {
        private MOD11INICalculator _calculator;
        public HR01()
        {
            _calculator = new MOD11INICalculator();
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

            return _calculator.Check(_allNumbers);

        }

        public override string Kreiraj()
        {
            var result = PozivNaBroj + _calculator.Calculate(_allNumbers, false).ToString();

            return result;
        }
    }
}
