using El_Camello.Assets.utilerias;
using El_Camello.Configuracion;
using El_Camello.Modelo.clases;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
                string endpoint = $"{Settings.ElCamelloURL}/v1/reportesEmpleo";

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
                            reporteGet.IdAspirante = (int)reporte["id_perfil_aspirante_re"];
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

        public static async Task<int> PatchAceptarReporte(string token, int idReporteEmpleo)
        {

            MensajesSistema errorMessage;
            int aceptada = 0;
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = $"{Settings.ElCamelloURL}/v1/reportesEmpleo/{idReporteEmpleo}/aceptado";

                try
                {
                    HttpResponseMessage respuesta = await cliente.PatchAsync(endpoint, null);

                    RespuestasAPI respuestaAPI = new RespuestasAPI();


                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        aceptada = 1;

                    }else if (respuesta.StatusCode == HttpStatusCode.Forbidden)
                    {
                        aceptada = -1;
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Patch aceptar reporte", respuesta);
                    }

                }
                catch (HttpRequestException exception)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Aceptar reporte de empleo", exception.Message);
                    errorMessage.ShowDialog();
                }


            }

            return aceptada;
        }

        public static async Task<int> PatchRechazarReporte(string token, int idReporteEmpleo)
        {

            MensajesSistema errorMessage;
            int rechazado = 0;
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = "http://localhost:5000/v1/reportesEmpleo/" + idReporteEmpleo + "/rechazado";

                try
                {
                    HttpResponseMessage respuesta = await cliente.PatchAsync(endpoint, null);

                    RespuestasAPI respuestaAPI = new RespuestasAPI();


                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        rechazado = 1;

                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Patch rechazar reporte", respuesta);
                    }

                }
                catch (HttpRequestException exception)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Rechazar reporte de empleo", exception.Message);
                    errorMessage.ShowDialog();
                }


            }

            return rechazado;
        }


        //Aspirante
        public static async Task<ReporteEmpleo> PostReporteEmpleo(ReporteEmpleo nuevoReporte, int idContratacion ,string token)
        {
            ReporteEmpleo reporte = new ReporteEmpleo();
            RespuestasAPI respuestaAPI = new RespuestasAPI();

            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = $"{Settings.ElCamelloURL}/v1/reportesEmpleo";

                try
                {  

                    JObject cuerpoSolicitud = new JObject
                    {
                        {"idPerfilAspirante", nuevoReporte.IdAspirante },
                        {"motivo", nuevoReporte.Motivo },
                        {"idContratacion", idContratacion }
                    };

                    var data = new StringContent(cuerpoSolicitud.ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage respuesta = await cliente.PostAsync(endpoint, data);

                    if (respuesta.StatusCode == HttpStatusCode.Created)
                    {
                        string responseBody = await respuesta.Content.ReadAsStringAsync();

                        JObject jReporte = JObject.Parse(responseBody);
                        reporte.IdReporte = (int)jReporte["idReporteEmpleo"];
                        reporte.IdAspirante = (int)jReporte["idAspirante"];
                        reporte.IdOfertaReportada = (int)jReporte["idOfertaEmpleo"];
                        reporte.Motivo = (string)jReporte["motivo"];
                        reporte.Estatus = (int)jReporte["estatus"];
                        reporte.FechaRegistro = (DateTime)jReporte["fechaRegistro"];
                        return reporte;
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Registrar reporte de empleo", respuesta);
                    }

                }
                catch (HttpRequestException exception)
                {
                    MensajesSistema errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Registrar reporte de empleo", exception.Message);
                    errorMessage.ShowDialog();
                }


            }

            return null;
        }
    }
}
