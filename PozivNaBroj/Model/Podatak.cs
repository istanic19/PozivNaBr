using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBroj.Model.Calculators;
using PozivNaBroj.Model.Validators;

namespace PozivNaBroj.Model
{
    public class Podatak
    {
        private string _broj;
        private int _index;
        private BaseValidator _parent;

        public int Index
        {
            get { return _index; }
        }

        public Podatak(string broj, int index, BaseValidator parent)
        {
            _index = index;
            _broj = broj;
            _parent = parent;
        }

        public int Segment
        {
            get { return _index; }
        }

        public string Broj
        {
            get { return _broj; }
            set { _broj = value; }
        }

        public bool Validate(int maxLen = 12, int? minLen=null, BaseCalculator calculator = null)
        {
            if (string.IsNullOrWhiteSpace(_broj))
            {
                _parent.Error = $"Podak {_index} ne može biti prazan.";
                return false;
            }

            if (!_broj.All(char.IsDigit))
            {
                _parent.Error = $"Podak {_index} sadrži nedozvoljene znakove.";
                return false;
            }

            if (_broj.Length > maxLen)
            {
                _parent.Error = $"Podak {_index} ne može biti dulji od {maxLen} znakova.";
                return false;
            }

            if (minLen.HasValue && _broj.Length < minLen.Value)
            {
                _parent.Error = $"Podak {_index} ne može biti manji od {minLen.Value} znakova.";
                return false;
            }

            if (calculator != null && !calculator.Check(_broj))
            {
                _parent.Error = $"Podak {_index}: pogreška validacije {calculator.GetName()}";
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return _broj;
        }
    }
}
