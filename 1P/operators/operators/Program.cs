// operators
int a =3; //= asignacion
int b =4;
WriteLine($"a is {a} and b is {b}"); // es binario porque usa dos elementos


decimal c=11;
decimal d=3;
WriteLine($"c+d ={c+d}"); // es binario porque usa dos elementos
WriteLine($"c-d ={c-d}");
WriteLine($"c*d ={c*d}");
WriteLine($"c/d ={c/d}");
WriteLine($"c%d ={c%d}"); //residuo

//assignmet operators
int e=6;
 //sigue siendo binario
WriteLine($"e+={e+=3}");
WriteLine($"e-={e-=3}");
WriteLine($"e*={e*=3}");
WriteLine($"e/={e/=3}");

//boolean operators
bool f=true;
bool g=false;

WriteLine($"AND |f      |g");
WriteLine($"f   | {f&f,-5} | {f&g,-5}"); //&&
WriteLine($"g   | {g&f,-5} | {g&g,-5}");

WriteLine($"OR  |f      |g");
WriteLine($"f   | {f|f,-5} | {f|g,-5}"); //OR
WriteLine($"g   | {g|f,-5} | {g|g,-5}");

WriteLine($"XOR |f      |g");
WriteLine($"f   | {f^f,-5} | {f^g,-5}"); //XOR
WriteLine($"g   | {g^f,-5} | {g^g,-5}");


//Conditional operators

static bool DoStuff(){
    WriteLine("I am working . . . wink wink");
    return true;
}
WriteLine();
WriteLine($"f & DoStuff() = {f & DoStuff() }"); //retornan el valor del operador booleano
WriteLine($"g & DoStuff() = {g & DoStuff() }");

WriteLine($"f && DoStuff() = {f && DoStuff() }"); //la diferencia, la gerarquia
WriteLine($"g && DoStuff() = {g && DoStuff() }");
//todo lo que va dentro de algo complejo, aunque sea las llaves, es una {expresion}
//lo que ls diferencia es que se evalya, el && condicional primero se evalua que es correcto
//Lo que hace el compilador primero ejecuta el DoStuff
//pero dentro de una expersion es una variable y lo que imprime es temporal
//la condicional le gana a todo x gerarquia
//Con que sea evaluado en una expresion vale para poder usar el condicional

//Miscellaneous
int age =50; //muy pocas veces se ven
char firstDigit = age.ToString()[0];
// . is the member access operator
// = is the assignment operator
// [] in the index access operator
// () is the invocation operator

//siempre pedir pistas, hasta 2, y tratar de deducir algo, si no es, preguntar que se buscaba
//Anagrama: una palabra que se puede armar con las mismas letras
//rat = art


