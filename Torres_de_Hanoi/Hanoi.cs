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
        public void mover_disco(Pila a, Pila b)
        {

            if (a.isEmpty() == false ) {
                
                if (b.isEmpty() == false) {

                    if (a.Elementos[a.Top].Tamano < b.Elementos[b.Top].Tamano)
                    {
                        b.push(a.pop());
                    }
                }
                else { b.push(a.pop(); }                   
            }

        }

        public int iterativo(int n, Pila ini, Pila fin, Pila aux)
        {
            int m = 0;
            if(n%2 == 0)
            {
                for (int i = 0; i < Math.Pow(2,n)-1; i++)
                {
                    mover_disco(ini, fin);
                    m++;
                    i++; //cada movimiento cuenta
                    mover_disco(ini, aux);
                    m++;
                    i++;
                    mover_disco(aux, fin);
                    m++;
                }
               

            }
            else if (n % 2 != 0)
            {
                for (int i = 0; i < Math.Pow(2, n) - 1; i++)
                {
                    mover_disco(ini, aux);
                    m++;
                    i++; //cada movimiento cuenta
                    mover_disco(ini, fin);
                    m++;
                    i++;
                    mover_disco(aux, fin);
                    m++;
                }
            }
            return m;
        }

    }
}
