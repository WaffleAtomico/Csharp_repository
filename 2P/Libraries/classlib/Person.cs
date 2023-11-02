namespace PA17F.Shared; //se va a usar en mas proyects
using System.Collections.Generic;
using System.Collections;
using System.Xml.Serialization; //[XMLAttributes]
public class Person
{

    public Person(){
    }
    public Person(decimal initialSalary){
        Salary = initialSalary;
    }
    //members
    //constant, read - onlys eventes
    /*Constant : Once declared and
    asigned, cannot be changed event in runtime

    read-Only : Similiar to a constant
    but you can change the calue on runtime
    using constructor

    Event: References to another method
    Usually used on buttons, actions things like that

    Methods: == Functions, Execute statements
    Constructor : Is using when is Executed when the NEW, allocate memory
    Property : 
    member -> int number = 0;
    public setNumber (int number) {this.nomber = number; }
    public void get Number () {return this.number; }
    string Name {get; set;} getters and setters
    
    Indexers: []
    Operators : + - => * / &6   
    
    */

    //members
    [XmlAttribute("fname")]
    public string? Name {get; set;}
    [XmlAttribute("lname")] //cambiarle el nombre
    public string? lastname { get; set; }
    [XmlAttribute("dob")]
    public DateTime DateOfBirth;
    //     //Data Field for deleagate
    public int AngerLevel;
    public decimal Salary { get; set; } //prop
     public HashSet<Person> Children { get; set; }  
    //HashSet contiene un conjunto de objetos,
    // pero de una manera que le permite determinar fácil 
    //y rápidamente si un objeto ya está en el conjunto o no.


     //Existen 2 tipos de propiedades
     //

//     //Delegates
    //public EventHandler? Shout;

//     public int MethodIWantToCall(string input)
//     {
//         return input.Length; //input.Leght
//     }

//     public delegate int DelegateWithMatchingSignature(string s);
//     //no es funcion, es la declaracion de la firma
//     //yo quiero que la funcion tenga los mismos parametros de recibir  y entregar
//     //es como un puntero hacia una funcion
    

//  //1st Step, Event Handler
//     //es como un listener, es un wey que se encarga de escuchar a cada rato

//     public delegate void Eventhandler(object? sender, EventArgs e); 
//         //delegated field
//     // public EventHandler? Shout;
//     //     //Data Field for deleagate
//     // public int AngerLevel;

//         public void Poke() //
//         {
//             AngerLevel++;
//             if(AngerLevel >=3){ //Only when is higher than 3 will activate
//                 //if somethinng is listening
//                 if(Shout != null){
//                     //then call the delegate
//                     Shout(this,EventArgs.Empty); //sin instancia se crea la variable tipo delegado
//                 }
//             }
//         }
    


}

    //generic types
    //list, hash, dictionary, <T>, <Tkey> <Tvalue> this means that is a class with a type
    //in all the conections in C#


    

    //minimo 5 pruebas unitarias en todas las practicas
