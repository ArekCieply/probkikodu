#include <iostream>
#include <math.h>

using namespace std;

class figura
{
    public:
    virtual double pole()=0;
};
class kwadrat : public virtual figura
{
private:
    double a;
public:
    kwadrat()
    {
        seta(1.0);
    }
    kwadrat(double a)
    {
        seta(a);
    }
    double pole()
    {
        return a*a;
    }
    void seta(double a)
    {
        this->a=a;
    }
    double geta()
    {
        return a;
    }
};
class prostokat : public virtual figura
{
private:
    double a;
    double b;
public:
    prostokat()
    {
        seta(1.0);
        setb(1.0);
    }
    prostokat(double a,double b)
    {
        seta(a);
        setb(b);
    }
    double pole()
    {
        return a*b;
    }
    void seta(double a)
    {
        this->a=a;
    }
    double geta()
    {
        return a;
    }
    void setb(double b)
    {
        this->b=b;
    }
    double getb()
    {
        return b;
    }
};
class kolo : public virtual figura
{
private:
    double r;
public:
    kolo()
    {
        setr(1.0);
    }
    kolo(double r)
    {
        setr(r);
    }
    double pole()
    {
        return (r*r)*M_PI;
    }
    void setr(double r)
    {
        this->r=r;
    }
    double getr()
    {
        return r;
    }
};
class trapez : public virtual figura
{
private:
    double a;
    double b;
    double h;
public:
    trapez()
    {
        seta(1.0);
        setb(1.0);
        seth(1.0);
    }
    trapez(double a,double b,double h)
    {
        seta(a);
        setb(b);
        seth(h);
    }
    double pole()
    {
        return ((a+b)*h)/2.0;
    }
    void seta(double a)
    {
        this->a=a;
    }
    double geta()
    {
        return a;
    }
    void setb(double b)
    {
        this->b=b;
    }
    double getb()
    {
        return b;
    }
    void seth(double h)
    {
        this->h=h;
    }
    double geth()
    {
        return h;
    }
};
class szescian : public kwadrat//,  public  figura
{
private:
    double a;
public:
    szescian(double a)
    {
        seta(a);
    }
    double pole()
    {
        kwadrat k(a);
        return 6*k.pole();
    }
    void seta(double a)
    {
        this->a=a;
    }
    double geta()
    {
        return a;
    }
};
class prostopadloscian : public kwadrat, public prostokat//, public  figura
{
    private:
        double a;
        double b;
public:
    double pole()
    {
        kwadrat k(a);
        prostokat p(b,a);
        return 2*k.pole()+4*p.pole();
    }
    void seta(double a)
    {
        this->a=a;
    }
    double geta()
    {
        return a;
    }
    void setb(double b)
    {
        this->b=b;
    }
    double getb()
    {
        return b;
    }
};
class kula : public kolo
{
public:
    pole(double r)
    {
        kolo k(r);
        return 4*k.pole();
    }
};
class graniastoslup : public trapez, public prostokat//, public  figura
{
private:
    double a;
    double b;
    double h;
    double c;
public:
   double pole()
    {
        int d;
        d=abs(a-b)*abs(a-b)+h*h;
        d=sqrt(d);
        trapez t(a,b,h);
        prostokat k1(a,c);
        prostokat k2(b,c);
        prostokat k3(c,d);
        return 2*t.pole()+k1.pole()+k2.pole()+2*k3.pole();
    }
    void seta(double a)
    {
        this->a=a;
    }
    double geta()
    {
        return a;
    }
    void setb(double b)
    {
        this->b=b;
    }
    double getb()
    {
        return b;
    }
    void seth(double h)
    {
        this->h=h;
    }
    double geth()
    {
        return h;
    }
    void setc(double c)
    {
        this->c=c;
    }
    double getc()
    {
        return c;
    }
};
int main()
{
    figura *f[3];
    kwadrat *k;
    k=new kwadrat(6.0);
    prostokat *p;
    p=new prostokat(6.0,7.0);
    szescian *s;
    s=new szescian(8.0);
    f[0]=k;
    f[1]=p;
    f[2]=s;
    for(int i=0;i<3;i++)
    cout<<f[i]->pole()<<endl;

    return 0;
}
