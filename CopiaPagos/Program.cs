using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopiaPagos
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {


                string Ruta_Origen = @"C:\Coopeuch\Pagos\";
                string Ruta_Destino = @"\\192.168.0.227\COO_Coopeuch\02.Pagos\";     
                string Ruta_Destino_historial = @"C:\coopeuch\pagos\his\";

                //string strCmdText;
                //strCmdText = @"net use \\192.168.0.227\CMR_Falabella /user:gna_user Tecno.202x";
                //System.Diagnostics.Process.Start("CMD.exe", strCmdText);


                //Valido que el directorio este disponible
                while (!Directory.Exists(Ruta_Destino))
                {
                    Console.WriteLine("valida directorio");
                }
                Console.WriteLine("paso el valida directorio");
                List<string> strFiles = Directory.GetFiles(Ruta_Origen, "*", SearchOption.AllDirectories).ToList();

                foreach (string fichero in strFiles)
                {

                    if (Path.GetFileName(fichero).Contains("Recupero_castigo_GARCIA NADAL")) {



                        if (!File.Exists((Ruta_Destino_historial + Path.GetFileName(fichero))))
                        {

                            //Copio Historico
                            File.Copy((fichero), Ruta_Destino_historial + Path.GetFileName(fichero));

                            //Copio Tecnocob
                            File.Copy(fichero, (Ruta_Destino + Path.GetFileName(fichero)));

                            //Elimino El archivo original
                            File.Delete(fichero);

                        }



                    }

                    if (Path.GetFileName(fichero).Contains("Recupero_castigo_judicial"))
                    {
                        if (!File.Exists((Ruta_Destino_historial + Path.GetFileName(fichero))))
                        {

                            //Copio Historico
                           File.Copy((fichero), Ruta_Destino_historial + "\\" + Path.GetFileName(fichero));

                            //Elimino El archivo original
                            File.Delete(fichero);
                        }
                    }

                }


            }
            catch (Exception EX)
            {

                Console.WriteLine(EX.Message.ToString());
          

            }



        }

    }
}

