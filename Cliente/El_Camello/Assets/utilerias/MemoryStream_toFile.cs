using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
