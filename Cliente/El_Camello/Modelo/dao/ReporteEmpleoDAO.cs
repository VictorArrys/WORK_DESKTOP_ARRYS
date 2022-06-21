using El_Camello.Assets.utilerias;
using El_Camello.Modelo.clases;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace El_Camello.Modelo.dao
{
    internal class ReporteEmpleoDAO
    {

        public static async Task<List<ReporteEmpleo>> GetReportesEmpleo(string token)
        {

            MensajesSistema errorMessage;
            List<ReporteEmpleo> reportesEmpleo = new List<ReporteEmpleo>();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = "http://localhost:5000/v1/reportesEmpleo";

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);

                    RespuestasAPI respuestaAPI = new RespuestasAPI();


                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        string body = await respuesta.Content.ReadAsStringAsync();


                        JArray arrayReportes = JArray.Parse(body);
                        foreach (var reporte in arrayReportes)
                        {

                            ReporteEmpleo reporteGet = new ReporteEmpleo();
                            reporteGet.IdReporte = (int)reporte["id_reporte_empleo"];
                            reporteGet.IdAspiranteReporte = (int)reporte["id_perfil_aspirante_re"];
                            reporteGet.IdOfertaReportada = (int)reporte["id_oferta_empleo_re"];
                            reporteGet.Motivo = (string)reporte["motivo"];
                            reporteGet.Estatus = (int)reporte["estatus"];
                            reporteGet.FechaRegistro = (DateTime)reporte["fecha_registro"];
                            reporteGet.NombreAspirante = (string)reporte["aspirante"];
                            reporteGet.NombreOfertaReportada = (string)reporte["nombre"];
                            reporteGet.DescripcionOfertaReportada = (string)reporte["descripcion"];
                            reporteGet.NombreEmpleador = (string)reporte["empleador"];

                            reportesEmpleo.Add(reporteGet);
                        }

                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Get reportes empleos", respuesta);
                    }

                }
                catch (HttpRequestException exception)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Obtener reportes de empleo", exception.Message);
                    errorMessage.ShowDialog();
                }


            }

            return reportesEmpleo;
        }

        public static async Task<int> PatchAceptarSolicitud(string token, int idSolicitudEmpleo)
        {

            MensajesSistema errorMessage;
            int aceptada = 0;
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = "http://localhost:5000/v1/solicitudesEmpleo/" + idSolicitudEmpleo + "/aceptada";

                try
                {
                    HttpResponseMessage respuesta = await cliente.PatchAsync(endpoint, null);

                    RespuestasAPI respuestaAPI = new RespuestasAPI();


                    if (respuesta.StatusCode == HttpStatusCode.NoContent)
                    {
                        aceptada = 1;

                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("PatchAceptarSolicitud", respuesta);
                    }

                }
                catch (HttpRequestException exception)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Aceptar solicitud de empleo", exception.Message);
                    errorMessage.ShowDialog();
                }


            }

            return aceptada;
        }

        public static async Task<int> PatchRechazarSolicitud(string token, int idSolicitudEmpleo)
        {

            MensajesSistema errorMessage;
            int aceptada = 0;
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = "http://localhost:5000/v1/solicitudesEmpleo/" + idSolicitudEmpleo + "/rechazada";

                try
                {
                    HttpResponseMessage respuesta = await cliente.PatchAsync(endpoint, null);

                    RespuestasAPI respuestaAPI = new RespuestasAPI();


                    if (respuesta.StatusCode == HttpStatusCode.NoContent)
                    {
                        aceptada = 1;

                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("PatchRechazarSolicitud", respuesta);
                    }

                }
                catch (HttpRequestException exception)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Rechazar solicitud de empleo", exception.Message);
                    errorMessage.ShowDialog();
                }


            }

            return aceptada;
        }

    }
}
