﻿using PozivNaBroj.Model.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBroj.Model.Validators
{
    public class HR11 : BaseValidator
    {
        private MOD11INICalculator _calculator;
        public HR11()
        {
            _calculator = new MOD11INICalculator();
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            for (int i = 0; i < _podaci.Count; ++i)
            {
                if (i > 1)
                {
                    if (!_podaci[i].Validate())
                        return false;
                }
                else
                {
                    if (!_podaci[i].Validate(calculator: _calculator))
                        return false;
                }
            }

            return true;

        }

        public override string Kreiraj()
        {

            var clone = new HR11();
            clone.PozivNaBroj = PozivNaBroj;

            for (int i = 0; i < clone._podaci.Count && i < 2;++i)
            {
                clone._podaci[i].Broj = clone._podaci[i].Broj + _calculator.Calculate(clone._podaci[i].Broj, false);
            }

            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}