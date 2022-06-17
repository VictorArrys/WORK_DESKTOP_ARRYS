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

namespace El_Camello.Modelo.dao
{
    internal class AspiranteDAO
    {

        public static async Task<int> PostAspirante(Usuario usuario, clases.Aspirante aspirante)
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
                    string body = await respuesta.Content.ReadAsStringAsync();//Falla con respuestas largas
                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            JObject perfilAspirante = JObject.Parse(body);
                            aspirante.Direccion = (string)perfilAspirante["direccion"];
                            aspirante.FechaNacimiento = (DateTime)perfilAspirante["fechaNacimiento"];
                            aspirante.IdAspirante = (int)perfilAspirante["idPerfilAspirante"];
                            aspirante.NombreAspirante = (string)perfilAspirante["nombre"];
                            aspirante.IdPerfilusuario = (int)perfilAspirante["idPerfilUsuario"];
                            //aspirante.Oficios = perfilAspirante["oficios"];
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


            }

            return aspirante;
        }

        public static async Task<List<clases.Aspirante>> GetAspirantes(string token)
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

                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:
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
                            break;
                    }
                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }
            }

            return aspirantes;
        }

    }

}

/*Dictionary<string, string> parametros = new Dictionary<string, string>();

                    //terminar diccionario
                    parametros.Add("clave", usuario.Clave);
                    parametros.Add("correoElectronico", usuario.CorreoElectronico);
                    parametros.Add("direccion", aspirante.Direccion);
                    parametros.Add("estatus", usuario.Estatus);
                    //parametros.Add("fechaNacimiento", (string) aspirante.FechaNacimiento);
                    parametros.Add("nombre", aspirante.NombreAspirante);
                    parametros.Add("nombreUsuario", usuario.NombreUsuario);
                    //parametros.Add("oficios", aspirante.Oficios);
                    parametros.Add("telefono", aspirante.Telefono);

                    //parametros

                    var nombreFotografia = Path.GetFileName(usuario.RutaFotografia);
                    var nombreCurriculum = Path.GetFileName(aspirante.RutaCurriculum);
                    var nombreVideo = Path.GetFileName(aspirante.RutaVideo);

                    var fotografiaStream = File.OpenRead(usuario.RutaFotografia);
                    var curriculumStream = File.OpenRead(aspirante.RutaCurriculum);
                    var videoStream = File.OpenRead(aspirante.RutaVideo);

                    var respuestaContenido = new MultipartFormDataContent();

                    var contenidoFoto = new StreamContent(fotografiaStream);
                    var contenidoVideo = new StreamContent(curriculumStream);
                    var contenidoDocumento = new StreamContent(videoStream);

                    contenidoFoto.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
                    contenidoDocumento.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                    contenidoDocumento.Headers.ContentType = new MediaTypeHeaderValue("video/mp4");




                    respuestaContenido.Add(contenidoFoto, "fotografia", nombreFotografia);
                    respuestaContenido.Add(contenidoDocumento, "curriculum", nombreCurriculum);
                    respuestaContenido.Add(contenidoVideo, "video", nombreVideo);

                    HttpContent DictionaryItems = new FormUrlEncodedContent(parametros);
                    respuestaContenido.Add(DictionaryItems, "aspirante");

                    //var data = new StringContent((string)DictionaryItems, Encoding.UTF8, "application/json");


                    HttpResponseMessage respuesta = await cliente.PostAsync(endpoint, respuestaContenido);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.Created:
                            MessageBox.Show(body);
                            break;
                        case HttpStatusCode.Unauthorized:
                        case HttpStatusCode.InternalServerError:
                        case HttpStatusCode.NotFound:
                            JObject codigo = JObject.Parse(body);
                            string mensaje = (string)codigo["resBody"]["menssage"];
                            MessageBox.Show(mensaje);
                            break;
                    }*/
