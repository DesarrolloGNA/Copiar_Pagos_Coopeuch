using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopiaPagos
{
    class Program
    {
        static void Main(string[] args)
        {

            string Ruta_Origen = @"C:\Coopeuch\Pagos\";
            string Ruta_Destino = @"\\192.168.0.227\COO_Coopeuch\02.Pagos\";     
            string Ruta_Destino_historial = @"C:\coopeuch\pagos\his\";

            //Valido que el directorio este disponible
            while (!System.IO.Directory.Exists(Ruta_Destino)) { }

            List<string> strFiles = System.IO.Directory.GetFiles(Ruta_Origen, "*", System.IO.SearchOption.AllDirectories).ToList();

            foreach (string fichero in strFiles)
            {

                if (System.IO.Path.GetFileName(fichero).Contains("Recupero_castigo_GARCIA NADAL")) {



                    if (!System.IO.File.Exists((Ruta_Destino_historial + System.IO.Path.GetFileName(fichero))))
                    {

                        //Copio Historico
                        System.IO.File.Copy((fichero), Ruta_Destino_historial + System.IO.Path.GetFileName(fichero));

                        //Copio Tecnocob
                        System.IO.File.Copy(fichero, (Ruta_Destino + System.IO.Path.GetFileName(fichero)));

                        //Elimino El archivo original
                        System.IO.File.Delete(fichero);

                    }



                }

                if (System.IO.Path.GetFileName(fichero).Contains("Recupero_castigo_judicial"))
                {
                    if (!System.IO.File.Exists((Ruta_Destino_historial + System.IO.Path.GetFileName(fichero))))
                    {

                        //Copio Historico
                        System.IO.File.Copy((fichero), Ruta_Destino_historial + "\\" + System.IO.Path.GetFileName(fichero));

                        //Elimino El archivo original
                        System.IO.File.Delete(fichero);
                    }
                }

            }


            //if (System.IO.File.Exists((Ruta_Origen + Nombre_Archivo)))
            //{
            //    //Copio Tecnocob
            //    if (!System.IO.File.Exists((Ruta_Destino + Nombre_Archivo)))
            //    {

            //        System.IO.File.Copy((Ruta_Origen + Nombre_Archivo), (Ruta_Destino + Nombre_Archivo));
            //    }

            //    //Copio Historico
            //    if (!System.IO.File.Exists((Ruta_Origen + Ruta_Destino_historial)))
            //    {

            //        System.IO.Directory.CreateDirectory(Ruta_Destino_historial);

            //        var path = (Ruta_Destino_historial + "\\" + Nombre_Archivo);

            //        System.IO.File.Copy((Ruta_Origen + Nombre_Archivo), path);
            //    }

            //    //Elimino El archivo original
            //    System.IO.File.Delete((Ruta_Origen + Nombre_Archivo));
        }

        }
    }
//}
