using System.Collections.Generic;
using System;
using System.Configuration;

public class pracownik<a, b, c, d, e>
{
    public a imie ;
    public b nazwisko;
    public c stanowisko;
    public d placa;
    public e nr;

    public void show()
    {
        Console.WriteLine(imie + " " + nazwisko + " " + stanowisko + " " + placa + " " + nr);
    }
    
}

public class kartoteka : pracownik<string, string, string, int, int>
{
    pracownik<string, string, string, int, int> p = new pracownik<string, string, string, int, int>();
    int klucz;
    
    public kartoteka(string a, string b, string c, int d, int e)
    {
        p.imie = a;
        p.nazwisko = b;
        p.stanowisko = c;
        p.placa = d;
        p.nr = e;
        string key = ConfigurationManager.AppSettings["key"];
        klucz = int.Parse(key);
    }
    public void wczyt(string a, string b, string c, int d, int e)
    {
        p.imie = a;
        p.nazwisko = b;
        p.stanowisko = c;
        p.placa = d;
        p.nr = e;
    }
    public void zapistxt()
    {
        using (StreamWriter w = File.AppendText("pliktxt.txt"))
        {
            w.WriteLine(p.imie);
            w.WriteLine(p.nazwisko);
            w.WriteLine(p.stanowisko);
            w.WriteLine(p.placa);
            w.WriteLine(p.nr);
        }
    }
    public void poka()
    {
        p.show();
    }
    public void validate()
    {
        p.imie = char.ToUpper(p.imie[0]) + p.imie.Substring(1);
        p.nazwisko = char.ToUpper(p.nazwisko[0]) + p.nazwisko.Substring(1);
    }
    public void encrypt()
    {
        p.imie = encipher(p.imie, klucz);
        p.nazwisko = encipher(p.nazwisko, klucz);
        p.stanowisko = encipher(p.stanowisko, klucz);
    }
    public void decrypt()
    {
        p.imie = decipher(p.imie, klucz);
        p.nazwisko = decipher(p.nazwisko, klucz);
        p.stanowisko = decipher(p.stanowisko, klucz);
    }
    public static char cipher(char ch, int k)
    {
        if (!char.IsLetter(ch))
        {
            return ch;
        }
        char d = char.IsUpper(ch) ? 'A' : 'a';
        return (char)((((ch + k) - d) % 26) + d);
    }


    public static string encipher(string input, int k)
    {
        string output = string.Empty;
        foreach (char ch in input)
            output += cipher(ch, k);
        return output;
    }

    public static string decipher(string input, int k)
    {
        return encipher(input, 26 - k);
    }
    public bool isMatch(int nr)
    {
        if(nr == p.nr)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

static class Program
{
    static List<kartoteka> k = new List<kartoteka>();
    static void wczyt()
    {
        using (StreamReader r = new StreamReader("pliktxt.txt"))
        {
            do
            {
                string a = r.ReadLine();
                string b = r.ReadLine();
                string c = r.ReadLine();
                int d = int.Parse(r.ReadLine());
                int e = int.Parse(r.ReadLine());
                k.Add(new kartoteka(a, b, c, d, e));
            } while (!r.EndOfStream);
        }
    }
    static void Main()
    {
        
        k.Add(new kartoteka("janusz", "nowak", "kapitanat portu", 20, 1));
        k.Add(new kartoteka("jan", "nowak", "biuro", 26, 2));
         k[0].zapistxt();
         k[1].zapistxt();
         wczyt();
         k[2].poka();
         k[3].poka();
        k[0].encrypt();
        k[0].poka();
        k[0].decrypt();
        k[0].poka();
        k[0].validate();
        k[0].poka();
    }
}