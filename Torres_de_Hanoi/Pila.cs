using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torres_de_Hanoi;

namespace Torres_de_Hanoi
{
    class Pila
    {
        public int Size { get; set; }
        public int Top { get; set; }
        
        public Disco[] Elementos { get; set; };

        /* TODO: Implementar métodos */
        public Pila(int top, Disco[] discos )
        {
            Top.this = top;
            Elementos = discos; 
            Size = Elementos.Length;
        }

        public void push(Disco d)
        {

        }

        public Disco pop()
        {
            Elementos[top] = null;
            Size-1
            return null;
        }                

        public bool isEmpty()
        {
            if (Size == 0)
            {
                return true;
        }else
            {
                return false;
            }
            
        }

    }
}
Pila pila1 { disco.tamano, Disco  }