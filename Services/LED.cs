using ListaEnlazadaDoble.Models;

namespace ListaEnlazadaDoble.Services
{
    public class LED
    {
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }

        public LED()
        {
            PrimerNodo = null;
            UltimoNodo = null;
        }
        bool EstaVacia()
        {
            return PrimerNodo == null;
        }
    }
}
