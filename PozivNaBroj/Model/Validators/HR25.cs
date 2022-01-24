using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBroj.Model.Validators
{
    public class HR25:BaseValidator
    {
        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            if (_podaci.Count != 2)
                return false;

            if (!_podaci[0].Validate(3, 3))
                return false;

            if (!_podaci[1].Validate(7, 7))
                return false;

            return true;
        }

        public override string Kreiraj()
        {
            return PozivNaBroj;
        }
    }
}
