using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Hanoi
    {
        /*TODO: Implementar métodos*/
        public bool mover_disco(Pila a, Pila b)
        {
            if (a.isEmpty() && b.isEmpty())
            {
                Console.WriteLine("Las filas " + a.Name + " y " + b.Name + "están vacías, omitiendo movimiento.");

                return false;
            }


            if (a.isEmpty())
            {
                a.push(b.pop());
                Console.WriteLine("Moviendo " + b.Name + " a " + a.Name + "");
            }
            else if (b.isEmpty())
            {
                b.push(a.pop());
                Console.WriteLine("Moviendo " + a.Name + " a " + b.Name + "");
            }
            else if (a.Elementos[a.Top].Tamano < b.Elementos[b.Top].Tamano)
            {
                b.push(a.pop());
                Console.WriteLine("Moviendo " + a.Name + " a " + b.Name + "");
            }
            else
            {
                a.push(b.pop());
                Console.WriteLine("Moviendo " + b.Name + " a " + a.Name + "");
            }

            return true;
        }


        public int iterativo(int n, Pila ini, Pila aux ,Pila fin)
        {
            int m = 0;
            int totalMov = (1 << n) - 1;

            void ImprimirEstado(int mov)
            {
                Console.WriteLine($"\nsituación del movimiento {mov}");
                ini.MostrarPila();
                aux.MostrarPila();
                fin.MostrarPila();
                Console.WriteLine("---------------------------");
            }

            Console.WriteLine("Situcion inicial ");
            if (n % 2 == 0)
            {
                
                while (m < totalMov)
                {
                    if (mover_disco(ini, aux)) { m++; ImprimirEstado(m); }
                    if (m < totalMov && mover_disco(ini, fin)) { m++; ImprimirEstado(m); }
                    if (m < totalMov && mover_disco(aux, fin)) { m++; ImprimirEstado(m); }
                }
            }
            else
            {
                while (m < totalMov)
                {
                    if (mover_disco(ini, fin)) { m++; ImprimirEstado(m); }
                    if (m < totalMov && mover_disco(ini, aux)) { m++; ImprimirEstado(m); }
                    if (m < totalMov && mover_disco(aux, fin)) { m++; ImprimirEstado(m); }
                }
            }

            return m;

        }
        public int Recursivo(int n, Pila ini, Pila aux, Pila fin)
        {
            int movimientos = 0;

            void ImprimirEstado(int mov)
            {
                Console.WriteLine($"\nsituación del movimiento {mov}");
                ini.MostrarPila();
                aux.MostrarPila();
                fin.MostrarPila();
                Console.WriteLine("---------------------------");
            }

            void Hanoi(int discos, Pila origen, Pila auxiliar, Pila destino)
            {
                if (discos == 1)
                {
                    mover_disco(origen, destino);
                    movimientos++;
                    ImprimirEstado(movimientos);
                }
                else
                {
                    // Paso 1: mover n-1 discos a auxiliar
                    Hanoi(discos - 1, origen, destino, auxiliar);

                    // Paso 2: mover el disco mayor a destino
                    mover_disco(origen, destino);
                    movimientos++;
                    ImprimirEstado(movimientos);

                    // Paso 3: mover los n-1 discos desde auxiliar a destino
                    Hanoi(discos - 1, auxiliar, origen, destino);
                }
            }

            Console.WriteLine("Situación inicial");
            ini.MostrarPila();
            aux.MostrarPila();
            fin.MostrarPila();
            Console.WriteLine("---------------------------");

            Hanoi(n, ini, aux, fin);

            return movimientos;
        }





    }
}
