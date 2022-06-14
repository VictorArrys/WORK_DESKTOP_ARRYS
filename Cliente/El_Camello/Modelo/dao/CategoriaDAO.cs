using El_Camello.Modelo.clases;
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
    internal class CategoriaDAO
    {
        public static async Task<List<Categoria>> GetCategorias(string token)
        {
            List<Categoria> categorias = new List<Categoria>();
            using (var cliente = new HttpClient())
            {
                //string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZFVzdWFyaW8iOjEsImNsYXZlIjoiMTExMDk4IiwidGlwbyI6IkFkbWluaXN0cmFkb3IiLCJpYXQiOjE2NTQzNTQ3NDAsImV4cCI6MTY1NDQ0MTE0MH0.1Nm4C3vVs-jH3_zpcYBmJTqH9DQA_LH6b3VPRJSucaw";
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = "http://localhost:5000/v1/categoriasEmpleo";
                //HttpResponseMessage respuesta = await client.GetAsync(query);
                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            JArray arrayCategorias = JArray.Parse(body);
                            foreach (var item in arrayCategorias)
                            {
                                Categoria categoria = new Categoria();
                                categoria.IdCategoria = (int)item["id_categoria_empleo"];
                                categoria.NombreCategoria = (string)item["nombre"];
                                categorias.Add(categoria);
                            }
                            break;
                        case HttpStatusCode.Unauthorized:
                        case HttpStatusCode.InternalServerError:
                        case HttpStatusCode.NotFound:
                            JObject codigo = JObject.Parse(body);
                            string mensaje = (string)codigo["type error"]["menssage"];
                            MessageBox.Show(mensaje);
                            break;
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }


            }

            return categorias;
        }

        public static async Task<int> PostCategoria(string nombre, string token)
        {
            int res = -1;
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = "http://localhost:5000/v1/categoriasEmpleo";
                //HttpResponseMessage respuesta = await client.GetAsync(query);
                try
                {
                    HttpRequestMessage cuerpoMensaje = new HttpRequestMessage();
                    string cuerpoJson = "{\"nombre\": \"" + nombre + "\"}";

                    var data = new StringContent(cuerpoJson, Encoding.UTF8, "application/json");


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
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }


            }
            return res;
        }

        public static async Task<bool> DeleteCategoria(int idCategoria, string token)
        {
            bool res = false;
            using (var cliente = new HttpClient())
            {
                //string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZFVzdWFyaW8iOjEsImNsYXZlIjoiMTExMDk4IiwidGlwbyI6IkFkbWluaXN0cmFkb3IiLCJpYXQiOjE2NTQzNTQ3NDAsImV4cCI6MTY1NDQ0MTE0MH0.1Nm4C3vVs-jH3_zpcYBmJTqH9DQA_LH6b3VPRJSucaw";
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = String.Format("http://localhost:5000/v1/categoriasEmpleo/{0}", idCategoria);
                //HttpResponseMessage respuesta = await client.GetAsync(query);
                try
                {


                    HttpResponseMessage respuesta = await cliente.DeleteAsync(endpoint);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.NoContent:
                            res = true;
                            break;
                        case HttpStatusCode.Unauthorized:
                        case HttpStatusCode.InternalServerError:
                        case HttpStatusCode.NotFound:
                            JObject codigo = JObject.Parse(body);
                            string mensaje = (string)codigo["type error"]["message"];
                            MessageBox.Show(mensaje);
                            break;
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("servidor desconectado, no se puede establecer conexion");
                }


            }
            return res;

        }

        public static async Task<bool> PatchCategoria(Categoria categoria, string token)
        {
            bool res = false;
            using (var cliente = new HttpClient())
            {
                
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
                string endpoint = String.Format("http://localhost:5000/v1/categoriasEmpleo/{0}", categoria.IdCategoria);
                //HttpResponseMessage respuesta = await client.GetAsync(query);
                try
                {
                    HttpRequestMessage cuerpoMensaje = new HttpRequestMessage();
                    string cuerpoJson = "{\"nombre\": \"" + categoria.NombreCategoria + "\"}";

                    var data = new StringContent(cuerpoJson, Encoding.UTF8, "application/json");


                    HttpResponseMessage respuesta = await cliente.PatchAsync(endpoint, data);
                    string body = await respuesta.Content.ReadAsStringAsync();
                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            JObject registroCategoria = JObject.Parse(body);

                            if (categoria.NombreCategoria == (string)registroCategoria["nombre"])
                            {
                                res = true;
                            }
                            break;
                        case HttpStatusCode.Unauthorized:
                        case HttpStatusCode.InternalServerError:
                        case HttpStatusCode.NotFound:
                            JObject codigo = JObject.Parse(body);
                            string mensaje = (string)codigo["resBody"]["menssage"];
                            MessageBox.Show(mensaje);
                            break;
                    }
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
