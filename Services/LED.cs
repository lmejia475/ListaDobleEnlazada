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
        public string AgregarAlInicio(Nodo nodo)
        {
            if (EstaVacia())
            {
                PrimerNodo = nodo;
                UltimoNodo = nodo;
                nodo.ReferenciaAnterior = nodo.ReferenciaSiguiente = null;
                return "Nodo agregado con éxito";

            }
            else
            {
                nodo.ReferenciaSiguiente = PrimerNodo;
                PrimerNodo.ReferenciaAnterior = nodo;
                PrimerNodo = nodo;
                nodo.ReferenciaAnterior = null;
                return "Nodo agregado con éxito";
            }
                return "Error";
        }

        public string AgregarAlFinal(Nodo nodo) {
            
            if(EstaVacia())
            {
                PrimerNodo = nodo;
                UltimoNodo = nodo;
                nodo.ReferenciaAnterior = nodo.ReferenciaSiguiente = null;
                return "Nodo agregado con éxito";

            }
            else
            {
                UltimoNodo.ReferenciaSiguiente = nodo;
                nodo.ReferenciaAnterior = UltimoNodo;
                UltimoNodo = nodo;
                nodo.ReferenciaSiguiente = null;
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
        public string EliminarAntesDePosicion(int posicionX)
        {
            if (PrimerNodo == null) return "La lista está vacía.";
            if (posicionX <= 1) return "No existe nodo antes de la posición 1.";

            if (posicionX == 2)
            {
                PrimerNodo = PrimerNodo.ReferenciaSiguiente;
                PrimerNodo.ReferenciaAnterior = null;
                return "Nodo en posición 1 eliminado.";
            }

            Nodo actual = PrimerNodo;
            for (int i = 1; i < posicionX; i++)
            {
                actual = actual.ReferenciaSiguiente;
            }

            if (actual == null)
                return $"No existe nodo en la posición {posicionX}.";

            
            actual.ReferenciaAnterior = actual.ReferenciaAnterior.ReferenciaAnterior;
            actual.ReferenciaAnterior.ReferenciaSiguiente = actual;

            return $"Nodo en posición {posicionX - 1} eliminado.";
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
            else { 
                UltimoNodo = UltimoNodo.ReferenciaAnterior;
                UltimoNodo.ReferenciaSiguiente = null;
                return "Nodo eliminado con éxito";

            }
            return "Error al eliminar nodo";
        }




    }
}
