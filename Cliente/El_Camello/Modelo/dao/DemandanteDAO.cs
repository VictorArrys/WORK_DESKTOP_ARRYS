using El_Camello.Modelo.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace El_Camello.Modelo.dao
{
    internal class DemandanteDAO
    {
        public static async Task<int> PostDemandante(Usuario usuario, Demandante aspirante)
        {
            int res = -1;
            MessageBox.Show(usuario.Fotografia.ToString());
            return res;
        }
    }
}
