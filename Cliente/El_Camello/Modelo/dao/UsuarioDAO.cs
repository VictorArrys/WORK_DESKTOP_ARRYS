using El_Camello.Modelo.clases;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace El_Camello.Modelo.dao
{
    internal class UsuarioDAO
    {
        public static async Task<Usuario> iniciarSesion(string nombreUsuario, string clave)
        {
            Usuario usuario = new Usuario();
            using (var cliente = new HttpClient())
            {
                string endpoint = string.Format("http://localhost:5000/v1/iniciarSesion?nombreUsuario={0}&clave={1}", nombreUsuario, clave);
                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            JObject user = JsonConvert.DeserializeObject<JObject>(body);

                            try
                            {
                                JObject arrayFoto = (JObject)user["fotografia"];
                                byte[] segmentosFoto = new byte[arrayFoto.Count];

                                for (int i = 0; i < arrayFoto.Count; i++)
                                {
                                    segmentosFoto[i] = (byte)arrayFoto[i.ToString()];
                                }

                                usuario.Fotografia = segmentosFoto;
                            }
                            catch (InvalidCastException)
                            {
                                usuario.Fotografia = null;
                            }
                            

                            usuario.Clave = (string)user["clave"];
                            usuario.Tipo = (string)user["tipoUsuario"];
                            usuario.Estatus = (string)user["estatus"];
                            usuario.IdPerfilusuario = (int)user["idPerfilusuario"];
                            usuario.CorreoElectronico = (string)user["correoElectronico"];
                            usuario.Token = respuesta.Headers.GetValues("x-access-token").First();
                            //usuario.Token = (string)user["token"];
                            break;
                        case HttpStatusCode.Unauthorized:
                        case HttpStatusCode.InternalServerError:
                        case HttpStatusCode.NotFound:
                            JObject codigo = JObject.Parse(body);
                            string mensaje = (string)codigo["type error"]["message"];
                            MessageBox.Show(mensaje);
                            usuario = null;
                            break;
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }

            }

            return usuario;
        } 
    }
}
