using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBroj.Model
{
    public class PozivNaBrojValidationResult
    {
        public bool Valid { get; set; }
        public string Message { get; set; }

        public PozivNaBrojValidationResult(bool valid)
        {
            Valid = valid;
        }

        public PozivNaBrojValidationResult(bool valid, string message)
        {
            Valid = valid;
            Message = message;
        }

        public static bool operator true(PozivNaBrojValidationResult de)
        {
            return de.Valid;
        }

        public static bool operator false(PozivNaBrojValidationResult de)
        {
            return !de.Valid;
        }

        public static bool operator !(PozivNaBrojValidationResult de)
        {
            return !de.Valid;
        }

        public static PozivNaBrojValidationResult Ok
        {
            get { return new PozivNaBrojValidationResult(true); }
        }

        public static PozivNaBrojValidationResult Error(string message)
        {
            return new PozivNaBrojValidationResult(false, message);
        }
    }
}
