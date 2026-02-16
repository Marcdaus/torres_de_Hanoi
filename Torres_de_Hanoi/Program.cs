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
            program();
        }
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
                Console.WriteLine("Debes seleccionar I o R pruebade nuevo");
                return comprobar_IoR();
               
            }
             
        }
        static public int comprobar_Discos()
        {

            Console.WriteLine("¿Cuantos discos quieres?");

            int n;
            bool esNumero = int.TryParse(Console.ReadLine(), out n);

            if (esNumero)
            {
                return n;
            }
            else
            {
                Console.WriteLine("Debes seleccionar un numero");
                return comprobar_Discos();

            }

        }
        static public void program()
        {
            Console.Clear();
            //Variables
            int movimientos = 0;

            Console.WriteLine("========================================================");
            Console.WriteLine("              Bienvenido a las torres de hanoi          ");
            Console.WriteLine("========================================================");

            int n = comprobar_Discos();


            Pila ini = new Pila(n);
            Pila aux = new Pila(n);
            Pila fin = new Pila(n);

            // Crear discos del mayor al menor
            for (int i = n; i >= 1; i--)
            {
                ini.push(new Disco(i));
            }

            Hanoi h = new Hanoi();
            string IoR_comp = comprobar_IoR();

            if (IoR_comp == "I")
            {
                movimientos = h.iterativo(n, ini, aux, fin);
            }
            else if (IoR_comp == "R")
            {
                // movimientos = h.recursivo(n, ini, aux, fin);
            }


            Console.WriteLine("Movimientos realizados: " + movimientos);

            Console.WriteLine("Presiona E para volver a jugar y cualquier tecla para cerrar");
            string volver = Console.ReadLine();
            if (volver.ToUpper() == "E")
            {
                
                program();
            } 
            
        }
    }
}
