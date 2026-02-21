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
            int m = 0; // guarda todos los movimientos

            // int totalMov = (1 << n) - 1;  ahorra la conversión de double utilizando
            // números binarios, simplemente desplaza el “1” n veces a la izquierda y le restamos 1.
            int totalMov = (1 << n) - 1; 
            Console.WriteLine("Situcion inicial ");
            if (n % 2 == 0) // comprueba si es par o inpar
            {
                
                while (m < totalMov)
                {
                    //llama a mover discos en el orden de par
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
            int m = 0; // guarda el numero de movimientos para devolverlos al final de la s comparativas

            void Hanoi(int discos, Pila origen, Pila auxiliar, Pila destino)
            {
                if (discos == 1) //comprueba si hay solo hay un disco en n
                {
                    mover_disco(origen, destino);
                    m++;//aumenta los movimientos
                    ImprimirEstado(m, ini, aux, fin); // llama a la funcion para imprimir por pantalla
                }
                else 
                {
                    Hanoi(discos - 1, origen, destino, auxiliar); //se vulve a llamar a si misma restando un uno para diferencia entre par y inpar

                    mover_disco(origen, destino); //llama a la funcion para mover los discos
                    m++;
                    ImprimirEstado(m, ini, aux, fin); 

                    Hanoi(discos - 1, auxiliar, origen, destino); // se encarga de cambiar el orden para el tercer paso
                }
            }
            //texto para la primera peticion
            Console.WriteLine("Situación inicial");
            ini.MostrarPila();
            aux.MostrarPila();
            fin.MostrarPila();
            Console.WriteLine("---------------------------");

            Hanoi(n, ini, aux, fin); //llama a la funcion publica hanoi 

            return m;
        }
        //funcion para imprimir resultados
        void ImprimirEstado(int mov, Pila ini, Pila aux, Pila fin)
        {
            Console.WriteLine($"\nsituación del movimiento {mov}");//\n: permite un salto de pagina   $: permite poner variables ne el texto
            ini.MostrarPila();
            aux.MostrarPila();
            fin.MostrarPila();
            Console.WriteLine("---------------------------");
        }





    }
}
