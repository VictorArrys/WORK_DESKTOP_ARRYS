using El_Camello.Modelo.clases;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using El_Camello.Assets.utilerias;

namespace El_Camello.Modelo.dao
{
    internal class AspiranteDAO
    {

        public static async Task<int> PostAspirante(Usuario usuario, clases.Aspirante aspirante) //listo cliente
        {

            int resultado = -1;
            int idUsuario = -1;
            int idAspirante = -1;
            using (var cliente = new HttpClient())
            {
                
                string endpoint = "http://localhost:5000/v1/perfilAspirantes";
                HttpRequestMessage cuerpoMensaje = new HttpRequestMessage();

                try
                {
                    JArray arregloOficiosJson = new JArray();
                    foreach (Oficio item in aspirante.Oficios)
                    {
                        JObject oficioJson = new JObject();
                        oficioJson.Add("idCategoria", item.IdCategoria);
                        oficioJson.Add("experiencia", item.Experiencia);
                        arregloOficiosJson.Add(oficioJson);
                    }

                    JObject objeto = new JObject();
                    objeto.Add("clave", usuario.Clave);
                    objeto.Add("correoElectronico", usuario.CorreoElectronico);
                    objeto.Add("direccion", aspirante.Direccion);
                    objeto.Add("estatus", 1);
                    string fecha = string.Format("{0:yyyy-MM-dd}", aspirante.FechaNacimiento);
                    objeto.Add("fechaNacimiento", fecha);
                    objeto.Add("nombre", aspirante.NombreAspirante);
                    objeto.Add("nombreUsuario", usuario.NombreUsuario);
                    objeto.Add("oficios", arregloOficiosJson);
                    objeto.Add("telefono", aspirante.Telefono);
                    string cuerpoJson = JsonConvert.SerializeObject(objeto);

                    var data = new StringContent(cuerpoJson, Encoding.UTF8, "application/json");

                    HttpResponseMessage respuesta = await cliente.PostAsync(endpoint, data);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if (respuesta.StatusCode == HttpStatusCode.Created)
                    {
                        JObject registroExitoso = JObject.Parse(body);
                        idUsuario = (int)registroExitoso["idPerfilUsuario"];
                        idAspirante = (int)registroExitoso["idPerfilAspirante"];

                        MultipartFormDataContent foto = new MultipartFormDataContent();
                        var contenidoImagen = new ByteArrayContent(usuario.Fotografia);
                        contenidoImagen.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                        foto.Add(contenidoImagen, "fotografia", "fotografiaPerfilAspirante.jpg");

                        string endpointFoto = string.Format("http://localhost:5000/v1/PerfilUsuarios/{0}/fotografia", idUsuario);
                        respuesta = await cliente.PatchAsync(endpointFoto, foto);

                        if (respuesta.StatusCode == HttpStatusCode.OK)
                        {
                            MultipartFormDataContent video = new MultipartFormDataContent();
                            var contenidoVideo = new ByteArrayContent(aspirante.RegistroVideo);
                            contenidoVideo.Headers.ContentType = MediaTypeHeaderValue.Parse("video/mp4");
                            video.Add(contenidoVideo, "video", "videoPerfilAspirante.mp4");

                            string endpointVideo = string.Format("http://localhost:5000/v1/perfilAspirantes/{0}/video", idAspirante);
                            respuesta = await cliente.PatchAsync(endpointVideo, video);

                            if (respuesta.StatusCode == HttpStatusCode.OK)
                            {
                                resultado = 1;
                            }
                            else
                            {
                                respuestaAPI.gestionRespuestasApi("Post Aspirante/video", respuesta);
                            }
                        }
                        else
                        {
                            respuestaAPI.gestionRespuestasApi("Post Aspirante/Foto", respuesta);
                        }

                    }

                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("Conexion en este momento no disponible", "¡Operacion!");
                }
                finally
                {
                    cliente.Dispose();
                }


            }

            return resultado;
        }

        public static async Task<int> putAspirante(Modelo.clases.Aspirante aspirante, bool video) // por probar
        {
            int resultado = -1;
            int idUsuario = -1;
            int idAspirante = -1;

            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", aspirante.Token);
                string endpoint = string.Format("http://localhost:5000/v1/perfilAspirantes/{0}", aspirante.IdAspirante);

                try
                {
                    HttpRequestMessage cuerpoMensaje = new HttpRequestMessage();
                    JArray arregloOficiosJson = new JArray();

                    foreach (Oficio item in aspirante.Oficios)
                    {
                        JObject oficioJson = new JObject();
                        oficioJson.Add("idCategoria", item.IdCategoria);
                        oficioJson.Add("experiencia", item.Experiencia);
                        arregloOficiosJson.Add(oficioJson);
                    }

                    JObject objeto = new JObject();
                    objeto.Add("clave", aspirante.Clave);
                    objeto.Add("correoElectronico", aspirante.CorreoElectronico);
                    objeto.Add("direccion", aspirante.Direccion);
                    objeto.Add("estatus", 1);
                    string fecha = string.Format("{0:yyyy-MM-dd}", aspirante.FechaNacimiento);
                    objeto.Add("fechaNacimiento", fecha);
                    objeto.Add("nombre", aspirante.NombreAspirante);
                    objeto.Add("nombreUsuario", aspirante.NombreUsuario);
                    objeto.Add("oficios", arregloOficiosJson);
                    objeto.Add("telefono", aspirante.Telefono);
                    objeto.Add("idPerfilUsuario", aspirante.IdPerfilusuario);

                    string cuerpoJson = JsonConvert.SerializeObject(objeto);
                    var data = new StringContent(cuerpoJson, Encoding.UTF8, "application/json");

                    HttpResponseMessage respuesta = await cliente.PutAsync(endpoint, data);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        JObject actualizacionAspirante = JObject.Parse(body);
                        idUsuario = (int)actualizacionAspirante["idPerfilUsuario"];
                        idAspirante = (int)actualizacionAspirante["idPerfilAspirante"];

                        MultipartFormDataContent foto = new MultipartFormDataContent();
                        var contenidoImagen = new ByteArrayContent(aspirante.Fotografia);
                        contenidoImagen.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                        foto.Add(contenidoImagen, "fotografia", "fotografiaPerfilAspirante.jpg");

                        string endpointFoto = string.Format("http://localhost:5000/v1/PerfilUsuarios/{0}/fotografia", idUsuario);
                        respuesta = await cliente.PatchAsync(endpointFoto, foto);

                        if (respuesta.StatusCode == HttpStatusCode.OK)
                        {
                            resultado = 0;
                            if (video)
                            {
                                MultipartFormDataContent videoEdicion = new MultipartFormDataContent();
                                var contenidoVideo = new ByteArrayContent(aspirante.RegistroVideo);
                                contenidoVideo.Headers.ContentType = MediaTypeHeaderValue.Parse("video/mp4");
                                videoEdicion.Add(contenidoVideo, "video", "videoPerfilAspirante.mp4");

                                string endpointVideo = string.Format("http://localhost:5000/v1/perfilAspirantes/{0}/video", idAspirante);
                                respuesta = await cliente.PatchAsync(endpointVideo, videoEdicion);

                                if (respuesta.StatusCode == HttpStatusCode.OK)
                                {
                                    resultado = 1;
                                }
                                else
                                {
                                    respuestaAPI.gestionRespuestasApi("Post Aspirante/video", respuesta);
                                }
                            }
                            
                        }
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("put Aspirante", respuesta);
                    }

                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }
                finally
                {
                    cliente.Dispose();
                }
            }
            
            return resultado;
        }

        public static async Task<clases.Aspirante> GetAspirante(int idUsuarioAspirante, string token)
        {
            clases.Aspirante aspirante = new clases.Aspirante();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = string.Format("http://localhost:5000/v1/perfilAspirantes/{0}", idUsuarioAspirante);

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        List<Oficio> listaOficios = new List<Oficio>();
                        JObject perfilAspirante = JObject.Parse(body);
                        aspirante.Direccion = (string)perfilAspirante["direccion"];
                        aspirante.FechaNacimiento = (DateTime)perfilAspirante["fechaNacimiento"];
                        aspirante.IdAspirante = (int)perfilAspirante["idPerfilAspirante"];
                        aspirante.NombreAspirante = (string)perfilAspirante["nombre"];
                        aspirante.IdPerfilusuario = (int)perfilAspirante["idPerfilUsuario"];
                        aspirante.Telefono = (string)perfilAspirante["telefono"];
                        JArray oficios = (JArray)perfilAspirante["oficios"];
                        foreach (var items in oficios)
                        {
                            Oficio oficio = new Oficio();
                            oficio.IdAspirante = (int)items["idAspirante"];
                            oficio.IdCategoria = (int)items["idCategoria"];
                            oficio.Experiencia = (string)items["experiencia"];
                            listaOficios.Add(oficio);
                        }
                        aspirante.Oficios = listaOficios;
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Post Aspirante", respuesta);
                    }

                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }
                finally
                {
                    cliente.Dispose();
                }


            }

            return aspirante;
        }

        public static async Task<List<clases.Aspirante>> GetAspirantes(string token) // listo api
        {
            List<clases.Aspirante> aspirantes = new List<clases.Aspirante>();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = string.Format("http://localhost:5000/v1/perfilAspirantes");

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        JArray arrayAspirantes = JArray.Parse(body);


                        foreach (var item in arrayAspirantes)
                        {
                            clases.Aspirante aspirante = new clases.Aspirante();
                            aspirante.Direccion = (string)item["direccion"];
                            aspirante.FechaNacimiento = (DateTime)item["fechaNacimiento"];
                            aspirante.IdAspirante = (int)item["idPerfilAspirante"];
                            aspirante.NombreAspirante = (string)item["nombre"];
                            aspirante.Telefono = (string)item["telefono"];
                            aspirantes.Add(aspirante);
                        }
                     
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Get Aspirantes", respuesta);
                    }
                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }
                finally
                {
                    cliente.Dispose();
                }
            }

            return aspirantes;
        }

        public async static Task<MemoryStream> GetVideo(int idAspirante, string token)
        {
            MemoryStream stream = null;
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = string.Format("http://localhost:5000/v1/perfilAspirantes/{0}/video", idAspirante);

                try
                {
                    var respuesta = await cliente.GetAsync(endpoint);
                    Stream streamVideo = await respuesta.Content.ReadAsStreamAsync();
                    
                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if(respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        stream = new MemoryStream();
                        streamVideo.CopyTo(stream);
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Get Video", respuesta);
                    }



                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }
                finally
                {
                    cliente.Dispose();
                }
            }

            return stream;
        }

    }

}


