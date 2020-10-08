using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsole
{
    class Program
    {
        static Agencia agencia = new Agencia();
        
        static void Main(string[] args)
        {
            agencia.cotizacion = 43;
            int opcion = 0;
            bool salir = false;
            //
            while (salir == false)
            {
                MostrarMenu();
                opcion = PedirNumero();
                switch (opcion)
                {
                    case 1:
                        IngresarUnDestino();
                        break;
                    case 2:
                        VisualizarTodosLosDestinos();
                        break;
                    case 3:
                        ModificarCotizacionDolar();
                        break;
                    case 4:
                        PrecargaDatos();
                        break;
                    case 5:
                        VisualizarTodasLasExcursiones();
                        break;
                    case 0:
                        salir = true;
                        break;
                }
            }
        }

        private static void MostrarMenu()
        {
            Console.WriteLine();
            Console.WriteLine("         Menu            ");
            Console.WriteLine("*************************");
            Console.WriteLine("1 - Ingresar un Destino");
            Console.WriteLine("2 - Visualizar destinos disponibles");
            Console.WriteLine("3 - Modificar Cotización");
            Console.WriteLine("4 - Precarga Datos");
            Console.WriteLine("5 - Listar todas las Excursiones");

            Console.WriteLine();
            Console.WriteLine("0 - Salir");
            Console.WriteLine();

            


        }

        private static int PedirNumero(string mensaje = "Ingrese el numero:")
        {
            int num;
            bool valido = false;
            do
            {
                Console.WriteLine(mensaje);
                valido = int.TryParse(Console.ReadLine(), out num);
                if (!valido)
                {
                    Console.WriteLine("Solo se admiten numeros");
                }
            } while (!valido);
            return num;
        }

        private static void IngresarUnDestino()
        {
            Console.WriteLine("Ingresar Ciudad");
            string ciudad = Console.ReadLine();
            Console.WriteLine("Ingresar Pais");
            string pais = Console.ReadLine();
            Console.WriteLine("Ingresar cantidad de dias de estadia");
            int cantidadDias = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresar costo diario");
            double costoDiario = double.Parse(Console.ReadLine());
            
            if(agencia.IngresarDestino(ciudad, pais, cantidadDias, costoDiario))
                Console.WriteLine("Destino Ingresado");
            else
                Console.WriteLine("El Destino no pudo ser Ingresado");
            
        }
        private static void PrecargaDatos()
        {
            agencia.PreCargaDatos();
        }

        private static void ModificarCotizacionDolar()
        {
            Console.WriteLine("Cotizacion actual del dolar: " + agencia.cotizacion);
            Console.WriteLine("Ingrese el nuevo valor de cotizacion");
            double nuevaCotizacion;
            bool valor = double.TryParse(Console.ReadLine(), out nuevaCotizacion);
            if(valor && nuevaCotizacion >= 0)
            {
                agencia.cotizacion = nuevaCotizacion;
                Console.WriteLine("Se guardo correctamente");
            }
            else
            {
                Console.WriteLine("Error de dato ingresado");
            }
        }


        //Visualizar todos los destinos
        private static void VisualizarTodosLosDestinos()
        {
            foreach (var item in agencia.ObtenerDestinos())
            {
                Console.WriteLine(item.ToString() +
                    "Estadia " + "$ " + (item.CantidadDias * item.CostoDiario * agencia.cotizacion) + "\n");

            }

        }

        //Visializar todas las Excursiones
        private static void VisualizarTodasLasExcursiones()
        {
            foreach (var item in agencia.listaExcursiones)
            {
                Console.WriteLine(item.ToString() +
                    "Costo total por persona $ " + (item.CostoTotal() * agencia.cotizacion) + "\n");

            }
        }

    }
}
