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
        public static async Task<OfertaEmpleo> GetOfertaEmpleo(int idOfertaEmpleo, string token)
        {

            OfertaEmpleo ofertaEmpleoGet = new OfertaEmpleo();

            JObject ofertaEmpleoConsultada = await GetOfertaEmpleoCompuesta(idOfertaEmpleo, token);

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


            return ofertaEmpleoGet;
        }

        public static async Task<OfertaEmpleo> GetOfertaEmpleoCompleta(int idOfertaEmpleo, string token)
        {
            MensajesSistema errorMessage;
            OfertaEmpleo ofertaEmpleoGet = new OfertaEmpleo();

            JObject ofertaEmpleoConsultada = await GetOfertaEmpleoCompuesta(idOfertaEmpleo, token);

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


            if ((string)ofertaEmpleoConsultada["contratacion"] == "empty")
            {
                ContratacionEmpleo contratacionVacia = new ContratacionEmpleo();
                ofertaEmpleoGet.ContratacionEmpleo = contratacionVacia;

                errorMessage = new MensajesSistema("AccionInvalida", "No existe aun una contratación para la oferta de empleo", "Obtener oferta de empleo completa", "Para tener una contratación debe aceptar una solcitud de empleo");
                errorMessage.ShowDialog();
            }
            else {

                JObject contratacionConsultada = JObject.Parse((string)ofertaEmpleoConsultada["contratacion"]);

                //Obtenemos la contratacion de la oferta de empleo
                ofertaEmpleoGet.ContratacionEmpleo.Estatus =(int)contratacionConsultada["estatus"];
                ofertaEmpleoGet.ContratacionEmpleo.FechaContratacion = (DateTime)contratacionConsultada["fechaContratacion"];
                ofertaEmpleoGet.ContratacionEmpleo.IdContratacion = (int)contratacionConsultada["idContratacionEmpleo"];
                ofertaEmpleoGet.ContratacionEmpleo.IdOfertaEmpleo = (int)contratacionConsultada["idOfertaEmpleo"];
                ofertaEmpleoGet.ContratacionEmpleo.FechaFinalizacionContratacion = (DateTime)contratacionConsultada["fechaFinalizacion"];

                //Obtenemos los contratados de la contratacion

                JArray arrayContratados = JArray.Parse((string)contratacionConsultada["contratados"]);
                foreach (var contratado in arrayContratados)
                {
                    ContratacionEmpleoAspirante contratacionEmpleado = new ContratacionEmpleoAspirante();
                    contratacionEmpleado.IdAspirante = (int)contratado["id_aspirante_cea"];
                    contratacionEmpleado.NombreAspiranteContratado = (string)contratado["nombre_aspirante"];
                    contratacionEmpleado.ValoracionAspirante = (int)contratado["valoracion_aspirante"];

                    //Agregamos la contratacion a la lista de contrataciones
                    ofertaEmpleoGet.ContratacionEmpleo.ContratacionesAspirantes.Add(contratacionEmpleado);
                }


            }

            return ofertaEmpleoGet;
        }


        public static async Task<JObject> GetOfertaEmpleoCompuesta(int idOfertaEmpleo, string token)
        {

            MensajesSistema errorMessage;

            JObject ofertaEmpleoConsultada = new JObject();

            using (var cliente = new HttpClient())
            {

                cliente.DefaultRequestHeaders.Add("x-access-token", token);

                string endpoint = string.Format("http://localhost:5000/v1/ofertasEmpleo-E/" + idOfertaEmpleo);
                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);

                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        string body = await respuesta.Content.ReadAsStringAsync();

                        ofertaEmpleoConsultada = JsonConvert.DeserializeObject<JObject>(body);

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

            return ofertaEmpleoConsultada;
        }

        public static async Task<List<OfertaEmpleo>> GetOfertasEmpleos(int idEmpleador, string token)
        {

            MensajesSistema errorMessage;
            List<OfertaEmpleo> ofertasEmpleosGet = new List<OfertaEmpleo>();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);
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

                        JObject objetoCreado = JsonConvert.DeserializeObject<JObject>(body);
                        int idCreado = (int)objetoCreado["idOfertaEmpleo"];

                        ofertaEmpleoCreada.IdOfertaEmpleo = idCreado;
                        MessageBox.Show("resultado ->" + objetoCreado + " | -> " + idCreado );
                        res = ofertaEmpleoCreada.IdOfertaEmpleo;


                        int resultadoCrearFotos = await PostFotografiasOfertaEmpleo(idCreado, ofertaEmpleoNueva.Fotografias);
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
                        fotoOfertaEmpleo.Add(contenidoImagen, "fotografia", "fotografiaOferta.jpg");

                        string endpointfoto = String.Format("http://localhost:5000/v1/ofertasEmpleo-E/" + idOfertaEmpleo + "/fotografia");

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
