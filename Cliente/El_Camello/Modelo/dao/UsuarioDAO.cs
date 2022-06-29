using El_Camello.Assets.utilerias;
using El_Camello.Modelo.clases;
using El_Camello.Configuracion;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace El_Camello.Modelo.dao
{
    internal class UsuarioDAO
    {
        public static async Task<Usuario> iniciarSesion(string nombreUsuario, string clave)
        {
            MensajesSistema mensajes;
            Usuario usuario = new Usuario();
            using (var cliente = new HttpClient())
            {
                string endpoint = string.Format("{0}/v1/iniciarSesion?nombreUsuario={1}&clave={2}", Settings.ElCamelloURL,nombreUsuario, clave);
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

                    }else if(respuesta.StatusCode == HttpStatusCode.NotFound)
                    {
                        mensajes = new MensajesSistema("AccionInvalida", "Credenciales incorrectas o usuario no existente", "Iniciar sesión", "Verifique sus credenciales o cree una cuenta si no tiene una");
                        mensajes.ShowDialog();
                    }

                    else if (respuesta.StatusCode == HttpStatusCode.Forbidden)
                    {
                        mensajes = new MensajesSistema("Prohibido", "Debido a los diferentes reportes que se presentan en tu perfil haz sido bloqueado indefinidamente del sistema", "Iniciar sesión", "Contacta al soporte técnico elcamello@outllok.com para resolver tu situación");
                        mensajes.ShowDialog();
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Iniciar sesion", respuesta);
                    }

                }
                catch (HttpRequestException ex)
                {
                    mensajes = new MensajesSistema("Error", "La conexión no se puede establecer en este momento, intente mas tarde", ex.StackTrace, ex.Message);
                    mensajes.ShowDialog();
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
            MensajesSistema errorMessage;
            Usuario usuario = new Usuario();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = string.Format("{0}/v1/PerfilUsuarios/{1}", Settings.ElCamelloURL, idUsuario);

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
                catch (HttpRequestException ex)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Obtener usuario", ex.Message);
                    errorMessage.ShowDialog();
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
            MensajesSistema errorMessage;
            List<clases.Usuario> usuarios = new List<clases.Usuario>();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = $"{Settings.ElCamelloURL}/v1/perfilUsuarios";
                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if (respuesta.StatusCode == HttpStatusCode.OK) {
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
                catch (HttpRequestException ex)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Obtener lista de usuarios", ex.Message);
                    errorMessage.ShowDialog();
                }
                finally
                {
                    cliente.Dispose();
                }
            }

            return usuarios;
        }

        public static async Task<Tuple<int, string>> patchDeshabilitar(int idUsuario, string token) // Listo cliente
        {
            MensajesSistema errorMessage;
            int resultado = -1;
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = String.Format("{0}/v1/perfilUsuarios/{1}/deshabilitar", Settings.ElCamelloURL,idUsuario);

                try
                {
                    HttpResponseMessage respuesta = await cliente.PatchAsync(endpoint, null);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        resultado = 1;
                        token = respuesta.Headers.GetValues("x-access-token").First();
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("patch deshabilitar", respuesta);
                    }

                }
                catch (HttpRequestException ex)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Deshabilitar usuario", ex.Message);
                    errorMessage.ShowDialog();
                }
                finally
                {
                    cliente.Dispose();
                }
            }
            return Tuple.Create(resultado, token);
        }

        public static async Task<Tuple<int, string>> patchHabilitar(int idUsuario,string token)// listo cliente
        {
            MensajesSistema errorMessage;
            int resultado = -1;
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = String.Format("{0}/v1/perfilUsuarios/{1}/habilitar", Settings.ElCamelloURL,idUsuario);

                try
                {
                    HttpResponseMessage respuesta = await cliente.PatchAsync(endpoint, null);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        resultado = 1;
                        token = respuesta.Headers.GetValues("x-access-token").First();
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("patch habilitar", respuesta);
                    }
                }
                catch (HttpRequestException ex)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Habilitar usuario", ex.Message);
                    errorMessage.ShowDialog();
                }
                finally
                {
                    cliente.Dispose();
                }
            }
            return Tuple.Create(resultado, token);
        }
    }
}
