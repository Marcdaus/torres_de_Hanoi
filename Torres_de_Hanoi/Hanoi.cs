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
                return false;

            if (a.isEmpty())
            {
                a.push(b.pop());
            }
            else if (b.isEmpty())
            {
                b.push(a.pop());
            }
            else if (a.Elementos[a.Top].Tamano < b.Elementos[b.Top].Tamano)
            {
                b.push(a.pop());
            }
            else
            {
                a.push(b.pop());
            }

            return true;
        }


        public int iterativo(int n, Pila ini, Pila fin, Pila aux)
        {
            int m = 0;
            int totalMov = (1 << n) - 1;

            if (n % 2 == 0)
            {
                while (m < totalMov)
                {
                    if (mover_disco(ini, fin)) m++;
                    if (m < totalMov && mover_disco(ini, aux)) m++;
                    if (m < totalMov && mover_disco(aux, fin)) m++;
                }
            }
            else
            {
                while (m < totalMov)
                {
                    if (mover_disco(ini, aux)) m++;
                    if (m < totalMov && mover_disco(ini, fin)) m++;
                    if (m < totalMov && mover_disco(aux, fin)) m++;
                }
            }

            return m;
        }


    }
}
