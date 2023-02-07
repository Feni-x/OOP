#include"TVector2D.cpp"
#include"math.h"
class TVector3D : public TVector2D
{
protected:
    double z;
public:
    TVector3D(double x, double y, double z) :TVector2D(x, y)
    {
        
        this->z = z;
    }
    TVector3D() :TVector2D()
    {
        this->z = 0;
    }

    TVector3D(const TVector3D& vector)
    {
        this->x = vector.x;
        this->y = vector.y;
        this->z = vector.z;
    }

    void input() override
    {
        this->TVector2D::input();
        cout << "Please, enter z" << endl;
        cin >> z;
    }

    void print() override
    {
        this->TVector2D::print();
        cout << "; " << z << " )" << endl;
    }

    double length() override
    {
        return sqrt(this->TVector2D::length() * this->TVector2D::length() + z * z);
    }
    void normalize() override
    {
        
        double length = this->length();       
        this->TVector2D::normalize();
        z =  length;
        
    }
    bool equals(TVector3D vector)
    {
        return this->x == vector.x && this->y == vector.y && this->z == vector.z;
    }
    TVector3D operator +(const TVector3D vector2)
    {
        return TVector3D(this->x + vector2.x, this->y + vector2.y, this->z + vector2.z);
    }
    TVector3D operator -(const TVector3D vector2)
    {
        return  TVector3D(this->x - vector2.x, this->y - vector2.y, this->z - vector2.z);
    }
    double operator *(const TVector3D vector2)
    {
        return (this->x * vector2.x + this->y * vector2.y + this->z * vector2.z);
    }


};
