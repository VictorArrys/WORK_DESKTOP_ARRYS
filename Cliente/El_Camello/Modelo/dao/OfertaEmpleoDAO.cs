using System;
using El_Camello.Modelo.clases;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using El_Camello.Assets.utilerias;

namespace El_Camello.Modelo.dao
{
    internal class OfertaEmpleoDAO
    {

        public static async Task<OfertaEmpleo> GetOfertaEmpleo(int idOfertaEmpleo)
        {

            MensajesSistema errorMessage;
            OfertaEmpleo ofertaEmpleoGet = new OfertaEmpleo();
            using (var cliente = new HttpClient())
            {
                string endpoint = string.Format("http://localhost:5000/v1/ofertasEmpleo-E/{0}", idOfertaEmpleo);
                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);

                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        string body = await respuesta.Content.ReadAsStringAsync();

                        JObject ofertaEmpleoConsultada = JsonConvert.DeserializeObject<JObject>(body);

                        //Obtener fotos
                        /*
                        JArray arrayFotos = JArray.Parse(body);
                        foreach (var foto in arrayFotos)
                        { 

                        }
                        */

                        ofertaEmpleoGet.CantidadPago = (int)ofertaEmpleoConsultada["cantidadPago"];
                        ofertaEmpleoGet.Descripcion = (string)ofertaEmpleoConsultada["descripcion"];
                        ofertaEmpleoGet.DiasLaborales = (string)ofertaEmpleoConsultada["diasLaborales"];
                        ofertaEmpleoGet.Direccion = (string)ofertaEmpleoConsultada["direccion"];

                        ofertaEmpleoGet.FechaFinalizacion = (DateTime)ofertaEmpleoConsultada["fechaDeFinalizacion"];
                        ofertaEmpleoGet.FechaInicio = (DateTime)ofertaEmpleoConsultada["fechaDeIinicio"];

                        string horaFin = (string)ofertaEmpleoConsultada["horaFin"];
                        string horaInicio = (string)ofertaEmpleoConsultada["horaInicio"];

                        ofertaEmpleoGet.HoraInicio = TimeOnly.Parse(horaInicio);
                        ofertaEmpleoGet.HoraFin = TimeOnly.Parse(horaFin);

                        ofertaEmpleoGet.IdCategoriaEmpleo = (int)ofertaEmpleoConsultada["idCategoriaEmpleo"];
                        ofertaEmpleoGet.CategoriaEmpleo = (string)ofertaEmpleoConsultada["categoriaEmpleo"];
                      
                        ofertaEmpleoGet.Nombre = (string)ofertaEmpleoConsultada["nombre"];
                        ofertaEmpleoGet.TipoPago = (string)ofertaEmpleoConsultada["tipoPago"];
                        ofertaEmpleoGet.Vacantes = (int)ofertaEmpleoConsultada["vacantes"];
                        ofertaEmpleoGet.IdOfertaEmpleo = (int)ofertaEmpleoConsultada["idOfertaEmpleo"];
                        ofertaEmpleoGet.IdPerfilEmpleador = (int)ofertaEmpleoConsultada["idPerfilEmpleador"];

                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Obtener oferta de empleo", respuesta);
                    }

                }
                catch (HttpRequestException exception)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Obtener oferta de empleo", exception.Message);
                    errorMessage.ShowDialog();
                }

            }

            return ofertaEmpleoGet;
        }

        public static async Task<List<OfertaEmpleo>> GetOfertasEmpleos(int idEmpleador)
        {

            MensajesSistema errorMessage;
            List<OfertaEmpleo> ofertasEmpleosGet = new List<OfertaEmpleo>();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZFVzdWFyaW8iOjUsImNsYXZlIjoidXNhZ2l0c3VraW5vIiwidGlwbyI6IkVtcGxlYWRvciIsImlhdCI6MTY1NTA0NzE4NCwiZXhwIjoxNjU1MTMzNTg0fQ.E3QTiHnyr4MB3mXazcmGzaMe4sQNGLZdekP_EisMOIk");
                string endpoint = "http://localhost:5000/v1/ofertasEmpleo-E?idPerfilEmpleador=" + idEmpleador;

                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);

                    RespuestasAPI respuestaAPI = new RespuestasAPI();


                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        string body = await respuesta.Content.ReadAsStringAsync();
                        

                        JArray arrayOfertasEmpleo = JArray.Parse(body);
                        foreach (var ofertaEmpleoConsultada in arrayOfertasEmpleo)
                        {

                            OfertaEmpleo ofertaEmpleoGet = new OfertaEmpleo();
                            ofertaEmpleoGet.IdOfertaEmpleo = (int)ofertaEmpleoConsultada["id_oferta_empleo"];
                            ofertaEmpleoGet.IdPerfilEmpleador = (int)ofertaEmpleoConsultada["id_perfil_oe_empleador"];
                            ofertaEmpleoGet.IdCategoriaEmpleo = (int)ofertaEmpleoConsultada["id_categoria_oe"];
                            ofertaEmpleoGet.Nombre = (string)ofertaEmpleoConsultada["nombre"];
                            ofertaEmpleoGet.Descripcion = (string)ofertaEmpleoConsultada["descripcion"];
                            ofertaEmpleoGet.Vacantes = (int)ofertaEmpleoConsultada["vacantes"];
                            ofertaEmpleoGet.DiasLaborales = (string)ofertaEmpleoConsultada["dias_laborales"];
                            ofertaEmpleoGet.TipoPago = (string)ofertaEmpleoConsultada["tipo_pago"];
                            ofertaEmpleoGet.CantidadPago = (int)ofertaEmpleoConsultada["cantidad_pago"];                           
                            ofertaEmpleoGet.Direccion = (string)ofertaEmpleoConsultada["direccion"];
                            string horaInicio = (string)ofertaEmpleoConsultada["hora_inicio"];
                            string horaFin = (string)ofertaEmpleoConsultada["hora_fin"];

                            ofertaEmpleoGet.HoraInicio = TimeOnly.Parse(horaInicio);
                            ofertaEmpleoGet.HoraFin = TimeOnly.Parse(horaFin);

                            ofertaEmpleoGet.FechaInicio = (DateTime)ofertaEmpleoConsultada["fecha_inicio"];
                            ofertaEmpleoGet.FechaFinalizacion = (DateTime)ofertaEmpleoConsultada["fecha_finalizacion"];

                            ofertaEmpleoGet.CategoriaEmpleo = (string)ofertaEmpleoConsultada["categoria"];
                            ofertaEmpleoGet.FechaInicio = DateTime.Now;
                           
                            ofertasEmpleosGet.Add(ofertaEmpleoGet);
                        }

                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Obtener ofertas de empleo", respuesta);
                    }

                }
                catch (HttpRequestException exception)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Obtener ofertas de empleo", exception.Message);
                    errorMessage.ShowDialog();
                }


            }
           
            return ofertasEmpleosGet;
        }


        public static async Task<int> PostOfertaEmpleo(OfertaEmpleo ofertaEmpleoNueva, string token)
        {

            MensajesSistema errorMessage;
            int res = -1;
            OfertaEmpleo ofertaEmpleoCreada = new OfertaEmpleo();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);

                string endpoint = "http://localhost:5000/v1/ofertasEmpleo-E";

                try
                {
    
                    HttpRequestMessage cuerpoMensaje = new HttpRequestMessage();
                    JObject objetoOfertaEmpleo = new JObject();

                    objetoOfertaEmpleo.Add("cantidadPago", ofertaEmpleoNueva.CantidadPago);
                    objetoOfertaEmpleo.Add("descripcion", ofertaEmpleoNueva.Descripcion);
                    objetoOfertaEmpleo.Add("diasLaborales", ofertaEmpleoNueva.DiasLaborales);
                    objetoOfertaEmpleo.Add("direccion", ofertaEmpleoNueva.Direccion);
                    string fechaInicio = string.Format("{0:yyyy-MM-dd}", ofertaEmpleoNueva.FechaInicio);
                    string fechaFin = string.Format("{0:yyyy-MM-dd}", ofertaEmpleoNueva.FechaFinalizacion);


                    objetoOfertaEmpleo.Add("fechaDeFinalizacion", fechaFin);
                    objetoOfertaEmpleo.Add("fechaDeIinicio", fechaInicio);

                    string horaInicio = string.Format("{0:H:mm}", ofertaEmpleoNueva.HoraInicio);
                    string horaFin = string.Format("{0:H:mm}", ofertaEmpleoNueva.HoraFin);

                    objetoOfertaEmpleo.Add("horaFin", horaFin);
                    objetoOfertaEmpleo.Add("horaInicio", horaInicio);

                    objetoOfertaEmpleo.Add("idCategoriaEmpleo", ofertaEmpleoNueva.IdCategoriaEmpleo);
                    objetoOfertaEmpleo.Add("nombre", ofertaEmpleoNueva.Nombre);
                    objetoOfertaEmpleo.Add("tipoPago", ofertaEmpleoNueva.TipoPago);
                    objetoOfertaEmpleo.Add("vacantes", ofertaEmpleoNueva.Vacantes);
                    objetoOfertaEmpleo.Add("idPerfilEmpleador", ofertaEmpleoNueva.IdPerfilEmpleador);

                    string cuerpoJson = JsonConvert.SerializeObject(objetoOfertaEmpleo);

                    var data = new StringContent(cuerpoJson, Encoding.UTF8, "application/json");

                    HttpResponseMessage respuesta = await cliente.PostAsync(endpoint, data);
                    

                    RespuestasAPI respuestaAPI = new RespuestasAPI();


                    if (respuesta.StatusCode == HttpStatusCode.Created)
                    {
                        string body = await respuesta.Content.ReadAsStringAsync();    

                        JObject objetoCreado = JObject.Parse(body);
                        MessageBox.Show(body);
                        ofertaEmpleoCreada.IdOfertaEmpleo = (int)objetoCreado["idOfertaEmpleo"];
                        res = ofertaEmpleoCreada.IdOfertaEmpleo;


                        int resultadoCrearFotos = await PostFotografiasOfertaEmpleo(ofertaEmpleoCreada.IdOfertaEmpleo, ofertaEmpleoNueva.Fotografias);
                        if(resultadoCrearFotos == 1)
                        {
                            MessageBox.Show("Se han creado correctamente las fotos");

                        }else if (resultadoCrearFotos == 0)
                        {
                            MessageBox.Show("Ocurrio un error al guardar alguna imagen");
                        }
                        else
                        {
                            MessageBox.Show("No se creo ninguna imagen");
                        }

                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Registrar oferta de empleo", respuesta);
                    }                   

                }
                catch (HttpRequestException excepcionCapturada)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Registrar oferta de empleo", excepcionCapturada.Message);
                    errorMessage.ShowDialog();
                }


            }

            return res;

        }

        public static async Task<int> PostFotografiasOfertaEmpleo(int idOfertaEmpleo, List<byte[]> fotografias)
        {
            MensajesSistema errorMessage;
            int resultado = -1;

            using (var cliente = new HttpClient())
            {
                try
                {
                    foreach (var foto in fotografias)
                    {
                        MultipartFormDataContent fotoOfertaEmpleo = new MultipartFormDataContent();

                        var contenidoImagen = new ByteArrayContent(foto);
                        contenidoImagen.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                        fotoOfertaEmpleo.Add(contenidoImagen, "fotografia", "fotografiaPerfil.jpg");

                        string endpointfoto = String.Format("http://localhost:5000/v1/ofertasEmpleo-E/{0}/{1}", idOfertaEmpleo, foto);

                        HttpResponseMessage respuestaFoto = await cliente.PostAsync(endpointfoto, fotoOfertaEmpleo);
                        RespuestasAPI respuestaAPI = new RespuestasAPI();


                        if (respuestaFoto.StatusCode == HttpStatusCode.Created)
                        {
                            resultado = 1;
                        }
                        else
                        {                            
                            respuestaAPI.gestionRespuestasApi("Registrar imagenes de oferta de empleo", respuestaFoto);
                            resultado = 0;
                        }

                        }

                }
                catch (Exception exception)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Registrar imagenes de oferta de empleo", exception.Message);
                    errorMessage.ShowDialog();
                }
            }


            return resultado;
        }






        }
}
