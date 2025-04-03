namespace ListaEnlazadaDoble.Models
{
    public class Nodo
    {
        public string Informacion { get; set; }
        public Nodo? ReferenciaAnterior { get; set; }
        public Nodo? ReferenciaSiguiente { get; set; }

        public Nodo()
        {
            Informacion = string.Empty;
            ReferenciaAnterior = null;
            ReferenciaSiguiente = null;
        }

        public Nodo(string informacion)
        {
            Informacion = informacion;
            ReferenciaAnterior = null;
            ReferenciaSiguiente = null;
        }

        public override string ToString()
        {
            return $"{Informacion} ==> ";
        }
    }
}

