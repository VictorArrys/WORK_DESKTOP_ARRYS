using El_Camello.Modelo.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Assets.utilerias
{
    public class ValidacionActualizar
    {


        public bool esDiferente(OfertaEmpleo objeto1, OfertaEmpleo objeto2)
        {
            bool resultado = true;

            if(objeto1 == objeto2)
            {
                resultado = false;
            }

            return resultado;
        }


    }
}
