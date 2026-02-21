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
        public int Size { get; set; } // Cuantos discos hay en la pila actualmente
        public int Top { get; set; } // Indice del ultimo disco en la pila, si es -1 no hay ningun disco
        public string Name { get; set; } // Nombre de la pila, para mostrarlo al usuario en la consola


        public Disco[] Elementos { get; set; } // Array que representa la pila, cada elemento es un disco

        // Metodos
        public Pila(int cant_max ,string nombre) // Constructor, se ejecuta al hacer 'new Pila(5, "ini")'
        {
            this.Top = -1; // Indice del ultimo disco en la pila si es -1 no hay ningun disco
            this.Elementos = new Disco[cant_max] ; // Definimos como de grande es la pila
            this.Size = 0; // Numero de discos en la pila
            this.Name = nombre; // Nombre de la pila
        }

        // Metodo para agregar un disco a la pila, se ejecuta al hacer 'pila.push(disco)'
        public void push(Disco d)
        {
            Top++;
            Elementos[Top] = d; // Añadir el nuevo disco a la ultima posicion usando el índice
            Size++;
        }

        // Metodo para sacar un disco de la pila, se ejecuta al hacer 'pila.pop()'
        public Disco pop()
        {
            Disco d = Elementos[Top]; // Guardamos disco temporalmente para devolverlo al final del metodo
            Elementos[Top] = null; // Eliminamos disco en la última posición de la pila
            Size--;
            Top--;
            return d; // Devolvemos el disco que hemos eliminado, esto es muy útil para usarlo en conjunto con el push y mover discos de una pila a otra
        }                

        // Metodo para decir si una pila está vacía o no.
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

        // Metodo para mostrar el estado de la pila, se ejecuta al hacer 'pila.MostrarPila()'
        public void MostrarPila()
        {
            // Obtenemos los tamaños de los discos y los unimos con comas
            var discos = Elementos.Take(Size)
                                 .Select(d => d.Tamano.ToString());
                                 

            Console.WriteLine($"Torre {Name}: {string.Join(", ", discos)}");
        }

    }
}

