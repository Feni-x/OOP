#include<iostream>;
#include<Math.h>
using namespace std;
class TVector2D
{
protected:
    double x;
    double y;

public:
    TVector2D(double x, double y)
    {
        this->x =  x;
        this->y =  y;
    }
    TVector2D()
    {
        x = 0;
        y = 0;
    }

    TVector2D(const TVector2D &vector)
    {
        x = vector.x;
        y = vector.y;
    }

    virtual void input()
    {
        cout<<"Please, enter x"<<endl;
        cin >> x;
        cout<<"Please, enter y"<<endl;
        cin >> y;
    }

    void virtual print()
    {
       cout<<x << "; " << y << " ";
    }

    double virtual length()
    {
        return (sqrt(x * x + y * y));
    }

    void virtual normalize()
    {
        double lenght = this->length();
        x = x / lenght ;
        y = y / lenght;

    }
    //ToDo чи треба додавати протилежність?
    bool equals(TVector2D vector)
    {
        return x == vector.x && y == vector.y;
    }

     TVector2D operator + (const TVector2D vector2)
    {
        return TVector2D(this->x + vector2.x, this->y + vector2.y);
    }
     TVector2D operator -(const TVector2D vector2)
    {
        return TVector2D(this->x - vector2.x, this->x - vector2.y);
    }
     double operator *(const TVector2D vector2)
    {
        return (this->x * vector2.x + this->x * vector2.y);
    }

};