using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozivNaBroj.Model.Validators;

namespace PozivNaBroj.Model
{
    public class ModelPoziva
    {
        private string _model;
        private BaseValidator _validator;
        private string _pozivNaBroj;

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
            Type t = Type.GetType($"PozivNaBroj.Model.Validators.{model}");
            if (t != null)
                _validator = (BaseValidator) Activator.CreateInstance(t);
            else
                _validator = new BaseValidator();
        }

        public override string ToString()
        {
            return _model;
        }

        public bool Validate()
        {
            return _validator.Validate();
        }

        public string Kreiraj()
        {
            return _validator.Kreiraj();
        }
    }
}
