using PozivNaBroj.Model.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBroj.Model.Validators
{
    public class HR08 : BaseValidator
    {
        private MOD11INI _calculator;
        public HR08()
        {
            _calculator = new MOD11INI();
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
                {
                    Error = $"Podatak 2 ne smije imati početne nule.";
                    return false;
                }

                var grupa = _podaci[0].Broj + _podaci[1].Broj;
                if (!_calculator.Check(grupa))
                {
                    Error = $"Pogreška {_calculator.GetName()} za grupu podataka 1 i 2.";
                    return false;
                }

                if (_podaci.Count > 2)
                {
                    if (!_podaci[2].Validate(calculator: _calculator))
                        return false;
                }
            }

            return true;

        }

        public override string Kreiraj()
        {

            var clone = new HR08();
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

                if (clone._podaci.Count > 2)
                {
                    var k2 = _calculator.Calculate(clone._podaci[2].Broj, false);
                    clone._podaci[2].Broj = clone._podaci[2].Broj + k2.ToString();
                }
            }


            clone.PozivNaBroj = clone.PodaciToBroj();

            return clone.PozivNaBroj;
        }
    }
}
