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
        public string Name { get; set; }


        public Disco[] Elementos { get; set; }

        /* TODO: Implementar métodos */
        public Pila(int cant_max ,string nombre)
        {
            this.Top = -1; //indice del ultimo disco en la pila si es -1 no hay ningun disco
            this.Elementos = new Disco[cant_max] ; //definimos como de grande es la pila
            this.Size = 0; //numero de discos en la pila
            this.Name = nombre; //nombre de la pila
        }
        
        
        public void push(Disco d)
        {
            Top++;
            Elementos[Top] = d; //Añadir nuevo disco
            Size++;
        }

        public Disco pop()
        {//sacar disco
            Disco d = Elementos[Top]; //guardamos disco
            Elementos[Top] = null; //Eliminamos disco
            //actualizar tamanos
            Size--;
            Top--;
            return d; //devolvemos disco
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
        public void MostrarPila()
        {
            // Obtenemos los tamaños de los discos y los unimos con comas
            var discos = Elementos.Take(Top + 1)
                                 .Select(d => d.Tamano.ToString());
                                 

            Console.WriteLine($"Torre {Name}: {string.Join(", ", discos)}");
        }

    }
}

