using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBroj.Model.Calculators
{
    public class BaseCalculator
    {
        public virtual int Calculate(string broj, bool check = true)
        {
            throw new NotImplementedException();
        }

        public virtual string Create(string broj)
        {
            throw new NotImplementedException(); ;
        }

        public virtual bool Check(string broj)
        {
            return true;
        }
    }
}
