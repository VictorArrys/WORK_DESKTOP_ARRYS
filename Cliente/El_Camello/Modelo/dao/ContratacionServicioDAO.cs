using El_Camello.Assets.utilerias;
using El_Camello.Configuracion;
using El_Camello.Modelo.clases;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.dao
{
    public class ContratacionServicioDAO
    {
        public static async Task<List<ContratacionServicio>> GetContratacionesServicio(int idDemandante, string token)
        {
            List<ContratacionServicio> contratacionesServicio = new List<ContratacionServicio>();
            MensajesSistema errorMessage;
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                try
                {
                    string endpoint = $"{Settings.ElCamelloURL}/v1/perfilDemandantes/{idDemandante}/contratacionesServicios";
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        string body = await respuesta.Content.ReadAsStringAsync();

                        JArray arrayContratacionesServicio = JArray.Parse(body);
                        foreach (JObject item in arrayContratacionesServicio)
                        {
                            ContratacionServicio contratacionServicio = new ContratacionServicio();
                            contratacionServicio.IdContratacionServicio = (int)item["idContratacionServicio"];
                            contratacionServicio.Demandante.IdDemandante = (int)item["idPerfilDemandante"];
                            contratacionServicio.FechaFinalizacion = item["fechaFinalizacion"].Type == JTokenType.Null ? DateTime.MinValue : (DateTime)item["fechaFinalizacion"];
                            contratacionServicio.Estatus = (int)item["estatus"];
                            contratacionServicio.FechaContratacion = (DateTime)item["fechaContratacion"];
                            contratacionServicio.ValoracionAspirante = (int)item["valoracionDemandante"];
                            contratacionServicio.Aspirante.IdAspirante = (int)item["idPerfilAspirante"];
                            contratacionesServicio.Add(contratacionServicio);

                        }
                    }
                }
                catch (HttpRequestException excepcionCapturada)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Evaluar aspirante", excepcionCapturada.Message);
                    errorMessage.ShowDialog();
                }
            }
            return contratacionesServicio;
        }

        public static async Task<List<ContratacionServicio>> GetContratacionesServicioAspirante(int idAspirante, string token)
        {
            List<ContratacionServicio> listaContratacionesServicios = new List<ContratacionServicio>();


            MensajesSistema errorMessage;
            int res = -1;
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);

                string endpoint = $"{Settings.ElCamelloURL}/v1/perfilAspirantes/{idAspirante}/contratacionesServicios";

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    RespuestasAPI respuestaAPI = new RespuestasAPI();
                    string body = await respuesta.Content.ReadAsStringAsync();

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        JArray arregloJContrataciones = JsonConvert.DeserializeObject<JArray>(body);

                        foreach (JToken item in arregloJContrataciones)
                        {
                            ContratacionServicio contratacion = new ContratacionServicio();
                            contratacion.IdContratacionServicio = (int)item["idContratacionServicio"];
                            contratacion.TituloEmpleo = (string)item["tituloEmpleo"];
                            contratacion.Aspirante.IdAspirante = (int)item["idPerfilAspirante"];
                            contratacion.Demandante.IdDemandante = (int)item["demandante"]["idPerfilDemandante"];
                            contratacion.Demandante.NombreDemandante = (string)item["demandante"]["nombre"];

                            JToken jTokenFechaFinalizacion = item["fechaFinalizacion"];
                            if (jTokenFechaFinalizacion.Type == JTokenType.Null)
                            {
                                contratacion.FechaFinalizacion = DateTime.Now;
                            } 
                            else
                            {
                                contratacion.FechaFinalizacion = (DateTime)item["fechaFinalizacion"];
                            }

                            JToken jTokenFechaContratacion = item["fechaContratacion"];
                            if (jTokenFechaContratacion.Type == JTokenType.Null)
                            {
                                contratacion.FechaContratacion = DateTime.Now;
                            }
                            else
                            {
                                contratacion.FechaContratacion = (DateTime)item["fechaContratacion"];
                            }
                            
                            listaContratacionesServicios.Add(contratacion);
                        }

                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Evaluar aspirante", respuesta);
                    }

                }
                catch (HttpRequestException excepcionCapturada)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Evaluar aspirante", excepcionCapturada.Message);
                    errorMessage.ShowDialog();
                }


            }

            return listaContratacionesServicios;
        }

        public static async Task<int> evaluar(int idDemandante, int idContratacion, string token, int puntuacion)
        {
            int resultado = -1;
            MensajesSistema errorMessage;
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                RespuestasAPI respuestaAPI = new RespuestasAPI();
                string endpoint = $"{Settings.ElCamelloURL}/v1/perfilDemandantes/{idDemandante}/contratacionesServicios/{idContratacion}/evaluarAspirante";
                try
                {
                    JObject cuerpoSolicitud = new JObject
                    {
                        {"puntuacion", puntuacion },

                    };

                    var data = new StringContent(cuerpoSolicitud.ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage respuesta = await cliente.PatchAsync(endpoint, data);

                    if (respuesta.StatusCode == HttpStatusCode.Created)
                    {
                        resultado = 1;
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Registrar solicitud para aspirante", respuesta);
                    }


                }
                catch (HttpRequestException excepcionCapturada)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Evaluar aspirante", excepcionCapturada.Message);
                    errorMessage.ShowDialog();
                }
            }
            return resultado;
        }

        public static async Task<int> finalizar(int idDemandante, int idContratacion, string token)
        {
            int resultado = -1;
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                RespuestasAPI respuestaAPI = new RespuestasAPI();
                MensajesSistema errorMessage;

                try
                {
                    string endpoint = $"{Settings.ElCamelloURL}/v1/perfilDemandantes/{idDemandante}/contratacionesServicios/{idContratacion}/finalizada";
                    HttpResponseMessage respuesta = await cliente.PatchAsync(endpoint, null);

                    if (respuesta.StatusCode == HttpStatusCode.NoContent)
                    {
                        resultado = 1;
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("finalizar constratacion para aspirante", respuesta);
                    }

                }
                catch (HttpRequestException excepcionCapturada)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "finalizar", excepcionCapturada.Message);
                    errorMessage.ShowDialog();
                }

            }
            return resultado;
        }
    }
}
