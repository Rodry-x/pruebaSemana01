namespace pruebaSemana01
{
    internal class ListaSimple<TipoDato>
    {
        private Nodo<TipoDato> cabeza;
        public ListaSimple()
        {
            cabeza = null;
        }

        public void InsertarAlInicio(TipoDato dato)
        {
            Nodo<TipoDato> nuevoNodo = new Nodo<TipoDato>(dato);
            nuevoNodo.Siguiente = cabeza;
            cabeza = nuevoNodo;
        }

        public void InsertarVariosAlInicio(IEnumerable<TipoDato> datos)
        {
            foreach (var dato in datos)
            {
                InsertarAlInicio(dato);
            }
        }
        public void InsertarAlFinal(TipoDato dato)
        {
            Nodo<TipoDato> nuevoNodo = new Nodo<TipoDato>(dato);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                return;
            }
            else
            {
                Nodo<TipoDato> actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
        }

        public void Mostrar()
        {
            if (cabeza == null)
            {
                Console.WriteLine("Lista Vacia");
                return;
            }

            Nodo<TipoDato> actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine(actual.Dato?.ToString());
                actual = actual.Siguiente;
            }
        }

        public void InsertarAscendente(TipoDato dato)
        {
            Nodo<TipoDato> nuevoNodo = new Nodo<TipoDato>(dato);

            // Si la lista está vacía o el nuevo dato es menor que la cabeza
            if (cabeza == null || Comparar(dato, cabeza.Dato) < 0)
            {
                nuevoNodo.Siguiente = cabeza;
                cabeza = nuevoNodo;
                return;
            }

            Nodo<TipoDato> actual = cabeza;
            while (actual.Siguiente != null && Comparar(dato, actual.Siguiente.Dato) >= 0)
            {
                actual = actual.Siguiente;
            }
            nuevoNodo.Siguiente = actual.Siguiente;
            actual.Siguiente = nuevoNodo;
        }

        // Método auxiliar para comparar dos elementos
        private int Comparar(TipoDato a, TipoDato b)
        {
            return Comparer<TipoDato>.Default.Compare(a, b);
        }

        public int ContarElementos()
        {
            int contador = 0;
            Nodo<TipoDato> actual = cabeza;
            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }
            return contador;
        }

        public int SumarElementos()
        {
            int suma = 0;
            Nodo<TipoDato> actual = cabeza;
            while (actual != null)
            {
                suma += Convert.ToInt32(actual.Dato);
                actual = actual.Siguiente;
            }
            return suma;
        }

        public TipoDato? ObtenerPrimero()
        {
            return cabeza != null ? cabeza.Dato : default;
        }

        public TipoDato? ObtenerUltimo()
        {
            if (cabeza == null) return default;
            Nodo<TipoDato> actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            return actual.Dato;
        }
    }
}
