using El_Camello.Assets.utilerias;
using El_Camello.Configuracion;
using El_Camello.Modelo.clases;
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
    internal class CategoriaDAO
    {
        public static async Task<List<Categoria>> GetCategorias() // listo en cliente
        {
            List<Categoria> categorias = new List<Categoria>();
            using (var cliente = new HttpClient())
            {
                string endpoint = $"{Settings.ElCamelloURL}/v1/categoriasEmpleo";

                try
                {
                    
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        JArray listaCategorias = JArray.Parse(body);
                        foreach (var item in listaCategorias)
                        {
                            Categoria categoria = new Categoria();
                            categoria.IdCategoria = (int)item["idCategoriaEmpleo"];
                            categoria.NombreCategoria = (string)item["nombre"];
                            categorias.Add(categoria);
                        }
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Get Categoria", respuesta);
                    }

                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }


            }

            return categorias;
        }

        public static async Task<int> PostCategoria(string nombre, string token) // listo cliente
        {
            int resultado = -1;
            int idCategoria = -1;
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = $"{Settings.ElCamelloURL}/v1/categoriasEmpleo";

                try
                {
                    HttpRequestMessage cuerpoMensaje = new HttpRequestMessage();
                    RespuestasAPI respuestaAPI = new RespuestasAPI();
                    string cuerpoJson = "{\"nombre\": \"" + nombre + "\"}";

                    var data = new StringContent(cuerpoJson, Encoding.UTF8, "application/json");


                    HttpResponseMessage respuesta = await cliente.PostAsync(endpoint, data);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    if (respuesta.StatusCode == HttpStatusCode.Created)
                    {
                        JObject registroCategoria = JObject.Parse(body);
                        idCategoria = (int)registroCategoria["idCategoriaEmpleo"];
                        resultado = 1;

                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Post Categorias", respuesta);
                    }
                    
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }


            }
            return resultado;
        }

        public static async Task<int> DeleteCategoria(int idCategoria, string token)// listo cliente
        {
            int resultado = -1;
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = String.Format("{0}/v1/categoriasEmpleo/{1}", Settings.ElCamelloURL, idCategoria);
                try
                {
                    HttpResponseMessage respuesta = await cliente.DeleteAsync(endpoint);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if (respuesta.StatusCode == HttpStatusCode.NoContent)
                    {
                        resultado = 1;
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Delete Categorias", respuesta);
                    }

                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }


            }
            return resultado;

        }

        public static async Task<int> PatchCategoria(Categoria categoria, string token) // listo cliente
        {
            int resultado = -1;
            int idCategoria = -1;
            using (var cliente = new HttpClient())
            {
                
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = String.Format("{0}/v1/categoriasEmpleo/{1}", Settings.ElCamelloURL, categoria.IdCategoria);

                try
                {
                    HttpRequestMessage cuerpoMensaje = new HttpRequestMessage();
                    string cuerpoJson = "{\"nombre\": \"" + categoria.NombreCategoria + "\"}";
                    RespuestasAPI respuestaAPI = new RespuestasAPI();
                    var data = new StringContent(cuerpoJson, Encoding.UTF8, "application/json");


                    HttpResponseMessage respuesta = await cliente.PatchAsync(endpoint, data);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    
                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        JObject registroCategoria = JObject.Parse(body);
                        idCategoria = (int)registroCategoria["idCategoriaEmpleo"];
                        resultado = 1;
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Put Categorias", respuesta);
                    }

                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }


            }

            return resultado;

        }
    }
}
