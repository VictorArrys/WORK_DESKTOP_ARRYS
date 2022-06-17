using El_Camello.Modelo.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.interfaz
{
    public interface observadorRespuesta
    {
        void actualizarInformacion(Usuario usuario);
        void actualizarCambios(string operacion);
    }
}
