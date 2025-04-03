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

        public string AgregarAlFinal(Nodo nodo) {
            
            if(EstaVacia())
            {
                PrimerNodo = nodo;
                UltimoNodo = nodo;
                return "Nodo agregado con éxito";

            }
            else
            {
                UltimoNodo.ReferenciaSiguiente = nodo;
                nodo.ReferenciaAnterior = UltimoNodo;
                UltimoNodo = nodo;
                return "Nodo agregado con éxito";
            }
            return "Error";
        }
        
        public string EliminarAntesDeX(string dato) { 
            Nodo aux = PrimerNodo;

            if (EstaVacia())
            {
                return "Lista vacía";
            }
            if (PrimerNodo.Informacion == dato)
            {
                return ("No hay nodos por eliminar antes del dato: " + dato);
            }
            while (aux != null)
            {

                if (aux.Informacion == dato && aux.ReferenciaAnterior == PrimerNodo && aux == UltimoNodo)
                {
                    aux.ReferenciaAnterior = null;
                    aux.ReferenciaSiguiente = null;
                    PrimerNodo = aux;
                    UltimoNodo = aux;
                    return "Nodo eliminado con éxito";
                }


                if (aux.Informacion == dato && aux.ReferenciaAnterior == PrimerNodo && aux != UltimoNodo)
                {
                    aux.ReferenciaAnterior = null;
                    PrimerNodo = aux;
                    return "Nodo eliminado con éxito";
                }


                if (aux.Informacion == dato && aux == UltimoNodo)
                {
                    aux.ReferenciaAnterior.ReferenciaAnterior.ReferenciaSiguiente = UltimoNodo;
                    UltimoNodo.ReferenciaAnterior = aux.ReferenciaAnterior.ReferenciaAnterior;
                    aux = null;
                    return "Nodo eliminado con éxito";
                }

                aux = aux.ReferenciaSiguiente;
            }
                
            return "Error al eliminar nodo";
        }


        public string EliminarAlFinal()
        {
            Nodo aux = PrimerNodo;

            if (EstaVacia())
            {
                return "Lista vacía";
            }
            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = null;
                UltimoNodo = null;
                return ("Se eliminó el ultimo Nodo");
            }

            while (aux != null)
            {
             
                if(aux.ReferenciaSiguiente == UltimoNodo)
                {
                    aux.ReferenciaSiguiente = null;
                    UltimoNodo = aux;
                    return "Nodo eliminado con éxito";
                }
                aux = aux.ReferenciaSiguiente;
            }

            return "Error al eliminar nodo";
        }




    }
}
