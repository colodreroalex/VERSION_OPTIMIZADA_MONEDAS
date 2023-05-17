using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoConversorMonetario
{
    public class Files
    {
        //Fichero
        const string FICHERO = "config.txt";

        //Valores por defecto de las monedas
        const double EURO = 1.3635;
        const double DOLLAR = 0.7374;

        internal static void CheckFile()
        {
            if (!File.Exists( FICHERO )) 
            {
                CreateFile(EURO, DOLLAR); 
            }
        }

        public static void CreateFile(double eur, double doll)
        {

            //Abrimos el flujo
            StreamWriter writer = null;

            //Comprobamos que exista y eliminamos
            if(File.Exists(FICHERO)) File.Delete(FICHERO);

            //Creamos de nuevo
            writer = File.CreateText(FICHERO);

            //Escribimos en la linea 1,2
            writer.WriteLine(eur);
            writer.WriteLine(doll);

            //Cerramos el flujo
            writer.Close();

        }

        public static double ObtainValueFromFile(byte line)
        {
            StreamReader reader = null;
            double value = 0;

            if (!File.Exists(FICHERO)) throw new Exception("File doesnt exists...");
            else reader = File.OpenText(FICHERO);

            try
            {
                //Posicion del puntero en el dato a leer del fichero 
                for (int i = 0; i < line; i++) reader.ReadLine(); 

                //Lee fichero y convierte a double
                value = Convert.ToDouble(reader.ReadLine());
                
            }
            catch (Exception ex)
            {
                reader.Close();
                throw new Exception(ex.Message); 
            }

            reader.Close();

            return value; 
        }
    }
}
