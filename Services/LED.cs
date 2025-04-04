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
            else { 
                UltimoNodo = UltimoNodo.ReferenciaAnterior;
                UltimoNodo.ReferenciaSiguiente = null;
                return "Nodo eliminado con éxito";

            }
            return "Error al eliminar nodo";
        }

        public string EliminarDespuesDePosicionX(int X)
        {
            if (EstaVacia())
            {
                return "Lista vacía";
            }

            Nodo? aux = PrimerNodo;
            int contador = 0;

            //moverse hasta la posicion X
            while (aux != null && contador < X)
            {
                aux = aux.ReferenciaSiguiente;
                contador++;
            }

            if (aux == null)
            {
                return "posicion, " + X + " no existe en la lista";
            }

            if (aux.ReferenciaSiguiente == null)
            {
                return "No hay nodo para eliminar despues de posición: " + X;
            }

            Nodo nodoEliminar = aux.ReferenciaSiguiente;

            aux.ReferenciaSiguiente = nodoEliminar.ReferenciaSiguiente;

            if (nodoEliminar.ReferenciaSiguiente != null)
            {
                nodoEliminar.ReferenciaSiguiente.ReferenciaAnterior = aux;
            }
            else
            {
                // Si el nodo a eliminar era el último
                UltimoNodo = aux;
            }

            return "Nodo eliminado despues de posición " + X;
        }

        public string EliminarPorInformacion(string infoX)
        {
            if (EstaVacia())
            {
                return "Lista vacía";
            }

            Nodo? aux = PrimerNodo;

            while (aux != null)
            {
                if (aux.Informacion == infoX)
                {
                    // Si es el único nodo
                    if (PrimerNodo == UltimoNodo)
                    {
                        PrimerNodo = null;
                        UltimoNodo = null;
                    }
                    // Si es el primer nodo
                    else if (aux == PrimerNodo)
                    {
                        PrimerNodo = aux.ReferenciaSiguiente;
                        if (PrimerNodo != null)
                        {
                            PrimerNodo.ReferenciaAnterior = null;
                        }
                    }
                    // Si es el último nodo
                    else if (aux == UltimoNodo)
                    {
                        UltimoNodo = aux.ReferenciaAnterior;
                        if (UltimoNodo != null)
                        {
                            UltimoNodo.ReferenciaSiguiente = null;
                        }
                    }
                    // Nodo en medio de la lista
                    else
                    {
                        aux.ReferenciaAnterior!.ReferenciaSiguiente = aux.ReferenciaSiguiente;
                        aux.ReferenciaSiguiente!.ReferenciaAnterior = aux.ReferenciaAnterior;
                    }

                    return $"Nodo con información '{infoX}' eliminado con éxito.";
                }

                aux = aux.ReferenciaSiguiente;
            }

            return $"No se encontró un nodo con la información '{infoX}'.";
        }


    }
}
