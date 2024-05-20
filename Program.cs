using System.Security.Cryptography.X509Certificates;

namespace Defontana;
public class Nodo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public int IdPadre { get; set; }
}

public class NodoArbol
        {
            public Nodo Nodo { get; set; }
            public List<NodoArbol> Hijos { get; set; }
        }

public class ArbolGenealogico
{
    public void CrearArbol(List<Nodo> listaNodos)
{
    Dictionary<int, NodoArbol> diccionarioNodos = new Dictionary<int, NodoArbol>();

    foreach (var nodo in listaNodos)
    {
        diccionarioNodos[nodo.Id] = new NodoArbol { Nodo = nodo, Hijos = new List<NodoArbol>() };
    }

    NodoArbol? raiz = null;
    foreach (var nodoArbol in diccionarioNodos.Values)
    {
        if (nodoArbol.Nodo.IdPadre == 0)
        {
            raiz = nodoArbol;
        }
        else
        {
            diccionarioNodos[nodoArbol.Nodo.IdPadre].Hijos.Add(nodoArbol);
        }
    }

    List<List<NodoArbol>> nivelesNodos = new List<List<NodoArbol>>();

    void CrearNiveles(NodoArbol nodo, int nivel)
    {
        while (nivelesNodos.Count <= nivel)
        {
            nivelesNodos.Add(new List<NodoArbol>());
        }

        nivelesNodos[nivel].Add(nodo);

        foreach (var hijo in nodo.Hijos)
        {
            CrearNiveles(hijo, nivel + 1);
        }
    }

    CrearNiveles(raiz, 0);

    for (int i = 0; i < nivelesNodos.Count; i++)
    {
        Console.WriteLine((i + 1).ToString());
        foreach (var nodo in nivelesNodos[i])
        {
            Console.WriteLine(nodo.Nodo.Nombre);
        }
    }
}

}
class Program
{
    static void Main(string[] args)
    {
    //1-1.- Genera una lista de 10.000.000 números enteros aleatorios entre -100.000 y 100.000.
        List<int> numAleatorio = new();

        Random randoms = new Random();


        for (int i = 1; i < 10000000; i++)
        {
            var numRandom = randoms.Next(-100000, 100001);
            numAleatorio.Add(numRandom);
        }

        // (var num in numAleatorio)
        //{
        //   Console.WriteLine(num);
        //}


        //1-2.- Imprime en distintas líneas por consola los siguientes datos:
        //- El valor más alto en la lista.
        //- El valor más bajo en la lista.
        //- El promedio de todos los valores en la lista.
        //- La cantidad de veces que se obtuvo el valor 0.
        var valorAlto = numAleatorio.Max();
        var valorMin = numAleatorio.Min();
        var valorPromedio = numAleatorio.Average();
        var numCount = numAleatorio.Where(x => x == 0).Count();

        Console.WriteLine(valorAlto);
        Console.WriteLine(valorMin);
        Console.WriteLine(valorPromedio);
        Console.WriteLine($"El numero 0 se repite: {numCount}");

        //1-3.- Imprime los 5 valores que más se repiten desde el más repetido al que menos lo hace, indicando para cada uno cuántas veces se repite.
        var grupoValores = numAleatorio.GroupBy(x => x).OrderByDescending(o => o.Count()).Take(5);

        foreach (var group in grupoValores)
        {
            Console.WriteLine($"Grupo de valores {group.Key} veces repetidas {group.Count()}");
        }
            //2.1.- En base al siguiente listado:
            //Implementa un ordenamiento, desde el valor más pequeño al más alto, con cualquier algoritmo implementado por ti (sin usar Sort(), OrderBy(), o métodos similares).
        var lista = new List<int>{
            15, 16, 14, 19,1, 20, 4, 13, 5, 23, 3, 7, 18, 12, 8, 11, 10, 9, 3, 6, 32, 11, 14, 7, 5, 2, 3, 4, 5, 2, 7, 8, 5, 9, 1, 5, 20, 11, 13, 6, 13, 17, 19, 4, 8, 7, 9, 6, 16, 12, 11, 5, 9};
        
        OrdenarLista(lista);

        Console.WriteLine("Lista ordenada:");
        foreach (var numOrder in lista)
        {
            Console.WriteLine(numOrder);
        }

            static void OrdenarLista(List<int> lista){

                for (int i = 0; i < lista.Count; i++)
            {
                int numActual = lista[i];
                int j = i - 1 ;

                while (j >= 0 && lista[j] > numActual)
                {
                    lista[j+ 1] = lista[j];
                    j--;
                }
                lista[j + 1] = numActual;
            }
            }
        
        //3-1.- En base a la siguiente clase y lista de datos:
        //Genera un método para armar un árbol genealógico de la familia que contiene los datos.
    List<Nodo> listaNodos = new()
    {
    new Nodo
    {
        Id = 1,
        Nombre = "Yo",
        IdPadre = 4,
    },
    new Nodo
    {
        Id = 2,
        Nombre = "Hermano",
        IdPadre = 4,
    },
    new Nodo
    {
        Id = 3,
        Nombre = "Hermana",
        IdPadre = 4,
    },
    new Nodo
    {
        Id = 4,
        Nombre = "Madre",
        IdPadre = 10,
    },
    new Nodo
    {
        Id = 5,
        Nombre = "Tía",
        IdPadre = 10,
    },
    new Nodo
    {
        Id = 6,
        Nombre = "Prima",
        IdPadre = 5,
    },
    new Nodo
    {
        Id = 7,
        Nombre = "Primo",
        IdPadre = 8,
    },
    new Nodo
    {
        Id = 8,
        Nombre = "Tío",
        IdPadre = 10,
    },
    new Nodo
    {
        Id = 9,
        Nombre = "Sobrino",
        IdPadre = 3,
    },
    new Nodo
    {
        Id = 10,
        Nombre = "Abuela",
        IdPadre = 0,
    }
    };

    var arbolg = new ArbolGenealogico();
        arbolg.CrearArbol(listaNodos);

    }
        

}
