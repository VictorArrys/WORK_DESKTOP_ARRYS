using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace El_Camello.Assets.utilerias
{
    public class RespuestasAPI
    {
       
        public async Task gestionRespuestasApi(string ubicacion,HttpResponseMessage respuesta)
        {
            MensajesSistema errorMessage;

            JObject respuestaObjectBody = new JObject();
            string respuestaBody = await respuesta.Content.ReadAsStringAsync();
            respuestaObjectBody = JObject.Parse(respuestaBody);

            switch (respuesta.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    respuestaObjectBody = JObject.Parse(respuestaBody);
                    string tokenInvalido = (string)respuestaObjectBody["type error"]["message"];

                    //Invocar clase para mensajes
                    errorMessage = new MensajesSistema("Error", "Credenciales incorrectas", ubicacion, tokenInvalido);
                    errorMessage.ShowDialog();

                    break;
                case HttpStatusCode.InternalServerError:
                    respuestaObjectBody = JObject.Parse(respuestaBody);
                    string errorInterno = (string)respuestaObjectBody["type error"]["message"];
                    //Invocar clase para mensajes
                    errorMessage = new MensajesSistema("Error", "Se ha generado un problema interno, de favor intente más tarde esta acción", ubicacion, errorInterno);
                    errorMessage.ShowDialog();

                    break;
                case HttpStatusCode.NotFound:
                    respuestaObjectBody = JObject.Parse(respuestaBody);
                    string noEncontrado = (string)respuestaObjectBody["type error"]["message"];
                    //Invocar clase para mensajes
                    errorMessage = new MensajesSistema("Error", "No se pudo encontrar el recurso", ubicacion, noEncontrado);
                    errorMessage.ShowDialog();
                    

                    break;
            }



        }

    }
}
