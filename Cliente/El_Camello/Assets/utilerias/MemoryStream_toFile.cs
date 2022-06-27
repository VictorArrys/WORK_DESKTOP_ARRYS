using System.IO;

namespace El_Camello.Assets.utilerias
{
    public class MemoryStream_toFile
    {
        public static void MemoryStreamToFile(MemoryStream stream, string rutaArchivo)
        {
            FileStream fs = File.OpenWrite(rutaArchivo);
            stream.WriteTo(fs);
            fs.Flush();
            fs.Close();
        }
    }
}
