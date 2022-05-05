#include <iostream>

using namespace std;

class przedmiot
{
private:
    double * oceny;
    int nr_indeksu;
    int liczba_ocen;
    int limit_ocen;
public:
    przedmiot(int nr_indeksu,int limit_ocen)
    {
        double *oceny=new double[limit_ocen];
        this->oceny=oceny;
        setliczba_ocen(0);
        setlimit_ocen(limit_ocen);
        setnr_indeksu(nr_indeksu);
    }
    double obliczSrednia()
    {
        double suma=0.0;
        for(int i=0; i<getliczba_ocen(); i++)
        {
            suma=suma+getoceny(i);
        }
        return suma/getliczba_ocen();
    }
    bool zaliczenie()
    {
        if(obliczSrednia()<3.0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    void dodajOcene(double ocena)
    {
        setoceny(ocena,getliczba_ocen());
        setliczba_ocen(getliczba_ocen()+1);
    }
    void zmienOcene(double ocena, int i)
    {
        setoceny(ocena,i);
    }
    void pisz()
    {
        cout<<getnr_indeksu()<<"oceny"<<endl;
        for(int i=0; i<getliczba_ocen(); i++)
        {
            cout<<getoceny(i)<<endl;
        }
        if(zaliczenie()==true)
        {
            cout<<"tak";
        }
        else
        {
            cout<<"nie";
        }
    }
    void setlimit_ocen(int limit_ocen)
    {
        this->limit_ocen=limit_ocen;
    }
    int getlimit_ocen()
    {
        return limit_ocen;
    }
    void setliczba_ocen(int liczba_ocen)
    {
        this->liczba_ocen=liczba_ocen;
    }
    int getliczba_ocen()
    {
        return liczba_ocen;
    }
    void setnr_indeksu(int nr_indeksu)
    {
        this->nr_indeksu=nr_indeksu;
    }
    int getnr_indeksu()
    {
        return nr_indeksu;
    }
    void setoceny(double oceny,int i)
    {
        this->oceny[i]=oceny;
    }
    double getoceny(int i)
    {
        return oceny[i];
    }
};
int main()
{
przedmiot p(12345,3);
p.dodajOcene(3.5);
p.dodajOcene(4.0);
p.pisz();
    return 0;
}
