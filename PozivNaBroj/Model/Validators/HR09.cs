﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBroj.Model.Calculators;

namespace PozivNaBroj.Model.Validators
{
    public class HR09 : BaseValidator
    {
        private MOD11INICalculator _calculator;
        public HR09()
        {
            _calculator = new MOD11INICalculator();
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            if (_podaci.Count == 1)
                return _podaci[0].Validate(calculator: _calculator);
            else
            {
                if (_podaci[1].Broj.StartsWith("0"))
                    return false;
                var grupa = _podaci[0].Broj + _podaci[1].Broj;
                if (!_calculator.Check(grupa))
                    return false;

                if (_podaci.Count > 2)
                {
                    if (!_podaci[2].Validate())
                        return false;
                }
            }

            return true;

        }

        public override string Kreiraj()
        {

            var clone = new HR09();
            clone.PozivNaBroj = PozivNaBroj;

            if (clone._podaci.Count == 1)
            {
                var k = _calculator.Calculate(clone._podaci[0].Broj, false);
                clone._podaci[0].Broj = clone._podaci[0].Broj + k;
            }
            else
            {
                var grupa = clone._podaci[0].Broj + clone._podaci[1].Broj;
                var k1 = _calculator.Calculate(grupa, false);
                clone._podaci[1].Broj = clone._podaci[1].Broj + k1.ToString();
                
            }


            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}