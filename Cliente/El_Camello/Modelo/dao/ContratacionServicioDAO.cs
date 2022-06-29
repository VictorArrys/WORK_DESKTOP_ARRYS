using El_Camello.Assets.utilerias;
using El_Camello.Configuracion;
using El_Camello.Modelo.clases;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace El_Camello.Modelo.dao
{
    internal class ContratacionServicioDAO
    {
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
    }
}
