using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Disco
    {
        // Getters y Setters para el tamaño del disco
        public int Tamano { get; set; }

        // Constructor: se ejecuta al hacer 'new Disco(5)'
        public Disco(int tamano)
        {
            Tamano = tamano;
        }

    }
}
