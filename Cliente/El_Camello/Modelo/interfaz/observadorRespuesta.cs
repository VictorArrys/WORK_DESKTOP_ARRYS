using El_Camello.Modelo.clases;

namespace El_Camello.Modelo.interfaz
{
    public interface observadorRespuesta
    {
        void actualizarInformacion(Usuario usuario);
        void actualizarCambios(string operacion);
    }
}
