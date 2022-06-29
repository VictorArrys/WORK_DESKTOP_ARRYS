using El_Camello.Assets.utilerias;
using El_Camello.Configuracion;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace El_Camello.Modelo.dao
{
    internal class AdministradorDAO
    {
        public static async Task<clases.Administrador> getAdministrador(int idUsuario, string token) // listo cliente
        {
            clases.Administrador administrador = new clases.Administrador();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = String.Format("{0}/v1/perfilAdministradores/{1}", Settings.ElCamelloURL, idUsuario);

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        JObject perfilAdministrador = JObject.Parse(body);
                        administrador.IdPerfilAdministrador = (int)perfilAdministrador["id_perfil_administrador"];
                        administrador.IdPerfilusuario = (int)perfilAdministrador["id_perfil_usuario_admin"];
                        administrador.Nombre = (string)perfilAdministrador["nombre"];
                        administrador.Telefono = (string)perfilAdministrador["telefono"];
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Get Administrador", respuesta);
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
            
            return administrador;
        }

        public static async Task<List<clases.Administrador>> getAdministradores(string token) // listo cliente
        {
            List<clases.Administrador> administradores = new List<clases.Administrador>();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = $"{Settings.ElCamelloURL}/v1/perfilAdministradores";

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        JArray arrayAdministradores = JArray.Parse(body);
                        foreach (var item in arrayAdministradores)
                        {
                            clases.Administrador administrador = new clases.Administrador();
                            administrador.IdPerfilAdministrador = (int)item["idPerfilAdministrador"];
                            administrador.IdPerfilusuario = (int)item["idPerfilUsuarioAdmin"];
                            administrador.Nombre = (string)item["nombre"];
                            administrador.Telefono = (string)item["telefono"];
                            administradores.Add(administrador);
                        }

                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Get Administradores", respuesta);
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

            return administradores;
        }

        public static async Task<int> putAdministrador(clases.Administrador administrador) // listo cliente
        {
            int resultado = -1;
            int idUsuario = -1;
            int idPerfilAdministrador = -1;

            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", administrador.Token);
                string endpoint = string.Format("{0}/v1/perfilAdministradores/{1}", Settings.ElCamelloURL, administrador.IdPerfilAdministrador);

                try
                {
                    HttpRequestMessage cuerpoMensaje = new HttpRequestMessage();
                    JObject objeto = new JObject();
                    objeto.Add("nombre", administrador.Nombre);
                    objeto.Add("telefono", administrador.Telefono);
                    objeto.Add("nombreUsuario", administrador.NombreUsuario);
                    objeto.Add("clave", administrador.Clave);
                    objeto.Add("correoElectronico", administrador.CorreoElectronico);
                    objeto.Add("idPerfilUsuario", administrador.IdPerfilusuario);

                    string cuerpoJson = JsonConvert.SerializeObject(objeto);
                    var data = new StringContent(cuerpoJson, Encoding.UTF8, "application/json");

                    HttpResponseMessage respuesta = await cliente.PutAsync(endpoint, data);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        JObject modificarAdministrador = JObject.Parse(body);
                        idUsuario = (int)modificarAdministrador["idPerfilUsuario"];
                        idPerfilAdministrador = (int)modificarAdministrador["idPerfilAdministrador"];
                        resultado = 1;
                    }

                }
                catch (HttpRequestException)
                {

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
