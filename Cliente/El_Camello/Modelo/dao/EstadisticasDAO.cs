using El_Camello.Assets.utilerias;
using El_Camello.Modelo.clases;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace El_Camello.Modelo.dao
{
    public class EstadisticasDAO
    {
        public static async Task<List<EstadisticasPlataforma>> GetEstadisticasPlataforma(string token)
        {

            MensajesSistema errorMessage;
            List<EstadisticasPlataforma> estadisticasPlataforma = new List<EstadisticasPlataforma>();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = "http://localhost:5000/v1/estadisticas/estadisticasUsoPlataforma";

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);

                    RespuestasAPI respuestaAPI = new RespuestasAPI();


                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        string body = await respuesta.Content.ReadAsStringAsync();


                        JArray arrayEstadisticasPlataforma = JArray.Parse(body);
                        foreach (var estadisticas in arrayEstadisticasPlataforma)
                        {

                            EstadisticasPlataforma estadisticasGET = new EstadisticasPlataforma();
                            estadisticasGET.YearFecha = (string)estadisticas["fecha"];
                            estadisticasGET.MesFecha = (string)estadisticas["mes"];
                            estadisticasGET.OfertasPublicadas = (int)estadisticas["ofertas_publicadas"];
                            estadisticasGET.CategoriaEmpleo = (string)estadisticas["categoria"];

                            estadisticasPlataforma.Add(estadisticasGET);
                        }

                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("GetEstadisticasPlataforma", respuesta);
                    }

                }
                catch (HttpRequestException exception)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Obtener estadisticas de la platadorma", exception.Message);
                    errorMessage.ShowDialog();
                }


            }

            return estadisticasPlataforma;
        }

        public static async Task<List<EstadisticasEmpleoDemanda>> GetEstadisticasDemanda(string token)
        {

            MensajesSistema errorMessage;
            List<EstadisticasEmpleoDemanda> estadisticasDemanda = new List<EstadisticasEmpleoDemanda>();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = "http://localhost:5000/v1/estadisticas/estadisiticasEmpleos";

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);

                    RespuestasAPI respuestaAPI = new RespuestasAPI();


                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        string body = await respuesta.Content.ReadAsStringAsync();


                        JArray arrayEstadisticasDemanda = JArray.Parse(body);
                        foreach (var estadisticas in arrayEstadisticasDemanda)
                        {

                            EstadisticasEmpleoDemanda estadisticasGET = new EstadisticasEmpleoDemanda();
                            estadisticasGET.FechaEstadisticas = (DateTime)estadisticas["fecha"];
                            estadisticasGET.SolicitudesEstadisticas = (int)estadisticas["solicitudes_publicadas"];
                            estadisticasGET.CategoriaEmpleo = (string)estadisticas["categoria"];

                            estadisticasDemanda.Add(estadisticasGET);
                        }

                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("GetEstadisticasDemanda", respuesta);
                    }

                }
                catch (HttpRequestException exception)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Obtener estadisticas de demanda de empleo", exception.Message);
                    errorMessage.ShowDialog();
                }


            }

            return estadisticasDemanda;
        }

        public static async Task<List<EstadisticasOfertasEmpleo>> GetEstadisticasOfertas(string token)
        {

            MensajesSistema errorMessage;
            List<EstadisticasOfertasEmpleo> estadisticasOfertasEmpleos = new List<EstadisticasOfertasEmpleo>();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = "http://localhost:5000/v1/estadisticas/ofertasEmpleo";

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);

                    RespuestasAPI respuestaAPI = new RespuestasAPI();


                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        string body = await respuesta.Content.ReadAsStringAsync();


                        JArray arrayEstadisticasOfertas = JArray.Parse(body);
                        foreach (var estadisticas in arrayEstadisticasOfertas)
                        {

                            EstadisticasOfertasEmpleo estadisticasGET = new EstadisticasOfertasEmpleo();
                            estadisticasGET.Fecha = (string)estadisticas["fecha_anio"];
                            estadisticasGET.OfertasPublicadas = (int)estadisticas["ofertas_publicadas"];

                            estadisticasOfertasEmpleos.Add(estadisticasGET);
                        }

                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("GetEstadisticasOfertas", respuesta);
                    }

                }
                catch (HttpRequestException exception)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Obtener estadisticas de ofertas de empleo", exception.Message);
                    errorMessage.ShowDialog();
                }


            }

            return estadisticasOfertasEmpleos;
        }

        public static async Task<List<ValoracionAspirante>> GetValoracionesAspirantes(string token)
        {

            MensajesSistema errorMessage;
            List<ValoracionAspirante> valoracionAspirantes = new List<ValoracionAspirante>();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = "http://localhost:5000/v1/estadisticas/valoracionesAspirantes";

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);

                    RespuestasAPI respuestaAPI = new RespuestasAPI();


                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        string body = await respuesta.Content.ReadAsStringAsync();


                        JArray arrayValoraciones = JArray.Parse(body);
                        foreach (var valoraciones in arrayValoraciones)
                        {

                            int? valoracion = (int?)valoraciones["valoracion_aspirante"];

                            if (valoracion == null) 
                            {
                                

                            }
                            else
                            {
                                ValoracionAspirante valoracionesGet = new ValoracionAspirante();
                                valoracionesGet.NombreAspirante = (string)valoraciones["aspirante"];
                                valoracionesGet.IdValoracionAspirante = (int)valoraciones["id_aspirante"];
                                valoracionesGet.EvaluacionAspirante = (int)valoraciones["valoracion_aspirante"];

                                if (valoracionesGet.EvaluacionAspirante > 0)
                                {
                                    valoracionAspirantes.Add(valoracionesGet);
                                }
                            }

                        }

                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("GetValoracionesAspirantes", respuesta);
                    }

                }
                catch (HttpRequestException exception)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Obtener valoracioens de aspirantes", exception.Message);
                    errorMessage.ShowDialog();
                }


            }

            return valoracionAspirantes;
        }

        public static async Task<List<ValoracionEmpleador>> GetValoracionesEmpleadores(string token)
        {

            MensajesSistema errorMessage;
            List<ValoracionEmpleador> valoracionEmpleadores = new List<ValoracionEmpleador>();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = "http://localhost:5000/v1/estadisticas/valoracionesEmpleadores";

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);

                    RespuestasAPI respuestaAPI = new RespuestasAPI();


                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        string body = await respuesta.Content.ReadAsStringAsync();


                        JArray arrayValoraciones = JArray.Parse(body);
                        foreach (var valoraciones in arrayValoraciones)
                        {
                            int? valoracion = (int?)valoraciones["valoracion_empleador"];

                            if (valoracion == null)
                            {

                            }
                            else
                            {
                                ValoracionEmpleador valoracionesGet = new ValoracionEmpleador();
                                valoracionesGet.NombreEmpleador = (string)valoraciones["empleador"];
                                valoracionesGet.IdValoracionEmpleador = (int)valoraciones["id_empleador"];
                                valoracionesGet.EvaluacionEmpleador = (int)valoraciones["valoracion_empleador"];

                                if(valoracionesGet.EvaluacionEmpleador > 0)
                                {
                                    valoracionEmpleadores.Add(valoracionesGet);
                                }
                                
                            }
                        }

                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("GetValoracionesEmpleadores", respuesta);
                    }

                }
                catch (HttpRequestException exception)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Obtener las valoraciones de empleadores", exception.Message);
                    errorMessage.ShowDialog();
                }


            }

            return valoracionEmpleadores;
        }




    }
}
