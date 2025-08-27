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
    }
}
