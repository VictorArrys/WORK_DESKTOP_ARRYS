using El_Camello.Modelo.clases;
using Newtonsoft.Json;
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
    public class ConversacionesDAO
    {
        
        public static async Task<List<Conversacion>> GetConversacionesAspirante(int idAspirante, string token)
        {
            List<Conversacion> conversaciones = new List<Conversacion>();
            using (var cliente = new HttpClient())
            {
                string endpoint = $"http://localhost:5000/v1/perfilAspirantes/{idAspirante}/conversaciones";
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string cuerpoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            JArray convesacionesJObject = JArray.Parse(cuerpoRespuesta);
                            foreach(var elemento in convesacionesJObject)
                            {
                                Conversacion conversacion = new Conversacion();
                                conversacion.IdConversacion = (int)elemento["idConversacion"];
                                conversacion.Titulo = (string)elemento["tituloEmpleo"];
                                conversacion.FechaContratacion = (DateTime)elemento["fechaContratacion"];
                                conversaciones.Add(conversacion);
                            }
                            break;
                        case HttpStatusCode.Unauthorized:
                        case HttpStatusCode.InternalServerError:
                        case HttpStatusCode.NotFound:
                            JObject codigo = JObject.Parse(cuerpoRespuesta);
                            string mensaje = (string)codigo["type error"]["menssage"];
                            MessageBox.Show(mensaje);
                            break;
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }
            }

            return conversaciones;
        }




        public static async Task<Conversacion> GetConversacionAspirante(int idConversacion, int idAspirante, string token)
        {
            Conversacion conversacion = new Conversacion();
            using (var cliente = new HttpClient())
            {
                string endpoint = $"http://localhost:5000/v1/perfilAspirantes/{idAspirante}/conversaciones/{idConversacion}";
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string cuerpoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            JObject conversacionGet = JObject.Parse(cuerpoRespuesta);
                            
                            conversacion.IdConversacion = (int)conversacionGet["idConversacion"];
                            conversacion.Titulo = (string)conversacionGet["tituloEmpleo"];

                            IList<JToken> listaMensajesJson = conversacionGet["mensajes"].Children().ToList();
                            List<Mensaje> listaMensajes = new List<Mensaje>();
                            foreach (JToken elemento in listaMensajesJson)
                            {
                                Mensaje mensaje = elemento.ToObject<Mensaje>();
                                listaMensajes.Add(mensaje);
                            }

                            conversacion.Mensajes = listaMensajes;
                            break;
                        case HttpStatusCode.Unauthorized:
                        case HttpStatusCode.InternalServerError:
                        case HttpStatusCode.NotFound:
                            JObject codigo = JObject.Parse(cuerpoRespuesta);
                            string mensajeError = (string)codigo["type error"]["menssage"];
                            MessageBox.Show(mensajeError);
                            break;
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }
            }

            return conversacion;
        }


        public static async Task<Mensaje> PostMensajeAspirante(int idConversacion, int idAspirante, string mensaje, string token)
        {
            Mensaje mensajeNuevo = new Mensaje();

            using (var cliente = new HttpClient())
            {
                try
                {
                    string endpoint = $"http://localhost:5000/v1/perfilAspirantes/{idAspirante}/conversaciones/{idConversacion}";
                    cliente.DefaultRequestHeaders.Add("x-access-token", token);

                    string cuerpoJson = "{\"mensaje\": \"" + mensaje + "\"}";

                    var requestBody = new StringContent(cuerpoJson, Encoding.UTF8, "application/json");

                    HttpResponseMessage respuesta = await cliente.PostAsync(endpoint, requestBody);
                    string cuerpoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.Created:
                            mensajeNuevo = JsonConvert.DeserializeObject<Mensaje>(cuerpoRespuesta);
                            break;
                        case HttpStatusCode.Unauthorized:
                        case HttpStatusCode.InternalServerError:
                        case HttpStatusCode.NotFound:
                            JObject codigo = JObject.Parse(cuerpoRespuesta);
                            string mensajeError = (string)codigo["type error"]["menssage"];
                            MessageBox.Show(mensajeError);
                            break;
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }
            }
            return mensajeNuevo;
        }




        public static async Task<List<Conversacion>> GetConversacionesDemandante(int idDemandante, string token)
        {
            List<Conversacion> conversaciones = new List<Conversacion>();
            using (var cliente = new HttpClient())
            {
                string endpoint = $"http://localhost:5000/v1/perfilDemandantes/{idDemandante}/conversaciones";
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string cuerpoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            JArray convesacionesJObject = JArray.Parse(cuerpoRespuesta);
                            foreach (var elemento in convesacionesJObject)
                            {
                                Conversacion conversacion = new Conversacion();
                                conversacion.IdConversacion = (int)elemento["idConversacion"];
                                conversacion.Titulo = (string)elemento["tituloSolicitud"];
                                conversacion.NombreAspirante = (string)elemento["nombreAspirante"];
                                conversacion.FechaContratacion = (DateTime)elemento["fechaContratacion"];
                                conversaciones.Add(conversacion);
                            }
                            break;
                        case HttpStatusCode.Unauthorized:
                        case HttpStatusCode.InternalServerError:
                        case HttpStatusCode.NotFound:
                            JObject codigo = JObject.Parse(cuerpoRespuesta);
                            string mensaje = (string)codigo["type error"]["menssage"];
                            MessageBox.Show(mensaje);
                            break;
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }
            }

            return conversaciones;
        }
        public static async Task<Conversacion> GetConversacionDemandante(int idConversacion, int idDemandante, string token)
        {
            Conversacion conversacion = new Conversacion();
            using (var cliente = new HttpClient())
            {
                string endpoint = $"http://localhost:5000/v1/perfilDemandantes/{idDemandante}/conversaciones/{idConversacion}";
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string cuerpoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            JObject conversacionGet = JObject.Parse(cuerpoRespuesta);

                            conversacion.IdConversacion = (int)conversacionGet["idConversacion"];
                            conversacion.Titulo = (string)conversacionGet["tituloEmpleo"];

                            IList<JToken> listaMensajesJson = conversacionGet["mensajes"].Children().ToList();
                            List<Mensaje> listaMensajes = new List<Mensaje>();
                            foreach (JToken elemento in listaMensajesJson)
                            {
                                Mensaje mensaje = elemento.ToObject<Mensaje>();
                                listaMensajes.Add(mensaje);
                            }

                            conversacion.Mensajes = listaMensajes;
                            break;
                        case HttpStatusCode.Unauthorized:
                        case HttpStatusCode.InternalServerError:
                        case HttpStatusCode.NotFound:
                            JObject codigo = JObject.Parse(cuerpoRespuesta);
                            string mensajeError = (string)codigo["type error"]["menssage"];
                            MessageBox.Show(mensajeError);
                            break;
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }
            }

            return conversacion;
        }
        public static async Task<Mensaje> PostMensajeDemandante(int idConversacion, int idDemandante, string mensaje, string token)
        {
            Mensaje mensajeNuevo = new Mensaje();

            using (var cliente = new HttpClient())
            {
                try
                {
                    string endpoint = $"http://localhost:5000/v1/perfilDemandantes/{idDemandante}/conversaciones/{idConversacion}";
                    cliente.DefaultRequestHeaders.Add("x-access-token", token);

                    string cuerpoJson = "{\"mensaje\": \"" + mensaje + "\"}";

                    var requestBody = new StringContent(cuerpoJson, Encoding.UTF8, "application/json");

                    HttpResponseMessage respuesta = await cliente.PostAsync(endpoint, requestBody);
                    string cuerpoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.Created:
                            mensajeNuevo = JsonConvert.DeserializeObject<Mensaje>(cuerpoRespuesta);
                            break;
                        case HttpStatusCode.Unauthorized:
                        case HttpStatusCode.InternalServerError:
                        case HttpStatusCode.NotFound:
                            JObject codigo = JObject.Parse(cuerpoRespuesta);
                            string mensajeError = (string)codigo["type error"]["menssage"];
                            MessageBox.Show(mensajeError);
                            break;
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }
            }
            return mensajeNuevo;
        }



        public static void GetConversacionesEmpleador(int idAspirante, string token)
        {

        }
        public static void GetConversacionEmpleador(int idConversacion, int idAspirante, string token)
        {

        }
        public static void PostMensajeEmpleador(int idConversacion, int idAspirante, string mensaje, string token)
        {

        }

    }
}
