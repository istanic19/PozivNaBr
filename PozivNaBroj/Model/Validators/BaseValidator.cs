using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBroj.Model.Validators
{
    public class BaseValidator
    {
        private string _pozivNaBroj;
        protected List<Podatak> _podaci;
        protected string _allNumbers;
        protected int _maxPodaciCount = 3;

        public string Error { get; set; }

        public string PozivNaBroj
        {
            get { return _pozivNaBroj; }
            set
            {
                if (_pozivNaBroj == value)
                    return;
                _pozivNaBroj = value;
                _podaci = GetPodaci(_pozivNaBroj);
            }
        }

        public BaseValidator()
        {
        }

        public virtual bool Validate()
        {
            Error = "";

            if (string.IsNullOrEmpty(_pozivNaBroj))
            {
                Error = "Poziv na broj ne može biti prazan.";
                return false;
            }

            if (_pozivNaBroj.Length > 22)
            {
                Error = "Poziv na broj može biti do 22 znaka.";
                return false;
            }

            if (_podaci.Count < 1 || _podaci.Count > _maxPodaciCount)
            {
                Error = $"Maksimaln broj podataka u pozivu na broj je {_maxPodaciCount}.";
                return false;
            }

            return true;
        }

        public virtual string Kreiraj()
        {
            return _pozivNaBroj;
        }

        public string PodaciToBroj()
        {
            var result = "";
            for (int i = 0; i < _podaci.Count; ++i)
            {
                if (i > 0)
                    result += "-";
                result += _podaci[i].ToString();
            }
            return result;
        }

        public List<Podatak> GetPodaci(string pozivNaBroj)
        {
            if (string.IsNullOrEmpty(pozivNaBroj))
                return null;
            var segmenti = pozivNaBroj.Split('-');

            var podaci = new List<Podatak>();
            _allNumbers = "";

            int index = 1;
            foreach (var s in segmenti)
            {
                podaci.Add(new Podatak(s, index, this));
                _allNumbers += s;
                index++;
            }

            return podaci;
        }


    }
}
