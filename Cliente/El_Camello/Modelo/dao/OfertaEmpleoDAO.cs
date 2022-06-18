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

            JObject? contratacionConsultada = (JObject)ofertaEmpleoConsultada["contratacion"];
            if (contratacionConsultada == null)
            {
                ContratacionEmpleo contratacionVacia = new ContratacionEmpleo();
                ofertaEmpleoGet.ContratacionEmpleo = contratacionVacia;
            }
            else { 
                //Obtenemos la contratacion de la oferta de empleo
                ofertaEmpleoGet.ContratacionEmpleo.Estatus = (int)ofertaEmpleoConsultada["contratacion"]["estatus"];
                ofertaEmpleoGet.ContratacionEmpleo.FechaContratacion = (DateTime)ofertaEmpleoConsultada["contratacion"]["fechaContratacion"];
                ofertaEmpleoGet.ContratacionEmpleo.IdContratacion = (int)ofertaEmpleoConsultada["contratacion"]["idContratacionEmpleo"];
                ofertaEmpleoGet.ContratacionEmpleo.IdOfertaEmpleo = (int)ofertaEmpleoConsultada["contratacion"]["idOfertaEmpleo"]; ofertaEmpleoGet.ContratacionEmpleo.FechaFinalizacionContratacion = (DateTime)ofertaEmpleoConsultada["contratacion"]["fechaFinalizacion"];


                //Obtenemos los contratados de la contratacion

                JArray arrayContratados = (JArray)ofertaEmpleoConsultada["contratacion"]["contratados"];
                foreach (var contratado in arrayContratados)
                {
                    ContratacionEmpleoAspirante contratacionEmpleado = new ContratacionEmpleoAspirante();
                    contratacionEmpleado.IdAspirante = (int)contratado["id_perfil_aspirante_cea"];
                    contratacionEmpleado.NombreAspiranteContratado = (string)contratado["nombre_aspirante"];

                    int? valoracionAspirante = (int)contratado["valoracion_aspirante"];
                    if (valoracionAspirante == null)
                    {
                        contratacionEmpleado.ValoracionAspirante = 0;

                    }
                    else
                    {
                        contratacionEmpleado.ValoracionAspirante = (int)contratado["valoracion_aspirante"];

                    }
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

                    Console.WriteLine(respuesta);
                    //MessageBox.Show("Respuesta: " + respuesta);

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
                        res = ofertaEmpleoCreada.IdOfertaEmpleo;


                        int resultadoCrearFotos = await PostFotografiasOfertaEmpleo(idCreado, ofertaEmpleoNueva.Fotografias);
                        if(resultadoCrearFotos == 1)
                        {
                            //MessageBox.Show("Se han creado correctamente las fotos");

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
                        string endpointfoto = string.Format("http://localhost:5000/v1/ofertasEmpleo-E/" + idOfertaEmpleo + "/fotografia");

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

        public static async Task<List<FotografiaOferta>> GetFotografiasOfertaEmpleo(int idOfertaEmpleo)
        {
            MensajesSistema errorMessage;
            List<FotografiaOferta> listaFotografias = new List<FotografiaOferta>();
            using (var cliente = new HttpClient())
            {
                string endpointfoto = string.Format("http://localhost:5000/v1/ofertasEmpleo-E/" + idOfertaEmpleo + "/fotografia");

                try
                {                    
                    HttpResponseMessage respuestaFoto = await cliente.GetAsync(endpointfoto);
                    RespuestasAPI respuestaAPI = new RespuestasAPI();

                    if (respuestaFoto.StatusCode == HttpStatusCode.OK)
                    {
                        try
                        {
                            string body = await respuestaFoto.Content.ReadAsStringAsync();

                            JArray fotografias = JsonConvert.DeserializeObject<JArray>(body);
                            //Obtener fotos
                            foreach (var foto in fotografias)
                            {

                                FotografiaOferta fotoGet = new FotografiaOferta();
                                fotoGet.IdFotografia = (int)foto["idFoto"];

                                JObject arrayFoto = (JObject)foto["imagen"];
                                byte[] segmentosFoto = new byte[arrayFoto.Count];

                                for (int i = 0; i < arrayFoto.Count; i++)
                                {
                                    segmentosFoto[i] = (byte)arrayFoto[i.ToString()];
                                }
                                
                                fotoGet.Imagen = segmentosFoto;

                                listaFotografias.Add(fotoGet);
                            }


                        }
                        catch (InvalidCastException e)
                        {
                            MessageBox.Show(e.Message);
                        }                        

                    }
                    else
                    { 
                        respuestaAPI.gestionRespuestasApi("Consultar imagenes de oferta de empleo", respuestaFoto);

                    }


                }
                catch (Exception exception)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Consultar imagenes de oferta de empleo", exception.Message);
                    errorMessage.ShowDialog();
                }
            }


            return listaFotografias;
        }

        public static async Task<int> PutFotografiasOfertaEmpleo(int idOfertaEmpleo, List<FotografiaOferta> fotografias, List<byte[]> fotosEditadas)
        {
            MensajesSistema errorMessage;
            int resultado = -1;

            using (var cliente = new HttpClient())
            {
                try
                {
                    int contador = 0;
                    foreach (var foto in fotosEditadas)
                    {
                        
                        MultipartFormDataContent fotoOfertaEmpleo = new MultipartFormDataContent();

                        var contenidoImagen = new ByteArrayContent(foto);
                        contenidoImagen.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                        fotoOfertaEmpleo.Add(contenidoImagen, "fotografia", "fotografiaOferta.jpg");
                        string endpointfoto = "http://localhost:5000/v1/ofertasEmpleo-E/" + idOfertaEmpleo + "/" + fotografias[contador].IdFotografia + "/fotografia";

                        HttpResponseMessage respuestaFoto = await cliente.PutAsync(endpointfoto, fotoOfertaEmpleo);
                        RespuestasAPI respuestaAPI = new RespuestasAPI();


                        if (respuestaFoto.StatusCode == HttpStatusCode.OK)
                        {
                            resultado = 1;
                            contador++;
                        }
                        else
                        {
                            respuestaAPI.gestionRespuestasApi("Actualizar imagenes de oferta de empleo", respuestaFoto);
                            resultado = 0;
                        }

                    }

                }
                catch (Exception exception)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Actualizar imagenes de oferta de empleo", exception.Message);
                    errorMessage.ShowDialog();
                }
            }


            return resultado;
        }

        public static async Task<int> PutOfertaEmpleo(OfertaEmpleo ofertaEmpleoEdicion, string token)
        {

            MensajesSistema errorMessage;
            int res = -1;
            OfertaEmpleo ofertaEmpleoCreada = new OfertaEmpleo();
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);

                string endpoint = string.Format("http://localhost:5000/v1/ofertasEmpleo-E/{0}", ofertaEmpleoEdicion.IdOfertaEmpleo);

                try
                {

                    HttpRequestMessage cuerpoMensaje = new HttpRequestMessage();
                    JObject objetoOfertaEmpleo = new JObject();

                    objetoOfertaEmpleo.Add("cantidadPago", ofertaEmpleoEdicion.CantidadPago);
                    objetoOfertaEmpleo.Add("descripcion", ofertaEmpleoEdicion.Descripcion);
                    objetoOfertaEmpleo.Add("diasLaborales", ofertaEmpleoEdicion.DiasLaborales);
                    objetoOfertaEmpleo.Add("direccion", ofertaEmpleoEdicion.Direccion);
                    string fechaInicio = string.Format("{0:yyyy-MM-dd}", ofertaEmpleoEdicion.FechaInicio);
                    string fechaFin = string.Format("{0:yyyy-MM-dd}", ofertaEmpleoEdicion.FechaFinalizacion);


                    objetoOfertaEmpleo.Add("fechaDeFinalizacion", fechaFin);
                    objetoOfertaEmpleo.Add("fechaDeIinicio", fechaInicio);

                    string horaInicio = string.Format("{0:H:mm}", ofertaEmpleoEdicion.HoraInicio);
                    string horaFin = string.Format("{0:H:mm}", ofertaEmpleoEdicion.HoraFin);

                    objetoOfertaEmpleo.Add("horaFin", horaFin);
                    objetoOfertaEmpleo.Add("horaInicio", horaInicio);

                    objetoOfertaEmpleo.Add("idCategoriaEmpleo", ofertaEmpleoEdicion.IdCategoriaEmpleo);
                    objetoOfertaEmpleo.Add("nombre", ofertaEmpleoEdicion.Nombre);
                    objetoOfertaEmpleo.Add("tipoPago", ofertaEmpleoEdicion.TipoPago);
                    objetoOfertaEmpleo.Add("vacantes", ofertaEmpleoEdicion.Vacantes);
                    objetoOfertaEmpleo.Add("idPerfilEmpleador", ofertaEmpleoEdicion.IdPerfilEmpleador);

                    string cuerpoJson = JsonConvert.SerializeObject(objetoOfertaEmpleo);


                    var data = new StringContent(cuerpoJson, Encoding.UTF8, "application/json");

                    HttpResponseMessage respuesta = await cliente.PutAsync(endpoint, data);


                    RespuestasAPI respuestaAPI = new RespuestasAPI();


                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        string body = await respuesta.Content.ReadAsStringAsync();

                        JObject objetoCreado = JsonConvert.DeserializeObject<JObject>(body);
                        int modificado = (int)objetoCreado["cambios"];
                        res = modificado;
                        
                        int resultadoModificarFotos = await PutFotografiasOfertaEmpleo(ofertaEmpleoEdicion.IdOfertaEmpleo, ofertaEmpleoEdicion.FotografiasEdicion, ofertaEmpleoEdicion.Fotografias);
                        if (resultadoModificarFotos == 1)
                        {
                            MessageBox.Show("Se han actualizado correctamente las fotos");

                        }
                        else if (resultadoModificarFotos == 0)
                        {
                            MessageBox.Show("Ocurrio un error al actualizar alguna imagen");
                        }
                        else
                        {
                            MessageBox.Show("No se creo ninguna imagen");
                        }
                        
                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Modificar oferta de empleo", respuesta);
                    }

                }
                catch (HttpRequestException excepcionCapturada)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Modificar oferta de empleo", excepcionCapturada.Message);
                    errorMessage.ShowDialog();
                }


            }

            return res;

        }

    }
}
