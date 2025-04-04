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
