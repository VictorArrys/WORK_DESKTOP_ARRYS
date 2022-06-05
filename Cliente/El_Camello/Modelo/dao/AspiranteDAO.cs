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
            int res =  -1;
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
                        oficioJson.Add("experiencia",item.Experiencia);
                        arregloOficiosJson.Add(oficioJson);
                    }
                    
                    HttpRequestMessage cuerpoMensaje = new HttpRequestMessage();
                    JObject objeto = new JObject();
                    objeto.Add("clave",usuario.Clave);
                    objeto.Add("correoElectronico", usuario.CorreoElectronico);
                    objeto.Add("direccion", aspirante.Direccion);
                    objeto.Add("estatus", 1);
                    objeto.Add("fechaNacimiento", aspirante.FechaNacimiento);
                    objeto.Add("nombre", aspirante.NombreAspirante);
                    objeto.Add("nombreUsuario", usuario.NombreUsuario);
                    objeto.Add("oficios", arregloOficiosJson);
                    string cuerpoJson = JsonConvert.SerializeObject(objeto);
                    MessageBox.Show(cuerpoJson);
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
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }


            }

            return res;
        }

    }
}
