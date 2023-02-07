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
        this->x = x;
        this->y = y;
    }
    TVector2D()
    {
        x = 0;
        y = 0;
    }

    TVector2D(const TVector2D& vector)
    {
        x = vector.x;
        y = vector.y;
    }

    virtual void input()
    {
        cout << "Please, enter x" << endl;
        cin >> x;
        cout << "Please, enter y" << endl;
        cin >> y;
    }

    void virtual print() 
    {
        cout << x << "; " << y << " ";
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
         cout << "; " << z << endl;
     }

     double length() override
     {
         return sqrt(this->TVector2D::length() * this->TVector2D::length() + z * z);
     }
     void normalize() override
     {
         double length = this->length();
         this->TVector2D::normalize();
         z = z / length;
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
//#include <iostream>
//#include"TVector2D.cpp"
//#include"TVector3D.cpp"
//using namespace std;
 static void printMenu()
{
    cout<<"\nPlease, choose action\n0. Exit\n1. Empty constuctor\n2. Constructor with parameters\n3. Copy constuctor" <<
        "\n4. Input object\n5. Print object\n6.Print coppied object\n7. Length\n8.Normalize\n9.Compare to coppied" <<
        "\n10. Addition\n11. Subtraction\n12. Multiplication"<<endl;
}
int main()
{
    cout<<"Choose dimension"<<endl;
    int choice;
    cin >> choice;
    TVector2D v21;
    TVector2D v22;
    TVector3D v31;
    TVector3D v32;
    switch (choice)
    {
    case 2:
        while (choice != 0)
        {
            printMenu();
            cin>> choice;
            switch (choice)
            {
            case 0: break;
            case 1:
                v21 = *new TVector2D();
                cout<<"First vector" << endl;
                v21.print();
                break;
            case 2:
                cout << "Please enter x and y" << endl;
                int x, y;
                cin >> x >> y;
                v21 = *new TVector2D(x,y);
                cout << "First vector" << endl;
                v21.print();
                break;
            case 3:
                cout<<"Coppied vector" << endl;
                v22 = *new TVector2D(v21);
                v22.print();
                break;
            case 4:
                v21.input();
                cout<<"First vector" << endl;
                v21.print();
                break;
            case 5:
                cout << "First vector" << endl;
                v21.print();
                break;
            case 6:
                cout << "Coppied vector"<<endl;
                v22.print();
                break;
           case 7:
                cout<<"Length" << endl << v21.length() << endl;
                break;
            case 8:
                cout << "Normalized first vector"<<endl;
                v21.normalize();
                v21.print();
                break;
            case 9:
                
                cout << "Are first and second vectors same?" << endl
                   <<v21.equals(v22)<<endl;
                break;
            case 10:
                cout << "first vector + second" << endl;
                v22 = v21 + v22;
                v22.print();
                break;
            case 11:
                cout << "first vector - second" << endl;
                v22 = v21 - v22;
                v22.print();
                break;
            case 12:
                cout << "scalar multiplication" << endl;
                cout<<v21 * v22<<endl;
                break;


            }
        }
        break;
    case 3:
        while (choice != 0)
        {
            printMenu();
            cin >> choice;
            switch (choice)
            {
            case 0: break;
            case 1:
                v31 = *new TVector3D();
                cout << "First vector" << endl;
                v31.print();
                break;
            case 2:
                cout << "Please enter x, y and z" << endl;
                int x, y, z;
                cin >> x >> y>>z;
                v31 = *new TVector3D(x, y,z);
                cout << "First vector" << endl;
                v31.print();
                break;
            case 3:
                cout << "Coppied vector" << endl;
                v32 = *new TVector3D(v31);
                v32.print();
                break;
            case 4:
                v31.input();
                cout << "First vector" << endl;
                v31.print();
                break;
            case 5:
                cout << "First vector" << endl;
                v31.print();
                break;
            case 6:
                cout << "Coppied vector" << endl;
                v32.print();
                break;
            case 7:
                cout << "Length" << endl << v31.length() << endl;
                break;
            case 8:
                cout << "Normalized first vector" << endl;
                v31.normalize();
                v31.print();
                break;
            case 9:

                cout << "Are first and second vectors same?" << endl
                    << v31.equals(v32) << endl;
                break;
            case 10:
                cout << "first vector + second" << endl;
                v32 = v31 + v32;
                v32.print();
                break;
            case 11:
                cout << "first vector - second" << endl;
                v32 = v31 - v32;
                v32.print();
                break;
            case 12:
                cout << "scalar multiplication" << endl;
                cout << v31 * v32 << endl;
                break;


            }
        }
        break;
    }
}



