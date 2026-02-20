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

            Console.WriteLine("Situcion inicial ");
            if (n % 2 == 0)
            {
                
                while (m < totalMov)
                {
                    if (mover_disco(ini, aux)) { m++; ImprimirEstado(m, ini, aux, fin); }
                    if (m < totalMov && mover_disco(ini, fin)) { m++; ImprimirEstado(m, ini, aux, fin); }
                    if (m < totalMov && mover_disco(aux, fin)) { m++; ImprimirEstado(m, ini, aux, fin); }
                }
            }
            else
            {
                while (m < totalMov)
                {
                    if (mover_disco(ini, fin)) { m++; ImprimirEstado(m, ini, aux, fin); }
                    if (m < totalMov && mover_disco(ini, aux)) { m++; ImprimirEstado(m, ini, aux, fin); }
                    if (m < totalMov && mover_disco(aux, fin)) { m++; ImprimirEstado(m, ini, aux, fin); }
                }
            }

            return m;

        }


        public int Recursivo(int n, Pila ini, Pila aux, Pila fin)
        {
            int movimientos = 0;

            void Hanoi(int discos, Pila origen, Pila auxiliar, Pila destino)
            {
                if (discos == 1)
                {
                    mover_disco(origen, destino);
                    movimientos++;
                    ImprimirEstado(movimientos, ini, aux, fin);
                }
                else
                {
                    Hanoi(discos - 1, origen, destino, auxiliar);

                    mover_disco(origen, destino);
                    movimientos++;
                    ImprimirEstado(movimientos, ini, aux, fin); 

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

        void ImprimirEstado(int mov, Pila ini, Pila aux, Pila fin)
        {
            Console.WriteLine($"\nsituación del movimiento {mov}");
            ini.MostrarPila();
            aux.MostrarPila();
            fin.MostrarPila();
            Console.WriteLine("---------------------------");
        }





    }
}
