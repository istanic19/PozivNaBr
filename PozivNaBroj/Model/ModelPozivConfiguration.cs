using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBroj.Model
{
    public static class ModelPozivConfiguration
    {
        public static List<ModelPoziva> Models { get; set; }

        static ModelPozivConfiguration()
        {
            Models = new List<ModelPoziva>();
            Models.Add(new ModelPoziva("HR00"));
            Models.Add(new ModelPoziva("HR01"));
            Models.Add(new ModelPoziva("HR02"));
            Models.Add(new ModelPoziva("HR03"));
            Models.Add(new ModelPoziva("HR04"));
            Models.Add(new ModelPoziva("HR05"));
            Models.Add(new ModelPoziva("HR06"));
            Models.Add(new ModelPoziva("HR07"));
            Models.Add(new ModelPoziva("HR08"));
            Models.Add(new ModelPoziva("HR09"));
            Models.Add(new ModelPoziva("HR10"));
            Models.Add(new ModelPoziva("HR11"));
            Models.Add(new ModelPoziva("HR12"));
            Models.Add(new ModelPoziva("HR13"));

            Models.Add(new ModelPoziva("HR99"));
        }
    }
}
