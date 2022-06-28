using System;
using System.IO;
using System.Windows;

namespace El_Camello.Assets.utilerias
{
    public class MemoryStream_toFile
    {
        public static void MemoryStreamToFile(MemoryStream stream, string rutaArchivo)
        {
            try
            {
                FileStream fs = File.OpenWrite(rutaArchivo);
                stream.WriteTo(fs);
                fs.Flush();
                fs.Close();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Ocurrio un error al consultar el video, favor de intentar de nuevo","¡Operación!");
            }
        }
    }
}
