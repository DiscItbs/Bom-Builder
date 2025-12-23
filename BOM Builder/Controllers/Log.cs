using System.IO;
using System.Web.Hosting;
using System.Windows.Forms;

namespace BOM_Builder.Controllers
{
    class Log
    {
        SQLServer sql = new SQLServer();
        
        Syst sistema = new Syst();
        
        /// <summary>
        /// Crea el archivo de logs por dia en la carpeta \Logs
        /// </summary>
        /// <returns></returns>
        public bool CreateLog()
        {
            string pathLog = "";
            //string pathLog = sql.GetPathLogs();
            string name_file = "\\Log_NAMM_" + sistema.GetDateForLog() + ".txt";
            string path = pathLog + name_file; 

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(sistema.GetDateTime() + "\n");
                }
            }

            return false;
        }

        public bool CreateDirectory()
        {
            string directoryName = "\\Logs_NAMM";
            string pathDirectory = sql.GetNameDirectoryLogs() + directoryName;

            if(!Directory.Exists(pathDirectory))
            {
                Directory.CreateDirectory(pathDirectory);
                return true;
            }

            return false;
        }

        public void WriteInLog(string text)
        {
            string pathLog = sql.GetPathLogs();
            string name_file = "\\Log_NAMM_" + sistema.GetDateForLog() + ".txt";
            string path = pathLog + name_file;

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(sistema.GetDateTime() + "\n");
                }
            }
            else
            {
                using (StreamWriter writer = File.AppendText(path))
                {
                    writer.WriteLine(text + "\t\t" +  sistema.GetDateTime());
                }
            }
        }

    }
}
