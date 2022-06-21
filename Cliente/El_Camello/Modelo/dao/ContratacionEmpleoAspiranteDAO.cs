using El_Camello.Assets.utilerias;
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

namespace El_Camello.Modelo.dao
{
    public class ContratacionEmpleoAspiranteDAO
    {
        public static async Task<int> PatchEvaluarAspirante(ContratacionEmpleoAspirante evaluacionAspirante , int idOfertaEmpleo, string token)
        {

            MensajesSistema errorMessage;
            int res = -1;
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("x-access-token", token);

                string endpoint = string.Format("http://localhost:5000/v1/contratacionesEmpleo/{0}?idAspirante={1}", idOfertaEmpleo,evaluacionAspirante.IdAspirante);

                try
                {

                    HttpRequestMessage cuerpoMensaje = new HttpRequestMessage();
                    JObject valoracionCuerpo = new JObject();

                    valoracionCuerpo.Add("idAspirante", evaluacionAspirante.IdAspirante);
                    valoracionCuerpo.Add("valoracionAspirante", evaluacionAspirante.ValoracionAspirante);
                    valoracionCuerpo.Add("diasLaborales", evaluacionAspirante.NombreAspiranteContratado);

                    string cuerpoJson = JsonConvert.SerializeObject(valoracionCuerpo);


                    var data = new StringContent(cuerpoJson, Encoding.UTF8, "application/json");

                    HttpResponseMessage respuesta = await cliente.PutAsync(endpoint, data);


                    RespuestasAPI respuestaAPI = new RespuestasAPI();


                    if (respuesta.StatusCode == HttpStatusCode.OK)
                    {
                        string body = await respuesta.Content.ReadAsStringAsync();

                        JObject objetoCreado = JsonConvert.DeserializeObject<JObject>(body);
                        int evaluado = (int)objetoCreado["valoracionAspirante"];
                        res = evaluado;

                    }
                    else
                    {
                        respuestaAPI.gestionRespuestasApi("Evaluar aspirante", respuesta);
                    }

                }
                catch (HttpRequestException excepcionCapturada)
                {
                    errorMessage = new MensajesSistema("Error", "Servidor desconectado, no se puede establecer conexion", "Evaluar aspirante", excepcionCapturada.Message);
                    errorMessage.ShowDialog();
                }


            }

            return res;

        }


    }
}
