using El_Camello.Assets.utilerias;
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
        public static async Task<Usuario> iniciarSesion(string nombreUsuario, string clave)  // listo en cliente
        {
            Usuario usuario = new Usuario();
            using (var cliente = new HttpClient())
            {
                string endpoint = string.Format("http://localhost:5000/v1/iniciarSesion?nombreUsuario={0}&clave={1}", nombreUsuario, clave);
                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    RespuestasAPI respuestaAPI = new RespuestasAPI();
                    

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        string body = await respuesta.Content.ReadAsStringAsync();

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
                        usuario.Estatus = (int)user["estatus"];
                        usuario.IdPerfilusuario = (int)user["idPerfilUsuario"];
                        usuario.CorreoElectronico = (string)user["correoElectronico"];
                        usuario.NombreUsuario = (string)user["nombre"];
                        usuario.Token = respuesta.Headers.GetValues("x-access-token").First();

                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Iniciar sesion", respuesta);
                    }

                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("La conexión no se puede establecer en este momento, intente mas tarde", "Inciciar Sesión.");
                }
                finally
                {
                    cliente.CancelPendingRequests();
                    cliente.Dispose();
                }

            }

            return usuario;
        }
        
        public static async Task<Usuario> getUsuario(int idUsuario, string token)// listo cliente
        {
            Usuario usuario = new Usuario();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = string.Format("http://localhost:5000/v1/PerfilUsuarios/{0}", idUsuario);

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
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
                        usuario.Estatus = (int)user["estatus"];
                        usuario.IdPerfilusuario = (int)user["idPerfilusuario"];
                        usuario.CorreoElectronico = (string)user["correoElectronico"];
                        usuario.NombreUsuario = (string)user["nombre"];
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("get usuario", respuesta);
                    }
                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("Conexion en este momento no disponible", "¡Operacion!");
                }
                finally
                {
                    cliente.Dispose();
                }
            }

                return usuario;
        }

        public static async Task<List<clases.Usuario>> getUsuarios(string token) // listo cliente
        {
            List<clases.Usuario> usuarios = new List<clases.Usuario>();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = "http://localhost:5000/v1/perfilUsuarios";
                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if(respuesta.StatusCode == HttpStatusCode.OK){
                        JArray arrayUsuarios = JArray.Parse(body);
                        foreach (var item in arrayUsuarios)
                        {
                            clases.Usuario usuario = new clases.Usuario();
                            usuario.IdPerfilusuario = (int)item["idPerfilUsuario"];
                            usuario.NombreUsuario = (string)item["nombreUsuario"];
                            usuario.Estatus = (int)item["estatus"];
                            usuario.Clave = (string)item["clave"];
                            usuario.CorreoElectronico = (string)item["correoElectronico"];
                            usuario.Tipo = (string)item["tipoUsuario"];
                            usuarios.Add(usuario);
                        }
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("get usuarios", respuesta);
                    }

                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("Conexion en este momento no disponible", "¡Operacion!");
                }
                finally
                {
                    cliente.Dispose();
                }
            }

            return usuarios;
        }

        public static async Task<int> patchDeshabilitar(int idUsuario,string token) // Listo cliente
        {
            int resultado = -1;
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = String.Format("http://localhost:5000/v1/perfilUsuarios/{0}/deshabilitar", idUsuario);

                try
                {
                    HttpResponseMessage respuesta = await cliente.PatchAsync(endpoint, null);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        resultado = 1;
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("patch deshabilitar", respuesta);
                    }

                }
                catch (HttpRequestException)
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

        public static async Task<int> patchHabilitar(int idUsuario,string token)// listo cliente
        {
            int resultado = -1;
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = String.Format("http://localhost:5000/v1/perfilUsuarios/{0}/habilitar", idUsuario);

                try
                {
                    HttpResponseMessage respuesta = await cliente.PatchAsync(endpoint, null);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        resultado = 1;
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("patch habilitar", respuesta);
                    }
                }
                catch (HttpRequestException)
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
    }
}
