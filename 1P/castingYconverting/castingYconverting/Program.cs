using static System.Convert;
// 2 types of conversion
//implicita
//explicita
#region Implicit Convertion
int a = 10;
double b = a;
WriteLine($"b is double and is {b}");
#endregion

#region Explicit Convertion
 double c =9.8;
 int d = (int)c; //siempre debe de ir a la izquierda la variable que quiero convertir
 WriteLine($"d is int and is {d}");
 //en los casteos explicitos puede haber perdida de memoria

 long e =10;
 int f = (int)e;
 WriteLine($"e is {e:N0} and f is {f:N0}");
 e = long.MaxValue;
 f = (int)e;
 WriteLine($"e is {e:N0} and f is {f:N0}"); //regresa un -1 ya que es el valor maximo y no truena pq prefiere mandar un -1
 e= 5_000_000_000_000;
 f = (int)e;
 WriteLine($"e is {e:N0} and f is {f:N0}"); 
 //en un numero de 64 bits no entra en uno de 32 por ende pone algo "Achicado"
 

#endregion

#region using Convert Class
    double g = 9.8;
    int h = ToInt32(g);
    WriteLine($"g is {g} and h is {h}"); //convert redondea
#endregion
#region tostring
    int number =12;
    WriteLine(number.ToString());
    //esta funcion se puede sobrecargar y puedes crear el propio ToString
    bool boolean = true;
    WriteLine(boolean.ToString());
    DateTime now = DateTime.Now;
    WriteLine(now.ToString());
    string name = "Nebai";
    WriteLine(name.ToString());
    object something = new();
    WriteLine(something.ToString());
#endregion

// 1era practica
// crear una tabla de datos que este formateada tanto a la izquierda como a la derecha
// el usuario no mete nd
// menos de 20 lineas

// 2do
// una conversion de un arreglo de bytes a strings
// presentar en hexa, convertir a string de como quedo
// no numero de lineas, sale como en 10 o menos

// 3ero
