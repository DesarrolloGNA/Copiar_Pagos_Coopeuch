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

            string Fecha = DateTime.Now.ToString("dd-MM-yyyy");
            string Ruta_Origen = @"C:\Coopeuch\Pagos\";
            string Ruta_Destino = @"\\192.168.0.227\COO_Coopeuch\02.Pagos\";
            string Nombre_Archivo = "Recupero_castigo_GARCIA NADAL_" + Fecha + ".xlsx.xlsx";
            string Ruta_Destino_historial = @"C:\coopeuch\pagos\his\" + Fecha;

            //Valido que el directorio este disponible
            while (!System.IO.Directory.Exists(Ruta_Destino)) { }

            if (System.IO.File.Exists((Ruta_Origen + Nombre_Archivo)))
            {
                //Copio Tecnocob
                if (!System.IO.File.Exists((Ruta_Destino + Nombre_Archivo)))
                {

                    System.IO.File.Copy((Ruta_Origen + Nombre_Archivo), (Ruta_Destino + Nombre_Archivo));
                }

                //Copio Historico
                if (!System.IO.File.Exists((Ruta_Origen + Ruta_Destino_historial)))
                {

                    System.IO.Directory.CreateDirectory(Ruta_Destino_historial);

                    var path = (Ruta_Destino_historial + "\\" + Nombre_Archivo);

                    System.IO.File.Copy((Ruta_Origen + Nombre_Archivo), path);
                }

                //Elimino El archivo original
                System.IO.File.Delete((Ruta_Origen + Nombre_Archivo));
            }

        }
    }
}
