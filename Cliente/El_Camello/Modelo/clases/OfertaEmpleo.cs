using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.clases
{
    public class OfertaEmpleo
    {
        private int cantidadPago;
        private string descripcion;
        private string diasLaborales;
        private string direccion;
        private DateTime fechaFinalizacion;
        private DateTime fechaInicio;
        private TimeOnly horaFin;
        private TimeOnly horaInicio;
        private int idCategoriaEmpleo;
        private string nombre;
        private string tipoPago;
        private int vacantes;
        private int idOfertaEmpleo;
        private int idPerfilEmpleador;
        private List<byte[]> fotografias;
        private string categoriaEmpleo;
        private string estado;

        //Tiene una contratación
        private ContratacionEmpleo ContratacionEmpleoOferta;

        public int CantidadPago { get => cantidadPago; set => cantidadPago = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string DiasLaborales { get => diasLaborales; set => diasLaborales = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public DateTime FechaFinalizacion { get => fechaFinalizacion; set => fechaFinalizacion = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public TimeOnly HoraFin { get => horaFin; set => horaFin = value; }
        public TimeOnly HoraInicio { get => horaInicio; set => horaInicio = value; }
        public int IdCategoriaEmpleo { get => idCategoriaEmpleo; set => idCategoriaEmpleo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string TipoPago { get => tipoPago; set => tipoPago = value; }
        public int Vacantes { get => vacantes; set => vacantes = value; }
        public int IdOfertaEmpleo { get => idOfertaEmpleo; set => idOfertaEmpleo = value; }
        public int IdPerfilEmpleador { get => idPerfilEmpleador; set => idPerfilEmpleador = value; }
        public List<byte[]> Fotografias { get => fotografias; set => fotografias = value; }
        public string CategoriaEmpleo { get => categoriaEmpleo; set => categoriaEmpleo = value; }
        public string Estado { get => estado; set => estado = value; }
        public ContratacionEmpleo ContratacionEmpleo { get => ContratacionEmpleoOferta; set => ContratacionEmpleoOferta = value; }
         
    }
}
