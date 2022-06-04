using El_Camello.Modelo.clases;
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
    internal class AspiranteDAO
    {

        public static async Task<int> PostAspirante(Usuario usuario, clases.Aspirante aspirante)
        {
            int res =  -1;
            using (var cliente = new HttpClient())
            {
                Dictionary<string, string> parametros = new Dictionary<string, string>();

                //terminar diccionario
                parametros.Add("clave", usuario.Clave);
                //parametros

                
               
                //cambiar la direccion de aspirante
                string endpoint = "http://localhost:5000/v1/categoriasEmpleo";
                
                try
                {
                    

                    /*var data = new StringContent((string)cuerpoJson, Encoding.UTF8, "application/json");


                    HttpResponseMessage respuesta = await cliente.PostAsync(endpoint, data);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.Created:

                            JObject id = JObject.Parse(body);
                            res = (int)id["id_Categoria_empleo"];
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
