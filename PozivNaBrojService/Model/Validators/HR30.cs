using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBrojService.Model.Validators
{
    public class HR30:BaseValidator
    {
        public override bool Validate()
        {
            if (!base.Validate())
                return false;

            if (_podaci.Count != 3)
            {
                Error = "Poziv na broj mora imati 3 podatka.";
                return false;
            }

            if (!_podaci[0].Validate(10, 10))
                return false;

            if (!_podaci[1].Validate(4, 4))
                return false;

            if (!_podaci[2].Validate(6))
                return false;


            return true;
        }
    }
}
