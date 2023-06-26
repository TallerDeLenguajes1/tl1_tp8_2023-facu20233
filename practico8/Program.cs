using System;
using System.Collections.Generic;

namespace TareasApp
{
    public class Tarea
    {
        public int TareaId { get; set; }
        public string Descripcion { get; set; }
        public int Duracion { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tareas a cargar: ");
            int numTareas = Convert.ToInt32(Console.ReadLine());

            List<Tarea> listaTareas = new List<Tarea>();

            for (int i = 0; i < numTareas; i++)
            {
                Tarea tarea = new Tarea();

                tarea.TareaId = i + 1;

                Console.WriteLine($"Ingrese la descripción de la tarea {i + 1}: ");
                tarea.Descripcion = Console.ReadLine();

                Console.WriteLine("Ingrese la duración de la tarea (entre 10 y 100): ");
                tarea.Duracion = Convert.ToInt32(Console.ReadLine());

                listaTareas.Add(tarea);
            }

            Console.WriteLine("Tareas realizadas:");
            List<Tarea> tareasRealizadas = new List<Tarea>();

            foreach (Tarea tarea in listaTareas)
            {
                Console.WriteLine($"¿Se realizó la tarea {tarea.TareaId}? (s/n):");
                char respuesta = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (respuesta == 's')
                {
                    tareasRealizadas.Add(tarea);
                }
            }

            Console.WriteLine("Tareas pendientes:");
            List<Tarea> tareasPendientes = new List<Tarea>();

            foreach (Tarea tarea in listaTareas)
            {
                if (!tareasRealizadas.Contains(tarea))
                {
                    tareasPendientes.Add(tarea);
                }
            }

            Console.WriteLine("Tareas realizadas:");
            foreach (Tarea tarea in tareasRealizadas)
            {
                Console.WriteLine($"Tarea {tarea.TareaId}:");
                Console.WriteLine($"Descripción: {tarea.Descripcion}");
                Console.WriteLine($"Duración: {tarea.Duracion}");
            }

            Console.WriteLine("Tareas pendientes:");
            foreach (Tarea tarea in tareasPendientes)
            {
                Console.WriteLine($"Tarea {tarea.TareaId}:");
                Console.WriteLine($"Descripción: {tarea.Descripcion}");
                Console.WriteLine($"Duración: {tarea.Duracion}");
            }

            Console.WriteLine("Ingrese el número de id de la tarea a buscar:");
            int id = Convert.ToInt32(Console.ReadLine());

            Tarea tareaPorId = BuscarTareaPorId(id, listaTareas);

            if (tareaPorId != null)
            {
                Console.WriteLine("Tarea encontrada:");
                Console.WriteLine($"Tarea {tareaPorId.TareaId}:");
                Console.WriteLine($"Descripción: {tareaPorId.Descripcion}");
                Console.WriteLine($"Duración: {tareaPorId.Duracion}");
            }
            else
            {
                Console.WriteLine($"No se encontró la tarea con el número de id {id}");
            }

            Console.WriteLine("Ingrese una palabra a buscar:");
            string palabra = Console.ReadLine();

            Tarea tareaPorPalabra = BuscarTareaPorPalabra(palabra, listaTareas);

            if (tareaPorPalabra != null)
            {
                Console.WriteLine("Tarea encontrada:");
                Console.WriteLine($"Tarea {tareaPorPalabra.TareaId}:");
                Console.WriteLine($"Descripción: {tareaPorPalabra.Descripcion}");
                Console.WriteLine($"Duración: {tareaPorPalabra.Duracion}");
            }
            else
            {
                Console.WriteLine($"No se encontró la tarea con la palabra {palabra}");
            }
        }

        static Tarea BuscarTareaPorId(int id, List<Tarea> listaTareas)
        {
            return listaTareas.Find(t => t.TareaId == id);
        }

        static Tarea BuscarTareaPorPalabra(string palabra, List<Tarea> listaTareas)
        {
            return listaTareas.Find(t => t.Descripcion.Contains(palabra));
        }
    }
}



