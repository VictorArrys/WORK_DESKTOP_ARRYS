using El_Camello.Modelo.clases;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public static async Task<int> PostAspirante(Usuario usuario, clases.Aspirante aspirante) //intermedio
        {

            int res = -1;
            Modelo.clases.Aspirante aspiranteRegistro = new Modelo.clases.Aspirante();
            using (var cliente = new HttpClient())
            {
                
                string endpoint = "http://localhost:5000/v1/perfilAspirantes";

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

                    HttpRequestMessage cuerpoMensaje = new HttpRequestMessage();
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
                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            aspiranteRegistro = new Modelo.clases.Aspirante();
                            JObject perfilAspirante = JObject.Parse(body);
                            MessageBox.Show(body);
                            /*JArray oficios = new JArray();
                            aspiranteRegistro.Clave = (string)perfilAspirante["clave"];
                            aspiranteRegistro.CorreoElectronico = (string)perfilAspirante["correo_electronico"];
                            aspirante.Direccion = (string)perfilAspirante["direccion"];
                            aspiranteRegistro.Estatus = (string)perfilAspirante["estatus"];
                            aspiranteRegistro.FechaNacimiento = (DateTime)perfilAspirante["fecha_nacimiento"];
                            aspiranteRegistro.IdPerfilusuario = (int)perfilAspirante["id_perfil_usuario"];
                            aspiranteRegistro.NombreAspirante = (string)perfilAspirante["nombre"];
                            aspiranteRegistro.NombreUsuario = (string)perfilAspirante["nombre_usuario"];*/

                            break;
                        case HttpStatusCode.Unauthorized:
                        case HttpStatusCode.InternalServerError:
                        case HttpStatusCode.NotFound:
                            JObject codigo = JObject.Parse(body);
                            string mensaje = (string)codigo["type error"]["message"];
                            MessageBox.Show(mensaje);
                            break;
                    }

                    MultipartFormDataContent foto = new MultipartFormDataContent();

                    var contenidoImagen = new ByteArrayContent(usuario.Fotografia);
                    contenidoImagen.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                    foto.Add(contenidoImagen, "fotografia", "fotografiaPerfil.jpg");

                    //falta video

                    //string endpointfoto = String.Format("http://localhost:5000/v1/perfilAspirantes/{0}/{1}",foto);

                    //HttpResponseMessage respuesta = await cliente.PostAsync(endpoint, foto);
                    //HttpContent fotoContenido = new StreamContent(File.OpenRead(usuario.RutaFotografia));
                    //foto.Add(fotoContenido, "fotografia", "fotoPerfil.jpg");



                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }
                finally
                {
                    cliente.Dispose();
                }


            }

            return res;
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
                    MessageBox.Show(body);
                    
                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            JObject perfilAspirante = JObject.Parse(body);
                            aspirante.Direccion = (string)perfilAspirante["direccion"];
                            aspirante.FechaNacimiento = (DateTime)perfilAspirante["fechaNacimiento"];
                            aspirante.IdAspirante = (int)perfilAspirante["idPerfilAspirante"];
                            aspirante.NombreAspirante = (string)perfilAspirante["nombre"];
                            aspirante.IdPerfilusuario = (int)perfilAspirante["idPerfilUsuario"];
                            aspirante.Telefono = (string)perfilAspirante["telefono"];
                            




                            break;
                        case HttpStatusCode.Unauthorized:
                        case HttpStatusCode.InternalServerError:
                        case HttpStatusCode.NotFound:
                            JObject codigo = JObject.Parse(body);
                            string mensaje = (string)codigo["type error"]["message"];
                            MessageBox.Show(mensaje);
                            break;
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


