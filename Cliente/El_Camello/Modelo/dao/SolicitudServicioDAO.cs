using El_Camello.Assets.utilerias;
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
    public class SolicitudServicioDAO
    {
        /*/Demandante
        public static async Task<List<SolicitudServicio>> GetSolicitudesDemandante()
        {
            
        }*/

        public static async Task<int> PostSolicitudServicio(SolicitudServicio solicitud, int idDemandante, string token)
        {
            int resultado = 0;
            ReporteEmpleo reporte = new ReporteEmpleo();
            RespuestasAPI respuestaAPI = new RespuestasAPI();

            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = $"http://localhost:5000/v1/perfilDemandantes/{idDemandante}/solicitudesServicios";

                try
                {
                    JObject cuerpoSolicitud = new JObject
                    {
                        {"idAspirante", solicitud.Aspirante.IdAspirante },
                        {"titulo", solicitud.Titulo },
                        {"descripcion", solicitud.Descripcion }
                    };

                    var data = new StringContent(cuerpoSolicitud.ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage respuesta = await cliente.PostAsync(endpoint, data);

                    if (respuesta.StatusCode == HttpStatusCode.Created)
                    {
                        resultado = 1;
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Registrar solicitud para aspirante", respuesta);
                    }

                }
                catch (HttpRequestException exception)
                {
                    MensajesSistema errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Registrar reporte de empleo", exception.Message);
                    errorMessage.ShowDialog();
                }


            }
            return resultado;
        }

        //Aspirante

        public static async Task<List<SolicitudServicio>> GetSolicitudesAspirante(int idAspirante, int estatus, string token)
        {
            List<SolicitudServicio> listaSolicitudes = new List<SolicitudServicio>();

            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = $"http://localhost:5000/v1/perfilAspirantes/{idAspirante}/solicitudesServicios";
                switch (estatus)
                {
                    case 1:
                        endpoint += "?estatus=Pendientes";
                        break;
                    case 2:
                        endpoint += "?estatus=Aceptadas";
                        break;
                    case 3:
                        endpoint += "?estatus=Rechazadas";
                        break;
                }
                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);

                    RespuestasAPI respuestaAPI = new RespuestasAPI();


                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        string body = await respuesta.Content.ReadAsStringAsync();


                        JArray arraySolicitudes = JArray.Parse(body);

                        foreach(var solicitud in arraySolicitudes)
                        {
                            SolicitudServicio solicitudConsultada = new SolicitudServicio();
                            solicitudConsultada.IdSolicitudServicio = (int)solicitud["idSolicitudServicio"];
                            solicitudConsultada.Titulo = (string)solicitud["titulo"];
                            solicitudConsultada.Estatus = (int)solicitud["estatus"];
                            solicitudConsultada.FechaRegistro = (DateTime)solicitud["fechaRegistro"];
                            listaSolicitudes.Add(solicitudConsultada);
                        }
                        

                    }
                    else if (respuesta.StatusCode == HttpStatusCode.NotFound)
                    {
                        
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("GetSolicitudesEmpleo", respuesta);
                    }

                }
                catch (HttpRequestException exception)
                {
                    
                }


            }

            return listaSolicitudes;
        }

        public static async Task<SolicitudServicio> GetSolicitudAspirante(int idAspirante, int idSolicitud, string token)
        {
            SolicitudServicio solicitudConsultada = new SolicitudServicio();

            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = $"http://localhost:5000/v1/perfilAspirantes/{idAspirante}/solicitudesServicios/{idSolicitud}";
                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);

                    RespuestasAPI respuestaAPI = new RespuestasAPI();


                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        string body = await respuesta.Content.ReadAsStringAsync();

                        JObject solicitud = JObject.Parse(body);

                        solicitudConsultada.IdSolicitudServicio = (int)solicitud["idSolicitudServicio"];
                        solicitudConsultada.Titulo = (string)solicitud["titulo"];
                        solicitudConsultada.Descripcion = (string)solicitud["descripcion"];
                        solicitudConsultada.Estatus = (int)solicitud["estatus"];
                        solicitudConsultada.FechaRegistro = (DateTime)solicitud["fechaRegistro"];
                        solicitudConsultada.Demandante.IdDemandante = (int)solicitud["demandante"]["idPerfilDemandante"];
                        solicitudConsultada.Demandante.NombreDemandante = (string)solicitud["demandante"]["nombre"];
                        solicitudConsultada.Aspirante.IdAspirante = (int)solicitud["idPerfilAspirante"];
                    }
                    else if (respuesta.StatusCode == HttpStatusCode.NotFound)
                    {

                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("GetSolicitudesEmpleo", respuesta);
                    }

                }
                catch (HttpRequestException exception)
                {

                }


            }

            return  solicitudConsultada;
        }


        public static async Task<string> PatchAceptarSolicitud(int idAspirante, int idSolicitud, string token)
        {
            string aceptarSolicitud = "";

            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = $"http://localhost:5000/v1/perfilAspirantes/{idAspirante}/solicitudesServicios/{idSolicitud}/aceptada";
                try
                {
                    HttpResponseMessage respuesta = await cliente.PatchAsync(endpoint,null);

                    RespuestasAPI respuestaAPI = new RespuestasAPI();
                    
                    string body = await respuesta.Content.ReadAsStringAsync();
                    JObject solicitud = JObject.Parse(body);
                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        aceptarSolicitud = (string)solicitud["message"];
                    }
                    else
                    {
                        aceptarSolicitud = (string)solicitud["type error"]["message"];
                    }

                }
                catch (HttpRequestException exception)
                {

                }


            }

            return aceptarSolicitud;
        }

        public static async Task<string> PatchRechazarSolicitud(int idAspirante, int idSolicitud, string token)
        {
            string aceptarSolicitud = "";

            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = $"http://localhost:5000/v1/perfilAspirantes/{idAspirante}/solicitudesServicios/{idSolicitud}/rechazada";
                try
                {
                    HttpResponseMessage respuesta = await cliente.PatchAsync(endpoint, null);

                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    string body = await respuesta.Content.ReadAsStringAsync();
                    JObject solicitud = JObject.Parse(body);
                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        aceptarSolicitud = (string)solicitud["message"];
                    }
                    else
                    {
                        aceptarSolicitud = (string)solicitud["type error"]["message"];
                    }

                }
                catch (HttpRequestException exception)
                {

                }


            }

            return aceptarSolicitud;
        }
    }
}
