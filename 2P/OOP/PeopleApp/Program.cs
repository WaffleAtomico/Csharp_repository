using PA17F.Shared; //si
using static PA17F.Shared.Person; //DelegateWithMatchingSignature para que lo tope
using System.Collections.Generic;
using System.Collections;
using System.Formats.Asn1;


Person wachi = new();
WriteLine($"Wachi is: {wachi.ToString()}");

wachi.Name = "Albert";
wachi.DateOfBirth = new DateTime(2002, 12, 22);
WriteLine(format: "{0} was born on {1:dddd, d MMMM yyyy}",
 arg0: wachi.Name,
arg1: wachi.DateOfBirth);

//hashtable ->
    //1. Cannot duplicate keys
    //2. All keys must be the same type

    // Hashtable lookupObject =new();
    // lookupObject.add(key:1, value: "Alpha");

    //tupla: datos compuestos, 2 datos separados esperados
    
    Dictionary<int, string>lookupIntString = new();
    lookupIntString.Add(key:1, value: "Alpha");
    lookupIntString.Add(key:2, value: "Beta");
    lookupIntString.Add(key:3, value: "Gamma");
    lookupIntString.Add(key:4, value: "Tetha");

    //Getting values from dictionary
    foreach (var key in lookupIntString.Keys)
    {
       WriteLine($"key: {key} has value of : {lookupIntString[key]}"); //This is how you can access to the values
       //the dictionarys can have 2 of more keys
       //the hash tables cannot
    }

//Si en una hash table se repite un valor, lanza una excepcion
//se puede hacer una try catch para evitar que truene el programa
//por ende, puedes saber si tienes un valor duplicado sin que caiga el programa

//DELEGADO: mandar a llamar una funcion como una variable
//se puede crear una funcion que pueda ser llamado como una variable?????????????? WTF
//CallMethod()
//public string CallMethod(int id) //la 1era cosa que va a revisar un delegado va a ser la firma de legado

//Firma de legado
//Tipo de retorno y parametros que recibe

Person Jordi = new();
int answer =Jordi.MethodIWantToCall("Alfred");
//alterminativamente puedo crear und elegado 
//que haga match con la fimra del metodo que voy a mandar a llamar
//Sirve para crearle una variable que mande a llamar una funcion sin tener que escribir toda la funcion
WriteLine(answer);
DelegateWithMatchingSignature d = new(Jordi.MethodIWantToCall);
//se crea una instancia del delegado
int answer2 = d("Isaac");
WriteLine(answer2);


//Un envento es un trigger

Jordi.Shout = Jordi_Shout; //le pasas la funcion que quieres usar y lo busca por la fimra
// wachi.Shout = Jordi_Shout;
//
Jordi.Poke(); //1
Jordi.Poke(); //2
Jordi.Poke(); //3
Jordi.Poke(); //4
Jordi.Poke(); //5     