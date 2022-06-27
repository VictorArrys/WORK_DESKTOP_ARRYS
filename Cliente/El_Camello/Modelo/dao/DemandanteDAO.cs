using El_Camello.Assets.utilerias;
using El_Camello.Modelo.clases;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace El_Camello.Modelo.dao
{
    internal class DemandanteDAO
    {
        public static async Task<int> PostDemandante(Usuario usuario, Demandante demandante) // listo cliente
        {
            int resultado = -1;
            int idUsuario = -1;
            int idDemandante = -1;
            using (var cliente = new HttpClient())
            {
                string endpoint = "http://localhost:5000/v1/perfilDemandantes";

                HttpRequestMessage cuerpoMensaje = new HttpRequestMessage();
                JObject objeto = new JObject();
                objeto.Add("clave", usuario.Clave);
                objeto.Add("correoElectronico", usuario.CorreoElectronico);
                objeto.Add("direccion", demandante.Direccion);
                objeto.Add("estatus", usuario.Estatus);
                string fecha = string.Format("{0:yyyy-MM-dd}", demandante.FechaNacimiento);
                objeto.Add("fechaNacimiento", fecha);
                objeto.Add("nombre", demandante.NombreDemandante);
                objeto.Add("nombreUsuario", usuario.NombreUsuario);
                objeto.Add("telefono", demandante.Telefono);

                string cuerpoJson = JsonConvert.SerializeObject(objeto);
                var data = new StringContent(cuerpoJson, Encoding.UTF8, "application/json");

                HttpResponseMessage respuesta = await cliente.PostAsync(endpoint, data);
                string body = await respuesta.Content.ReadAsStringAsync();
                RespuestasAPI respuestaAPI = new RespuestasAPI();

                if (respuesta.StatusCode == HttpStatusCode.Created)
                {
                    JObject registroDemandante = JObject.Parse(body);

                    idUsuario = (int)registroDemandante["idPerfilUsuario"];
                    idDemandante = (int)registroDemandante["idPerfilDemandante"];

                    MultipartFormDataContent foto = new MultipartFormDataContent();
                    var contenidoImagen = new ByteArrayContent(usuario.Fotografia);
                    contenidoImagen.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                    foto.Add(contenidoImagen, "fotografia", "fotografiaPerfilDemandante.jpg");

                    string endpointfoto = String.Format("http://localhost:5000/v1/PerfilUsuarios/{0}/fotografia", idUsuario);
                    respuesta = await cliente.PatchAsync(endpointfoto, foto);

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        resultado = 1;
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Post Demandante", respuesta);
                    }
                }
                else
                {
                    respuestaAPI.gestionRespuestasApi("Post Demandante", respuesta);
                }

            }
                return resultado;
        }


        public static async Task<Demandante> getDemandante(int idUsuarioDemandante, string token) // listo api
        {
            Modelo.clases.Demandante demandante = new Modelo.clases.Demandante();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = string.Format("http://localhost:5000/v1/perfilDemandantes/{0}", idUsuarioDemandante);

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        JObject perfilDemandante = JObject.Parse(body);
                        demandante.Direccion = (string)perfilDemandante["direccion"];
                        demandante.FechaNacimiento = (DateTime)perfilDemandante["fechaNacimiento"];
                        demandante.NombreDemandante = (string)perfilDemandante["nombre"];
                        demandante.Telefono = (string)perfilDemandante["telefono"];
                        demandante.IdDemandante = (int)perfilDemandante["idperfilDemandante"];
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Get Demandante", respuesta);
                    }
                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("verificar servidor");
                }

            }
            return demandante;
        }

        public static async Task<int> putDemandante(Usuario usuario, Demandante demandante) // listo cliente
        {
            int resultado = -1;
            int idUsuario = -1;
            int idDemandante = -1;
            using (var cliente = new HttpClient())
            {
                try
                {
                    cliente.DefaultRequestHeaders.Add("x-access-token", usuario.Token);
                    string endpoint = string.Format("http://localhost:5000/v1/perfilDemandantes/{0}", demandante.IdDemandante);

                    HttpRequestMessage cuerpoMensaje = new HttpRequestMessage();
                    JObject objeto = new JObject();
                    objeto.Add("clave", usuario.Clave);
                    objeto.Add("correoElectronico", usuario.CorreoElectronico);
                    objeto.Add("direccion", demandante.Direccion);
                    objeto.Add("estatus", usuario.Estatus);
                    string fecha = string.Format("{0:yyyy-MM-dd}", demandante.FechaNacimiento);
                    objeto.Add("fechaNacimiento", fecha);
                    objeto.Add("idPerfilUsuario", usuario.IdPerfilusuario);
                    objeto.Add("nombre", demandante.NombreDemandante);
                    objeto.Add("nombreUsuario", usuario.NombreUsuario);
                    objeto.Add("telefono", demandante.Telefono);

                    string cuerpoJson = JsonConvert.SerializeObject(objeto);
                    var data = new StringContent(cuerpoJson, Encoding.UTF8, "application/json");

                    HttpResponseMessage respuesta = await cliente.PutAsync(endpoint, data);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    RespuestasAPI respuestaAPI = new RespuestasAPI();


                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        JObject perfilDemandante = JObject.Parse(body);
                        MessageBox.Show(body);
                        idUsuario = (int)perfilDemandante["idPerfilUsuario"];
                        idDemandante = (int)perfilDemandante["idPerfilDemandante"];

                        MultipartFormDataContent foto = new MultipartFormDataContent();
                        var contenidoImagen = new ByteArrayContent(usuario.Fotografia);
                        contenidoImagen.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                        foto.Add(contenidoImagen, "fotografia", "fotografiaPerfilDemandante.jpg");

                        string endpointfoto = String.Format("http://localhost:5000/v1/PerfilUsuarios/{0}/fotografia", idUsuario);
                        respuesta = await cliente.PatchAsync(endpointfoto, foto);

                        if (respuesta.StatusCode == HttpStatusCode.OK)
                        {
                            resultado = 1;
                        }
                    }

                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("verificar servidor");
                }
            }

             return resultado;
        }
       
    }
}
