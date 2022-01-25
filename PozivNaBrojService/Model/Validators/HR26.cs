using PozivNaBrojService.Model.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBrojService.Model.Validators
{
    public class HR26:BaseValidator
    {
        private MOD11INI _calculator;
        private ISO7064MOD1110 _oibCalculator;
        public HR26()
        {
            _calculator = new MOD11INI();
            _oibCalculator = new ISO7064MOD1110();
            _maxPodaciCount = 4;
        }

        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            if (_podaci.Count < 3)
            {
                Error = "Poziv na broj mora imati minimalno 3 podatka.";
                return false;
            }

            for (int i = 0; i < _podaci.Count; ++i)
            {
                if (i == 0)
                {
                    if (!_podaci[i].Validate(4, 4, calculator: _oibCalculator))
                        return false;
                }
                else if (i == 1 || i == 2)
                {
                    if (_podaci[i].Broj.Length <= 10)
                    {
                        if (!_podaci[i].Validate(calculator: _oibCalculator))
                            return false;
                    }
                    else
                    {
                        if (!_podaci[i].Validate(11, 11, calculator: _oibCalculator))
                            return false;
                    }
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

            var clone = new HR26();
            clone.PozivNaBroj = PozivNaBroj;

            if (clone._podaci[0].Broj.Length < 4)
            {
                var k = _calculator.Calculate(clone._podaci[0].Broj, false);
                clone._podaci[0].Broj = clone._podaci[0].Broj + k;
            }

            if (clone._podaci.Count > 1)
            {
                if (clone._podaci[1].Broj.Length < 10)
                {
                    var k1 = _calculator.Calculate(clone._podaci[1].Broj, false);
                    clone._podaci[1].Broj = clone._podaci[1].Broj + k1;
                }
            }

            if (clone._podaci.Count > 2)
            {
                if (clone._podaci[2].Broj.Length < 10)
                {
                    var k2 = _calculator.Calculate(clone._podaci[2].Broj, false);
                    clone._podaci[2].Broj = clone._podaci[2].Broj + k2;
                }
            }

            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
