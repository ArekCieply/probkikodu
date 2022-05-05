using System;
using System.Linq;

public class listaint
{
    public List<int> lista;

    public listaint(List<int> lista)
    {
        this.lista = lista;
    }

    public static bool operator <(listaint a, listaint b)
    {
        int suma = a.lista.Sum();
        int sumb = b.lista.Sum();
        bool status = false;
        if (suma < sumb)
            status = true;
        return status;
    }
    public static bool operator >(listaint a, listaint b)
    {
        int suma = a.lista.Sum();
        int sumb = b.lista.Sum();
        bool status = false;
        if (suma > sumb)
            status = true;
        return status;
    }
    public static implicit operator listaint(List<int> lista)
    {
        return new listaint(lista);
    }
}
static class program
{
    static void Main()
    {
        List<int> a = new List<int>() { 1, 2, 3, 4 };
        List<int> b = new List<int>() { 20,30};

        var wynik = (listaint) a < b;
        Console.WriteLine(wynik);
        Console.WriteLine((listaint)a > b);
    }
}
