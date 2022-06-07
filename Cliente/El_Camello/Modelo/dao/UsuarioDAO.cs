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
                //HttpResponseMessage respuesta = await client.GetAsync(query);
                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            JObject user = JsonConvert.DeserializeObject<JObject>(body);
                            //usuario.Fotografia = Encoding.ASCII.GetBytes((string)user["fotografia"]);

                            JObject arrayu = (JObject)user["fotografia"];
                            byte[] segmentosFoto = new byte[arrayu.Count];
                            //MessageBox.Show((string)arrayu);

                            for (int i =0; i < arrayu.Count; i++)
                            {
                                segmentosFoto[i] = (byte)arrayu[i.ToString()];
                            }

                            usuario.Fotografia = segmentosFoto;
                            usuario.Clave = (string)user["clave"];
                            usuario.Tipo = (string)user["tipo"];
                            usuario.Estatus = (string)user["estatus"];
                            usuario.IdPerfilusuario = (int)user["idPerfilusuario"];
                            usuario.CorreoElectronico = (string)user["correoElectronico"];
                            usuario.Token = (string)user["token"];


                            

                            //JArray fotografia = (JArray)user["fotografia"];
                            //BinaryFormatter bf = new BinaryFormatter();
                            //MemoryStream ms = new MemoryStream();
                            //bf.Serialize(ms, fotografia);

                            //usuario.Fotografia = ms.ToArray();
                            break;
                        case HttpStatusCode.Unauthorized:
                        case HttpStatusCode.InternalServerError:
                        case HttpStatusCode.NotFound:
                            JObject codigo = JObject.Parse(body);
                            string mensaje = (string)codigo["resBody"]["menssage"];
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
