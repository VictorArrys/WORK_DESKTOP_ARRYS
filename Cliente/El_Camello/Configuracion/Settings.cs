using System.Diagnostics;
using System.IO;

namespace El_Camello.Configuracion
{
    public class Settings
    {
        private static string INIPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + Path.DirectorySeparatorChar + "ElCamello.ini";

        private static string elCamelloURL;

        private static INI archivoINI = new INI(INIPath);

        public static string ElCamelloURL { get => elCamelloURL; private set => elCamelloURL = value; }

        public static void CargarConfiguracion()
        {
            bool existeINI = File.Exists(INIPath);
            if (!existeINI)
            {
                CrearDefaultINI();
            }
            else
            {
                LeerINI();
            }
        }

        private static void LeerINI()
        {
            string url = archivoINI.LeerINI("Settings", "URL");
            if (url.Length == 0)
            {
                SetDefaultURL();
                url = archivoINI.LeerINI("Settings", "URL");
            }
            ElCamelloURL = url;
        }

        private static void CrearDefaultINI()
        {
            SetDefaultURL();
        }

        private static void SetDefaultURL()
        {
            archivoINI.EscribirINI("Settings", "URL", "http://localhost:3000/worksystem_develop");
        }
    }
}