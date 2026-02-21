using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Llamada a la función que comienza el programa y de manera recursiva se vuelve a llamar para jugar de nuevo
            program();
        }

        // Esta función comprueba si el usuario ha escrito correctamente para elegir el modo iterativo o recursivo
        // Y de manera recursiva vuelve ha llamarse en caso de error
        static public string comprobar_IoR()
        {
            Console.WriteLine("¿Para iterativo escrive I y para recursivo R ?");
            string IoR = Console.ReadLine();

            if (IoR.ToUpper() == "I")
            {
                return IoR.ToUpper();
            }
            else if (IoR.ToUpper() == "R")
            {
                return IoR.ToUpper();
            }
            else
            {
                Console.WriteLine("Debes seleccionar I o R prueba de nuevo");
                return comprobar_IoR();
               
            }
             
        }

        // Esta función comprueba si se introduce un numero "valido"
        // Tiene que ser un numero entero y mayor que 0
        // En caso de error se vuelve a llamar de manera recursiva
        static public int comprobar_Discos()
        {
            int n;

            while (true)
            {
                Console.WriteLine("¿Cuántos discos quieres?");
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out n))
                {
                    if (n > 0)
                    {
                        return n;
                    }
                    else
                    {
                        Console.WriteLine("El número debe ser mayor que 0.");
                    }
                }
                else
                {
                    Console.WriteLine("Debes introducir un número válido.");
                }
            }
        }

        // Esta es la función principal que inicia el programa, inicializa las variables
        // y llama a las funciones para ejercutar Hanoi
        static public void program()
        {
            // Limpiamos la consola, para que cada vez que vuelvas a jugar se vea limpio
            Console.Clear();

            Console.WriteLine("========================================================");
            Console.WriteLine("              Bienvenido a las torres de hanoi          ");
            Console.WriteLine("========================================================");

            int movimientos = 0;
            int n = comprobar_Discos();
            string IoR_comp = comprobar_IoR();

            Pila ini = new Pila(n, "ini");
            Pila aux = new Pila(n, "aux");
            Pila fin = new Pila(n, "fin");

            // Crear discos del mayor al menor
            for (int i = n; i >= 1; i--)
            {
                ini.push(new Disco(i));
            }

            Hanoi h = new Hanoi();
            
            if (IoR_comp == "I")
            {
                movimientos = h.iterativo(n, ini, aux, fin);
            }
            else if (IoR_comp == "R")
            {
                 movimientos = h.Recursivo(n, ini, aux, fin);
            }

            // Mostramos los movimientos realizados al final
            Console.WriteLine("Movimientos realizados: " + movimientos);
            // Si quiere volver a jugar escribe E y comienza de nuevo, sino se cierra el programa
            Console.WriteLine("Presiona E para volver a jugar y cualquier tecla para cerrar");
            string volver = Console.ReadLine();
            if (volver.ToUpper() == "E")
            {
                program();
            } 
            
        }
    }
}
