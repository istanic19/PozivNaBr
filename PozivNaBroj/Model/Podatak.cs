using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBroj.Model.Calculators;

namespace PozivNaBroj.Model
{
    public class Podatak
    {
        private string _broj;
        private int _index;

        public Podatak(string broj, int index)
        {
            _index = index;
            _broj = broj;
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
                return false;
            if (!_broj.All(char.IsDigit))
                return false;
            if (_broj.Length > maxLen)
                return false;
            if (minLen.HasValue && _broj.Length < minLen.Value)
                return false;

            if (calculator != null && !calculator.Check(_broj))
            {
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
