using PozivNaBrojService.Model.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBrojService.Model
{
    public class ModelPoziva
    {
        private string _model;
        private BaseValidator _validator;
        private HRxx _frendlyValidator;
        private string _pozivNaBroj;

        public string Error
        {
            get { return _validator.Error; }
        }

        public string PozivNBr
        {
            get { return _pozivNaBroj; }
            set
            {
                _pozivNaBroj = value;
                _validator.PozivNaBroj = value;
            }
        }

        public ModelPoziva(string model)
        {
            _model = model;
            Type t = Type.GetType($"PozivNaBrojService.Model.Validators.{model}");
            if (t != null)
                _validator = (BaseValidator)Activator.CreateInstance(t);
            else
                throw new Exception("Nepoznat model");
        }

        public override string ToString()
        {
            return _model;
        }

        public bool Validate()
        {
            if (PozivNBr.StartsWith("#VI#"))
            {
                if (_frendlyValidator == null)
                    _frendlyValidator = new HRxx();
                _frendlyValidator.PozivNaBroj = PozivNBr.Substring(4);

                return _frendlyValidator.Validate();
            }
            else
                return _validator.Validate();
        }

        public string Kreiraj()
        {
            return _validator.Kreiraj();
        }
    }
}
