using System;
using System.Collections.Generic;
using System.IO;

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
            List<Tarea> tareasPendientes = GenerarTareasPendientes(10);

            Console.WriteLine("------ Tareas Pendientes ------");
            MostrarTareas(tareasPendientes);

            List<Tarea> tareasRealizadas = new List<Tarea>();

            while (tareasPendientes.Count > 0)
            {
                Console.WriteLine("\n------ Mover Tareas ------");
                Console.WriteLine("Ingrese el número de la tarea que desea mover (0 para salir):");
                MostrarTareas(tareasPendientes);

                int opcion = Convert.ToInt32(Console.ReadLine());

                if (opcion == 0)
                    break;

                Tarea tarea = BuscarTareaPorId(opcion, tareasPendientes);

                if (tarea != null)
                {
                    MoverTarea(tarea, tareasPendientes, tareasRealizadas);
                    Console.WriteLine($"La tarea {tarea.TareaId} ha sido movida a Tareas Realizadas.");
                }
                else
                {
                    Console.WriteLine("¡Opción inválida! Intente nuevamente.");
                }
            }

            Console.WriteLine("\n------ Tareas Realizadas ------");
            MostrarTareas(tareasRealizadas);

            Console.WriteLine("\n------ Buscar Tareas Pendientes ------");
            Console.WriteLine("Ingrese una descripción para buscar tareas (0 para salir):");

            string descripcion = Console.ReadLine();

            while (descripcion != "0")
            {
                List<Tarea> tareasEncontradas = BuscarTareasPorDescripcion(descripcion, tareasPendientes);

                if (tareasEncontradas.Count > 0)
                {
                    Console.WriteLine($"\nSe encontraron {tareasEncontradas.Count} tareas con la descripción '{descripcion}':");
                    MostrarTareas(tareasEncontradas);
                }
                else
                {
                    Console.WriteLine("No se encontraron tareas con esa descripción.");
                }

                Console.WriteLine("\nIngrese una descripción para buscar tareas (0 para salir):");
                descripcion = Console.ReadLine();
            }

            int totalDuracion = CalcularDuracionTotal(tareasRealizadas);
            GuardarSumarioHorasTrabajadas(totalDuracion);

            Console.WriteLine("\nSumario de horas trabajadas guardado en el archivo 'sumario_horas.txt'");
        }

        static List<Tarea> GenerarTareasPendientes(int cantidad)
        {
            List<Tarea> tareasPendientes = new List<Tarea>();

            Random random = new Random();

            for (int i = 1; i <= cantidad; i++)
            {
                Tarea tarea = new Tarea();
                tarea.TareaId = i;
                tarea.Descripcion = $"Tarea {i}";
                tarea.Duracion = random.Next(10, 101);
                tareasPendientes.Add(tarea);
            }

            return tareasPendientes;
        }

        static void MostrarTareas(List<Tarea> tareas)
        {
            foreach (Tarea tarea in tareas)
            {
                Console.WriteLine($"Tarea {tarea.TareaId}: {tarea.Descripcion} (Duración: {tarea.Duracion})");
            }
        }

        static Tarea BuscarTareaPorId(int id, List<Tarea> tareas)
        {
            return tareas.Find(t => t.TareaId == id);
        }

        static void MoverTarea(Tarea tarea, List<Tarea> listaOrigen, List<Tarea> listaDestino)
        {
            listaOrigen.Remove(tarea);
            listaDestino.Add(tarea);
        }

        static List<Tarea> BuscarTareasPorDescripcion(string descripcion, List<Tarea> tareas)
        {
            return tareas.FindAll(t => t.Descripcion.Contains(descripcion));
        }

        static int CalcularDuracionTotal(List<Tarea> tareas)
        {
            int duracionTotal = 0;

            foreach (Tarea tarea in tareas)
            {
                duracionTotal += tarea.Duracion;
            }

            return duracionTotal;
        }

        static void GuardarSumarioHorasTrabajadas(int duracionTotal)
        {
            using (StreamWriter writer = new StreamWriter("sumario_horas.txt"))
            {
                writer.WriteLine("Sumario de horas trabajadas");
                writer.WriteLine("---------------------------");
                writer.WriteLine($"Duración total: {duracionTotal} horas");
            }
        }
    }
}

//


