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

        public string InsertarAntesDeX(int posicion, string informacion)
        {
            if (posicion < 0 || PrimerNodo == null) return "Posición inválida"; // Verifica posición inválida o lista vacía

            Nodo nodoNuevo = new Nodo(informacion);
            Nodo nodoActual = PrimerNodo;

            // Si la posición es 0, insertar al inicio
            if (posicion == 0)
            {
                nodoNuevo.ReferenciaSiguiente = PrimerNodo;
                PrimerNodo.ReferenciaAnterior = nodoNuevo;
                PrimerNodo = nodoNuevo;
                return "Nodo insertado correctamente";
            }

            for (int i = 0; nodoActual != null && i < posicion; i++)
            {
                nodoActual = nodoActual.ReferenciaSiguiente;
            }

            if (nodoActual == null) return "Posición fuera de rango"; 

            nodoNuevo.ReferenciaSiguiente = nodoActual;
            nodoNuevo.ReferenciaAnterior = nodoActual.ReferenciaAnterior;

            if (nodoActual.ReferenciaAnterior != null)
            {
                nodoActual.ReferenciaAnterior.ReferenciaSiguiente = nodoNuevo;
            }

            nodoActual.ReferenciaAnterior = nodoNuevo;

            return "Nodo insertado correctamente";
        }

        public string InsertarDespuesDeX(int posicion, string informacion)
        {
            if (posicion < 0 || PrimerNodo == null) return "Posición inválida"; 

            Nodo nodoNuevo = new Nodo(informacion);
            Nodo nodoActual = PrimerNodo;

            for (int i = 0; nodoActual != null && i < posicion; i++)
            {
                nodoActual = nodoActual.ReferenciaSiguiente;
            }

            if (nodoActual == null) return "Posición fuera de rango"; 

            nodoNuevo.ReferenciaSiguiente = nodoActual.ReferenciaSiguiente;
            nodoNuevo.ReferenciaAnterior = nodoActual;

            if (nodoActual.ReferenciaSiguiente != null)
            {
                nodoActual.ReferenciaSiguiente.ReferenciaAnterior = nodoNuevo;
            }

            nodoActual.ReferenciaSiguiente = nodoNuevo;

            return "Nodo insertado correctamente";
        }

        public string EliminaralInicio()
        {
            if (EstaVacia())
                return "La lista está vacía, no se puede eliminar.";

            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = null;
                UltimoNodo = null;
            }
            else
            {
                PrimerNodo = PrimerNodo.ReferenciaSiguiente;
                PrimerNodo.ReferenciaAnterior = null;
            }

            return "Nodo eliminado al inicio correctamente.";
        }

        public string InsertarAntesDeDato(string datoReferencia, string nuevoValor)
        {
            if (EstaVacia())
                return "La lista está vacía.";

            Nodo actual = PrimerNodo;

            while (actual != null && actual.Informacion != datoReferencia)
            {
                actual = actual.ReferenciaSiguiente;
            }

            if (actual == null)
                return "El dato de referencia no existe en la lista.";

            Nodo nuevo = new Nodo(nuevoValor);

            if (actual == PrimerNodo)
            {
                nuevo.ReferenciaSiguiente = PrimerNodo;
                PrimerNodo.ReferenciaAnterior = nuevo;
                PrimerNodo = nuevo;
            }
            else
            {
                Nodo anterior = actual.ReferenciaAnterior;
                anterior.ReferenciaSiguiente = nuevo;
                nuevo.ReferenciaAnterior = anterior;

                nuevo.ReferenciaSiguiente = actual;
                actual.ReferenciaAnterior = nuevo;
            }

            return "Nodo insertado antes del dato correctamente.";
        }

        public List<string> ObtenerValores()
        {
            List<string> valores = new List<string>();
            Nodo? temporal = PrimerNodo;
            while (temporal != null)
            {
                valores.Add(temporal.Informacion);
                temporal = temporal.ReferenciaSiguiente;
            }
            return valores;
        }
    }
}
