using System;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la ruta de la carpeta:");
        string rutaCarpeta = Console.ReadLine();

        if (Directory.Exists(rutaCarpeta))
        {
            string[] archivos = Directory.GetFiles(rutaCarpeta);

            Console.WriteLine("\n------ Archivos en la Carpeta ------");
            foreach (string archivo in archivos)
            {
                string nombreArchivo = Path.GetFileNameWithoutExtension(archivo);
                string extensionArchivo = Path.GetExtension(archivo).TrimStart('.');
                Console.WriteLine($"- {nombreArchivo} ({extensionArchivo})");
            }

            string rutaCSV = Path.Combine(rutaCarpeta, "index.csv");
            GenerarArchivoCSV(archivos, rutaCSV);

            Console.WriteLine($"\nEl listado de archivos ha sido guardado en {rutaCSV}");
        }
        else
        {
            Console.WriteLine("La carpeta especificada no existe.");
        }
    }

    static void GenerarArchivoCSV(string[] archivos, string rutaCSV)
    {
        using (StreamWriter writer = new StreamWriter(rutaCSV))
        {
            writer.WriteLine("Índice,Nombre,Extensión");

            for (int i = 0; i < archivos.Length; i++)
            {
                string nombreArchivo = Path.GetFileNameWithoutExtension(archivos[i]);
                string extensionArchivo = Path.GetExtension(archivos[i]).TrimStart('.');
                writer.WriteLine($"{i + 1},{nombreArchivo},{extensionArchivo}");
            }
        }
    }
}

//







