namespace calculatorlib;
// para crear
//dotnet new classlib
//para crear la unidad dotnet new xunit
public class Calculator
{
    public double Add(double a, double b)
    {
        return a+b;
    }
    public double Div(double a, double b)
    {
        // if(b==0){
        //     throw new DivideByZeroException("B cannot be 0");
        // }
        return a/b;
    }
}

//desing pattern: single responsability es un patron de diseno
// y pertenece a algo llamado SOLID
//S = single responsability

//Unit testing: codigo que prueba codigo
// Aunque uno no lo haga, se necesita probar
// Y se tiene que tomar pruebas
// ponerlo en las... cosas de gantz
// el circulo de Deming
// Es un circulo para mejorar continuamente, al aplicarse para programacion
// Plan -> code dev -> test -> error handler -> Plan
// un buen plan es mejor modulado
// si en una parte ya no hay error ya ni le muevas
// si no se hace bien en una suma ni se imagne en un programa grande 
// las correcciones cuestan dinero porque es tiempo
// el tiempo es oro

// es inficiente y tardado ese metodo

// TDD Test driven development
// "Voy a escribir mis pruebas y mi codigo va a tener que escribirse para que pase esas pruebas"
// primero se escriben las pruebas y el codigo se escribe entorno a
// RED PHASE = Escribir las pruebas, todo esta en rojo ->
// GREEN PHASE = donde se escribe el codigo ->
// 
// 
// Se aprende con la practica
// Se llama unit testing
// QA QUALITY ASSURARCE AKA TESTERS
// AUTOMATION TESTING (Comenzar en este)
// MANUAL TESTING
// Uno que conoce de ambos, $$$$$$$$

//Se prueba unitariamente Unit testing
// y si las funciones hacen 5000 cosas, no va a jalar