namespace pruebaSemana01
{
    internal class Nodo<TipoDato>
    {
        public TipoDato Dato { get; set; }
        public Nodo<TipoDato> Siguiente { get; set; }

        public Nodo(TipoDato dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
}