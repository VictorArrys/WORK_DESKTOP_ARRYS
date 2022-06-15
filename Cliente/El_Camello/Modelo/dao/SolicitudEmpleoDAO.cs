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

                            if(solicitudGet.EstatusInt == 1)
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

                            MessageBox.Show("ID: " + idUsuarioAspirante);
                            //solicitudGet.AspiranteSolicitante = await AspiranteDAO.GetAspirante(idUsuarioAspirante, token);


                            solicitudesEmpleo.Add(solicitudGet);
                        }

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


    }
}
