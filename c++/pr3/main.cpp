#include <iostream>
#include <math.h>

using namespace std;

int funkcja(int & suma,int & iloczyn)
{
    suma=0;
    iloczyn=1;
    int a,i;
    do
    {
    cin>>a;
    i++;
    suma=suma+a;
    if(a!=0)
    iloczyn=iloczyn*a;
    }while(a!=0);
    return (i%2);

}
int main()
{
    int suma,iloczyn;
    funkcja(suma,iloczyn);
    cout<<suma<<" "<<iloczyn<<endl;
    return 0;
}
