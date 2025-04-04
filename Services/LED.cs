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
                if (aux.Informacion == dato) {
                    Nodo nodoEliminar = aux.ReferenciaAnterior;

                    if(nodoEliminar == PrimerNodo)
                    {
                        PrimerNodo = PrimerNodo.ReferenciaSiguiente;
                        PrimerNodo.ReferenciaAnterior = null;
                        return "Nodo eliminado con éxito";
                    }
                    else
                    {
                        aux.ReferenciaAnterior = nodoEliminar.ReferenciaAnterior;
                        nodoEliminar.ReferenciaAnterior.ReferenciaSiguiente = aux;
                        return "Nodo eliminado con éxito";
                    }
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
                return "Nodo eliminado con éxito";
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
