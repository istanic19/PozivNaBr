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
            Models.Add(new ModelPoziva("HR14"));
            Models.Add(new ModelPoziva("HR15"));//Provjeriti validaciju 
            Models.Add(new ModelPoziva("HR16"));
            Models.Add(new ModelPoziva("HR17"));
            Models.Add(new ModelPoziva("HR18"));//Provjeriti
            Models.Add(new ModelPoziva("HR19"));
            Models.Add(new ModelPoziva("HR23"));
            Models.Add(new ModelPoziva("HR24"));
            Models.Add(new ModelPoziva("HR25"));
            Models.Add(new ModelPoziva("HR26"));
            Models.Add(new ModelPoziva("HR27"));
            Models.Add(new ModelPoziva("HR28"));
            Models.Add(new ModelPoziva("HR29"));
            Models.Add(new ModelPoziva("HR30"));
            Models.Add(new ModelPoziva("HR31"));
            Models.Add(new ModelPoziva("HR33"));
            Models.Add(new ModelPoziva("HR34"));
            Models.Add(new ModelPoziva("HR35"));
            Models.Add(new ModelPoziva("HR40"));//Provjeriti validaciju 
            Models.Add(new ModelPoziva("HR41"));
            Models.Add(new ModelPoziva("HR42"));
            Models.Add(new ModelPoziva("HR43"));
            Models.Add(new ModelPoziva("HR50"));
            Models.Add(new ModelPoziva("HR55"));
            Models.Add(new ModelPoziva("HR62"));
            Models.Add(new ModelPoziva("HR63"));
            Models.Add(new ModelPoziva("HR64"));
            Models.Add(new ModelPoziva("HR65"));
            Models.Add(new ModelPoziva("HR67"));
            Models.Add(new ModelPoziva("HR68"));
            Models.Add(new ModelPoziva("HR69"));
            Models.Add(new ModelPoziva("HR83"));//Provjeriti
            Models.Add(new ModelPoziva("HR84"));//Provjeriti

            Models.Add(new ModelPoziva("HR99"));
        }
    }
}
