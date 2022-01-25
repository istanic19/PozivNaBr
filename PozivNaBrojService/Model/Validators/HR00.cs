using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBrojService.Model.Validators
{
    public class HR00 : BaseValidator
    {
        public override bool Validate()
        {
            if (!base.Validate())
                return false;


            foreach (var podatak in _podaci)
            {
                if (!podatak.Validate())
                    return false;
            }

            return true;

        }

        public override string Kreiraj()
        {
            return PozivNaBroj;
        }
    }
}
