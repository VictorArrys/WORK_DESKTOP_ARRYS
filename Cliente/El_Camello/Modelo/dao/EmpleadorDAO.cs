using El_Camello.Modelo.clases;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace El_Camello.Modelo.dao
{
    internal class EmpleadorDAO
    {
        public static async Task<int> PostEmpleador(Usuario usuario, clases.Empleador empleador)
        {
            int resultado = -1;
            int idUsuario = -1;
            int idEmpleador = -1;
            using (var cliente = new HttpClient())
            {
                string endpoint = "http://localhost:5000/v1/perfilEmpleadores";
                HttpRequestMessage cuerpoMensaje = new HttpRequestMessage();
                JObject objeto = new JObject();
                objeto.Add("clave", usuario.Clave);
                objeto.Add("correoElectronico", usuario.CorreoElectronico);
                objeto.Add("direccion", empleador.Direccion);
                objeto.Add("estatus", usuario.Estatus);
                string fecha = string.Format("{0:yyyy-MM-dd}", empleador.FechaNacimiento);
                objeto.Add("fechaNacimiento", fecha);
                objeto.Add("nombre", empleador.NombreEmpleador);
                objeto.Add("nombreOrganizacion", empleador.NombreOrganizacion);
                objeto.Add("telefono", empleador.Telefono);
                objeto.Add("nombreusuario", usuario.NombreUsuario);

                string cuerpoJson = JsonConvert.SerializeObject(objeto);
                var data = new StringContent(cuerpoJson, Encoding.UTF8, "application/json");

                HttpResponseMessage respuesta = await cliente.PostAsync(endpoint, data);
                string body = await respuesta.Content.ReadAsStringAsync();

                switch (respuesta.StatusCode)
                {
                    case HttpStatusCode.Created:
                        JObject registroExitoso = JObject.Parse(body);
                        idUsuario = (int)registroExitoso["idPerfilUsuario"];
                        idEmpleador = (int)registroExitoso["idPerfilAspirante"];
                        

                        MultipartFormDataContent foto = new MultipartFormDataContent();
                        var contenidoImagen = new ByteArrayContent(usuario.Fotografia);
                        contenidoImagen.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                        foto.Add(contenidoImagen, "fotografia", "fotografiaPerfilEmpleador.jpg");

                        string endpointFoto = string.Format("http://localhost:5000/v1/PerfilUsuarios/{0}/fotografia", idUsuario);
                        respuesta = await cliente.PatchAsync(endpointFoto, foto);
                        switch (respuesta.StatusCode)
                        {
                            case HttpStatusCode.OK:
                                resultado = idUsuario;
                                break;
                        }
                        break;
                }
            }
            
            return resultado;
        }

        public static async Task<Modelo.clases.Empleador> getEmpleador(int idUsuarioEmpleador, string token)//probar
        {
            Modelo.clases.Empleador empleador = new Modelo.clases.Empleador();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = string.Format("http://localhost:5000/v1/perfilEmpleadores/{0}", idUsuarioEmpleador);

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:

                            JObject perfilEmpleador = JObject.Parse(body);
                            /*empleador.Direccion = (string)perfilEmpleador["direccion"];
                            empleador.FechaNacimiento = (DateTime)perfilEmpleador["fechaNacimiento"];
                            empleador.NombreEmpleador = */
                            break;

                    }
                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("verificar servidor");
                }
            }

            return empleador;
        }

        public static async Task<List<clases.Empleador>> getEmpleadores(string token) // probar
        {
            List<clases.Empleador> empleadores = new List<clases.Empleador>();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = string.Format("http://localhost:5000/v1/perfilEmpleadores");

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string body = await respuesta.Content.ReadAsStringAsync();

                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            JArray arrayEmpleadores = JArray.Parse(body);
                            MessageBox.Show(arrayEmpleadores.ToString());


                            foreach (var item in arrayEmpleadores)
                            {
                                clases.Empleador empleador = new clases.Empleador();
                                empleador.IdPerfilEmpleador = (int)item["idPerfilEmpleador"];
                                empleador.IdPerfilEmpleador = (int)item["idPerfilUsuarioEmpleador"];
                                empleador.NombreEmpleador = (string)item["nombreOrganizacion"];
                                empleador.NombreEmpleador = (string?)item["nombre"];
                                empleador.Direccion = (string)item["direccion"];
                                empleador.FechaNacimiento = (DateTime)item["fechaNacimiento"];
                                empleador.Telefono = (string)item["telefono"];
                                empleador.Amonestaciones = (int)item["amonestaciones"];
                            }
                            break;
                    }
                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }
            }

            return empleadores;
        }

        public static async Task<int> putEmpleador(Modelo.clases.Empleador empleador) //probar
        {
            int resultado = -1;
            int idUsuario = 0;
            int idPerfilEmpleador;
            using (var cliente = new HttpClient())
            {
                try
                {
                    cliente.DefaultRequestHeaders.Add("x-access-token", empleador.Token);
                    string endpoint = string.Format("http://localhost:5000/v1/perfilEmpleadores/{0}", empleador.IdPerfilusuario);

                    HttpRequestMessage cuerpoMensaje = new HttpRequestMessage();
                    JObject objeto = new JObject();
                    objeto.Add("clave", empleador.Clave);
                    objeto.Add("correoElectronico", empleador.CorreoElectronico);
                    objeto.Add("direccion", empleador.Direccion);
                    objeto.Add("estatus", empleador.Estatus);
                    string fecha = string.Format("{0:yyyy-MM-dd}", empleador.NombreEmpleador);
                    objeto.Add("fechaNacimiento", empleador.NombreEmpleador);
                    objeto.Add("nombreOrganizacion", empleador.NombreOrganizacion);
                    objeto.Add("telefono", empleador.Telefono);
                    objeto.Add("nombreusuario", empleador.NombreUsuario);

                    string cuerpoJson = JsonConvert.SerializeObject(objeto);
                    var data = new StringContent(cuerpoJson, Encoding.UTF8, "application/json");

                    HttpResponseMessage respuesta = await cliente.PutAsync(endpoint, data);
                    string body = await respuesta.Content.ReadAsStringAsync();

                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            Modelo.clases.Empleador modificarEmpleador = new Modelo.clases.Empleador();
                            JObject perfilEmpleador = JObject.Parse(body);
                            idUsuario = (int)perfilEmpleador["idPerfilUsuario"];
                            idPerfilEmpleador = (int)perfilEmpleador["idPerfilAspirante"];

                            MultipartFormDataContent foto = new MultipartFormDataContent();
                            var contenidoImagen = new ByteArrayContent(empleador.Fotografia);
                            contenidoImagen.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                            foto.Add(contenidoImagen, "fotografia", "fotografiaPerfilEmpleador.jpg");
                            string endpointfoto = String.Format("http://localhost:5000/v1/PerfilUsuarios/{0}/fotografia", empleador.IdPerfilusuario);
                            respuesta = await cliente.PatchAsync(endpointfoto, foto);

                            switch (respuesta.StatusCode)
                            {
                                case HttpStatusCode.OK:
                                    resultado = 1;
                                    break;
                                case HttpStatusCode.NotFound:
                                    break;
                                case HttpStatusCode.InternalServerError:
                                    break;
                            }
                            break;
                    }


                }
                catch (Exception)
                {

                }
            }

            return resultado;
        }
        
    }
}
