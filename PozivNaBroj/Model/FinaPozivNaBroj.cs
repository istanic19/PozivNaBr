using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBroj.Model
{
    public class FinaPozivNaBroj
    {
        private string _model;
        private string _broj;

        public FinaPozivNaBroj(string model, string broj)
        {
            _model = model.ToUpper();
            if (_model.Length == 2)
                _model = "HR" + _model;
            if (_model.Length != 4)
                _model = null;
            _broj = broj;
        }

        public override string ToString()
        {
            return $"{_model} {_broj}";
        }
    }
}
