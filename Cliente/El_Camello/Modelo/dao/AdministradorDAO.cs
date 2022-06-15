using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace El_Camello.Modelo.dao
{
    internal class AdministradorDAO
    {
        public static async Task<clases.Administrador> getAdministrador(int idUsuario, string token) // listo
        {
            clases.Administrador administrador = new clases.Administrador();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = String.Format("http://localhost:5000/v1/perfilAdministradores/{0}", idUsuario);

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            JObject perfilAdministrador = JObject.Parse(body);
                            administrador.IdPerfilAdministrador = (int)perfilAdministrador["idPerfilAdministrador"];
                            administrador.IdPerfilusuario = (int)perfilAdministrador["idPerfilUsuarioAdmin"];
                            administrador.Nombre = (string)perfilAdministrador["nombre"];
                            administrador.Telefono = (string)perfilAdministrador["telefono"];   
                            break;
                    }
                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("verificar servidor");
                }
            }
            
            return administrador;
        }

        public static async Task<List<clases.Administrador>> getAdministradores(string token) // probar
        {
            List<clases.Administrador> administradores = new List<clases.Administrador>();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = "http://localhost:5000/v1/perfilAdministradores";
                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string body = await respuesta.Content.ReadAsStringAsync();

                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            JArray arrayAdministradores = JArray.Parse(body);

                            foreach (var item in arrayAdministradores)
                            {
                                clases.Administrador administrador = new clases.Administrador();
                                administrador.IdPerfilAdministrador = (int)item["idPerfilUsuarioAdmin"];
                                administrador.IdPerfilusuario = (int)item["idPerfilUsuarioAdmin"];
                                administrador.Nombre = (string)item["nombre"];
                                administrador.Telefono = (string)item["telefono"];
                                administradores.Add(administrador);
                            }
                            break;
                    }
                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("verificar servidor");
                }
            }

            return administradores;
        }

        public static async Task<int> putAdministrador(clases.Administrador administrador) // probar
        {
            int resultado = -1;
            int idUsuario = -1;
            int idPerfilAdministrador = -1;

            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", administrador.Token);
                string endpoint = string.Format("http://localhost:5000/v1/perfilAdministradores/{0}", administrador.IdPerfilAdministrador);
                try
                {
                    HttpRequestMessage cuerpoMensaje = new HttpRequestMessage();
                    JObject objeto = new JObject();
                    objeto.Add("nombre", administrador.Nombre);
                    objeto.Add("telefono", administrador.Telefono);
                    objeto.Add("nombreUsuario", administrador.NombreUsuario);
                    objeto.Add("clave", administrador.Clave);
                    objeto.Add("correoElectronico", administrador.CorreoElectronico);

                    string cuerpoJson = JsonConvert.SerializeObject(objeto);
                    var data = new StringContent(cuerpoJson, Encoding.UTF8, "application/json");

                    HttpResponseMessage respuesta = await cliente.PutAsync(endpoint, data);
                    string body = await respuesta.Content.ReadAsStringAsync();

                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            JObject modificarAdministrador = JObject.Parse(body);
                            idUsuario = (int)modificarAdministrador["idPerfilUsuarioAdmin"];
                            idPerfilAdministrador = (int)modificarAdministrador["idPerfilUsuarioAdmin"];
                            resultado = 1;
                            break;
                    }
                }
                catch (HttpRequestException)
                {

                }
            }
            return resultado;
        }
    }

}
