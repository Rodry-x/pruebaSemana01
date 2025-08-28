using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaSemana01
{
    internal class NUM7
    {
        // Definición de un nodo para lista enlazada simple
        public class Nodo
        {
            public int Valor;
            public Nodo Siguiente;

            public Nodo(int valor)
            {
                Valor = valor;
                Siguiente = null;
            }
        }

        // Método para comparar dos listas enlazadas
        public static bool SonIguales(Nodo cabeza1, Nodo cabeza2)
        {
            while (cabeza1 != null && cabeza2 != null)
            {
                if (cabeza1.Valor != cabeza2.Valor)
                    return false;

                cabeza1 = cabeza1.Siguiente;
                cabeza2 = cabeza2.Siguiente;
            }

            // Si ambas listas terminaron al mismo tiempo, son iguales
            return cabeza1 == null && cabeza2 == null;
        }
    }
}
