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
    internal class DemandanteDAO
    {
        public static async Task<int> PostDemandante(Usuario usuario, Demandante demandante)
        {
            int res = -1;
            Modelo.clases.Demandante registroDemandante = new Demandante();
            using (var cliente = new HttpClient())
            {
                string endpoint = "http://localhost:5000/v1/perfilDemandantes";

                HttpRequestMessage cuerpoMensaje = new HttpRequestMessage();
                JObject objeto = new JObject();
                objeto.Add("clave", usuario.Clave);
                objeto.Add("correoElectronico", usuario.CorreoElectronico);
                objeto.Add("direccion", demandante.Direccion);
                objeto.Add("estatus", usuario.Estatus);
                string fecha = string.Format("{0:yyyy-MM-dd}", demandante.FechaNacimiento);
                objeto.Add("fechaNacimiento", fecha);
                objeto.Add("nombre", demandante.NombreDemandante);
                objeto.Add("nombreUsuario", usuario.NombreUsuario);
                objeto.Add("telefono", demandante.Telefono);

                string cuerpoJson = JsonConvert.SerializeObject(objeto);
                var data = new StringContent(cuerpoJson, Encoding.UTF8, "application/json");

                HttpResponseMessage respuesta = await cliente.PostAsync(endpoint, data);
                string body = await respuesta.Content.ReadAsStringAsync();

                switch (respuesta.StatusCode)
                {
                    case HttpStatusCode.Created:
                        registroDemandante = new Demandante();
                        JObject perfilDemandante = JObject.Parse(body);

                        registroDemandante.Clave = (string)perfilDemandante["clave"];
                        registroDemandante.CorreoElectronico = (string)perfilDemandante["correoElectronico"];
                        registroDemandante.Direccion = (string)perfilDemandante["direccion"];
                        registroDemandante.Estatus = (int)perfilDemandante["estatus"];
                        registroDemandante.FechaNacimiento = (DateTime)perfilDemandante["fechaNacimiento"];
                        registroDemandante.IdPerfilusuario = (int)perfilDemandante["idPerfilUsuario"];
                        registroDemandante.NombreDemandante = (string)perfilDemandante["nombre"];
                        registroDemandante.NombreUsuario = (string)perfilDemandante["nombreUsuario"];
                        registroDemandante.Telefono = (string)perfilDemandante["telefono"];
                        registroDemandante.IdPerfilUsuarioDemandante = (int)perfilDemandante["idPerfilAspirante"];
                        MessageBox.Show(registroDemandante.IdPerfilusuario.ToString());

                        MultipartFormDataContent foto = new MultipartFormDataContent();
                        var contenidoImagen = new ByteArrayContent(usuario.Fotografia);
                        contenidoImagen.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                        foto.Add(contenidoImagen, "fotografia", "fotografiaPerfilDemandante.jpg");
                        string endpointfoto = String.Format("http://localhost:5000/v1/PerfilUsuarios/{0}/fotografia", registroDemandante.IdPerfilusuario);
                        respuesta = await cliente.PatchAsync(endpointfoto, foto);
                        switch (respuesta.StatusCode)
                        {
                            case HttpStatusCode.OK:
                                res = 1;
                                break;
                            case HttpStatusCode.NotFound:
                                break;
                            case HttpStatusCode.InternalServerError:
                                break;
                        }

                        break;
                    case HttpStatusCode.NotFound:
                        break;
                    case HttpStatusCode.InternalServerError:
                        break;
                    case HttpStatusCode.UnprocessableEntity:
                        break;

                }

            }
                return res;
        }


        public static async Task<Modelo.clases.Demandante> getDemandante(int idUsuarioDemandante, string token)
        {
            Modelo.clases.Demandante demandante = new Modelo.clases.Demandante();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = string.Format("http://localhost:5000/v1/perfilDemandantes/{0}", idUsuarioDemandante);

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            JObject perfilDemandante = JObject.Parse(body);
                            demandante.Direccion = (string)perfilDemandante["direccion"];
                            demandante.FechaNacimiento = (DateTime)perfilDemandante["fechaNacimiento"];
                            demandante.NombreDemandante = (string)perfilDemandante["nombre"];
                            demandante.Telefono = (string)perfilDemandante["telefono"];
                            demandante.IdDemandante = (int)perfilDemandante["idperfilDemandante"];

                            break;
                        case HttpStatusCode.NotFound:
                            break;
                        case HttpStatusCode.Unauthorized:
                            break;
                        case HttpStatusCode.InternalServerError:
                            break;
                    }
                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("verificar servidor");
                }

            }
            return demandante;
        }
    }
}


/* para put
 * "clave": "ut dolor dolore ut",
  "correoElectronico": "elcamello@outlook.com",
  "direccion": "Xalapeños ilustres #40",
  "estatus": 1,
  "fechaNacimiento": "{}",
  "idPerfilUsuario": 2,
  "nombre": "Josue Buendia",
  "nombreUsuario": "skylake",
  "telefono": "5557008594",
  "idperfilDemandante": 1,
  "fotografia": "$2a$08$9ODrZxVW4w2LpaSng2AiN9"*/