using El_Camello.Assets.utilerias;
using El_Camello.Modelo.clases;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace El_Camello.Modelo.dao
{
    public class ContratacionEmpleoAspiranteDAO
    {
        public static async Task<int> PatchEvaluarAspirante(ContratacionEmpleoAspirante evaluacionAspirante, int idAspirante, int idOfertaEmpleo, string token)
        {

            MensajesSistema errorMessage;
            int res = -1;
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);

                string endpoint = string.Format("http://localhost:5000/v1/contratacionesEmpleo/{0}?idAspirante={1}", idOfertaEmpleo,idAspirante);

                try
                {

                    HttpRequestMessage cuerpoMensaje = new HttpRequestMessage();
                    JObject valoracionCuerpo = new JObject();

                    valoracionCuerpo.Add("idAspirante", idAspirante);
                    valoracionCuerpo.Add("valoracionAspirante", evaluacionAspirante.ValoracionAspirante);
                    valoracionCuerpo.Add("nombreAspirante", evaluacionAspirante.NombreAspiranteContratado);

                    string cuerpoJson = JsonConvert.SerializeObject(valoracionCuerpo);


                    var data = new StringContent(cuerpoJson, Encoding.UTF8, "application/json");

                    HttpResponseMessage respuesta = await cliente.PatchAsync(endpoint, data);


                    RespuestasAPI respuestaAPI = new RespuestasAPI();


                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        string body = await respuesta.Content.ReadAsStringAsync();

                        JObject objetoCreado = JsonConvert.DeserializeObject<JObject>(body);
                        ContratacionEmpleoAspirante evaluacion = new ContratacionEmpleoAspirante();
                        evaluacion.IdAspirante = (int)objetoCreado["idAspirante"];
                        evaluacion.ValoracionAspirante = (int)objetoCreado["valoracionAspirante"];
                        evaluacion.NombreAspiranteContratado = (string)objetoCreado["nombreAspirante"];
                        int evaluado = evaluacion.ValoracionAspirante;
                        res = evaluado;

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

            return res;

        }


        //Aspirante
        public static async Task<List<ContratacionEmpleo>> GetContraracionesEmpleoAspirante(int idAspirante, string token)
        {
            List<ContratacionEmpleo> listaContrataciones = new List<ContratacionEmpleo>();

            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);

                string endpoint = $"http://localhost:5000/v1/perfilAspirantes/{idAspirante}/contratacionesEmpleo";

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    RespuestasAPI respuestaAPI = new RespuestasAPI();
                    string body = await respuesta.Content.ReadAsStringAsync();

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        

                        JArray jArrayContrataciones = JArray.Parse(body);
                        foreach (var jContratacion in jArrayContrataciones)
                        {
                            ContratacionEmpleo contratacion = new ContratacionEmpleo();
                            contratacion.IdContratacion = jContratacion["idContratacionEmpleo"] != null && (jContratacion["idContratacionEmpleo"].Type == JTokenType.Integer) ? (int)jContratacion["idContratacionEmpleo"] : 0;
                            contratacion.IdOfertaEmpleo = jContratacion["idOfertaEmpleo"] != null && jContratacion["idOfertaEmpleo"].Type == JTokenType.Integer ? (int)jContratacion["idOfertaEmpleo"] : 0;
                            contratacion.NombteOfertaEmpleo = (string)jContratacion["nombreOfertaEmpleo"];
                            contratacion.NombreEmpleador = (string)jContratacion["nombreEmpleador"];
                            contratacion.Estatus = (int)jContratacion["estatus"];
                            contratacion.FechaContratacion = (DateTime)jContratacion["fechaContratacion"];
                            contratacion.FechaFinalizacionContratacion = (DateTime)jContratacion["fechaFinalizacion"];
                            listaContrataciones.Add(contratacion);
                        }
                        

                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Evaluar aspirante", respuesta);
                    }

                }
                catch (HttpRequestException excepcionCapturada)
                {
                    MensajesSistema errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Evaluar aspirante", excepcionCapturada.Message);
                    errorMessage.ShowDialog();
                }


            }

            return listaContrataciones;
        }

        public static async Task<Tuple<ContratacionEmpleo, OfertaEmpleo>> GetContratacionAspirante(int idAspirante, int idContratacion, string token)
        {
            ContratacionEmpleo contratacion = new ContratacionEmpleo();
            OfertaEmpleo ofertaEmpleo = new OfertaEmpleo();

            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);

                string endpoint = $"http://localhost:5000/v1/perfilAspirantes/{idAspirante}/contratacionesEmpleo/{idContratacion}";

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    RespuestasAPI respuestaAPI = new RespuestasAPI();
                    string responseBody = await respuesta.Content.ReadAsStringAsync();

                    JObject jContratacion = JObject.Parse(responseBody);
                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        contratacion.IdContratacion = (int)jContratacion["idContratacion"];
                        contratacion.Estatus = (int)jContratacion["estatus"];
                        
                        
                        ofertaEmpleo.Nombre = (string)jContratacion["nombreEmpleo"];
                        ofertaEmpleo.CategoriaEmpleo = (string)jContratacion["categoriaEmpleo"];
                        ofertaEmpleo.Direccion = (string)jContratacion["direccion"];
                        ofertaEmpleo.DiasLaborales = (string)jContratacion["diasLaborales"];
                        
                        string horaInicio = (string)jContratacion["horaInicio"];
                        string horaFin = (string)jContratacion["horaFin"];

                        ofertaEmpleo.HoraInicio = TimeOnly.Parse(horaInicio);
                        ofertaEmpleo.HoraFin = TimeOnly.Parse(horaFin);
                        ofertaEmpleo.TipoPago = (string)jContratacion["tipoPago"];
                        ofertaEmpleo.CantidadPago = (int)jContratacion["cantidadPago"];
                        ofertaEmpleo.FechaInicio = (DateTime)jContratacion["fechaContratacion"];
                        ofertaEmpleo.FechaFinalizacion = (DateTime)jContratacion["fechaFinalizacion"];
                        ofertaEmpleo.Descripcion = (string)jContratacion["descripcion"];
                        return Tuple.Create(contratacion, ofertaEmpleo);
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Consultar contratación", respuesta);
                    }

                }
                catch (HttpRequestException excepcionCapturada)
                {
                    MensajesSistema errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Evaluar aspirante", excepcionCapturada.Message);
                    errorMessage.ShowDialog();
                }


            }

            return null;
        }
    }
}
