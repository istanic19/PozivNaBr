﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBroj.Model.Validators
{
    public class HR99: BaseValidator
    {
        public HR99() : base()
        {

        }
        public override bool Validate()
        {
            if (string.IsNullOrEmpty(PozivNaBroj))
            {
                return true;
            }

            return false;
        }

        public override string Kreiraj()
        {
            return string.Empty;
        }
    }
}