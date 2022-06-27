using El_Camello.Assets.utilerias;
using El_Camello.Modelo.clases;
using El_Camello.Modelo.interfaz;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.dao
{
    internal class SolicitudEmpleoDAO
    {
        public static async Task<List<SolicitudEmpleo>> GetSolicitudesEmpleo(string token, int idOfertaEmpleo)
        {

            MensajesSistema errorMessage;
            List<SolicitudEmpleo> solicitudesEmpleo = new List<SolicitudEmpleo>();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = "http://localhost:5000/v1/solicitudesEmpleo?idOfertaEmpleo=" + idOfertaEmpleo;

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);

                    RespuestasAPI respuestaAPI = new RespuestasAPI();


                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        string body = await respuesta.Content.ReadAsStringAsync();


                        JArray arraySolicitudes = JArray.Parse(body);
                        foreach (var solicitudes in arraySolicitudes)
                        {

                            SolicitudEmpleo solicitudGet = new SolicitudEmpleo();
                            solicitudGet.IdSolicitud = (int)solicitudes["id_solicitud_aspirante"];
                            solicitudGet.IdAspirante = (int)solicitudes["id_perfil_aspirante_sa"];
                            solicitudGet.IdOfertaEmpleo = (int)solicitudes["id_oferta_empleo_sa"];
                            solicitudGet.EstatusInt = (int)solicitudes["estatus"];

                            if (solicitudGet.EstatusInt == 1)
                            {
                                solicitudGet.Estatus = "Pendiente";
                            }
                            if (solicitudGet.EstatusInt == -1)
                            {
                                solicitudGet.Estatus = "Rechazada";
                            }
                            if (solicitudGet.EstatusInt == 0)
                            {
                                solicitudGet.Estatus = "Aprobada";
                            }


                            solicitudGet.FechaRegistro = (DateTime)solicitudes["fecha_registro"];
                            solicitudGet.Nombre = (string)solicitudes["nombre"];
                            solicitudGet.IdUsuarioAspirante = (int)solicitudes["id_perfil_usuario_aspirante"];
                            int idUsuarioAspirante = (int)solicitudes["id_perfil_usuario_aspirante"];

                            //solicitudGet.AspiranteSolicitante = await AspiranteDAO.GetAspirante(idUsuarioAspirante, token);


                            solicitudesEmpleo.Add(solicitudGet);
                        }

                    }
                    else if (respuesta.StatusCode == HttpStatusCode.NotFound)
                    {
                        return solicitudesEmpleo;
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("GetSolicitudesEmpleo", respuesta);
                    }

                }
                catch (HttpRequestException exception)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Obtener solicitudes de empleo", exception.Message);
                    errorMessage.ShowDialog();
                }


            }

            return solicitudesEmpleo;
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



        //Aspirante
        public static async Task<SolicitudEmpleo> PostSolicitarVacante(int idOfertaEmpleo, int idPerfilAspirante, string token, observadorRespuesta ventanaSolicitudvacante)
        {
            SolicitudEmpleo solicitudEmpleo = new SolicitudEmpleo();
            try
            {
                MensajesSistema errorMessage;
                using (var cliente = new HttpClient())
                {
                    JObject cuerpoSolicitud = new JObject
                    {
                        {"idPerfilAspirante", idPerfilAspirante }
                    };
                    
                    var data = new StringContent(cuerpoSolicitud.ToString(), Encoding.UTF8, "application/json");

                    cliente.DefaultRequestHeaders.Add("x-access-token", token);
                    string endpoint = $"http://localhost:5000/v1/ofertasEmpleo-A/{idOfertaEmpleo}/solicitarVacante";


                    HttpResponseMessage respuesta = await cliente.PostAsync(endpoint, data);

                    RespuestasAPI respuestaAPI = new RespuestasAPI();
                    string body = await respuesta.Content.ReadAsStringAsync();
                    JObject registroSolicitudVacante = JObject.Parse(body);
                    if (respuesta.StatusCode == HttpStatusCode.Created)
                    {
                        solicitudEmpleo.IdSolicitud = (int)registroSolicitudVacante["idSolicitudVacante"];
                        ventanaSolicitudvacante.actualizarCambios("Solicitud registrada exitosamente");
                    }
                    else
                    {
                        solicitudEmpleo.IdSolicitud = 0;
                        ventanaSolicitudvacante.actualizarCambios((string)registroSolicitudVacante["type error"]["message"]);
                    }




                }
            }
            catch (HttpRequestException exception)
            {
                MensajesSistema errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Rechazar solicitud de empleo", exception.Message);
                errorMessage.ShowDialog();
            }
            return solicitudEmpleo;
        }
    }
}
