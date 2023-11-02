namespace CalculatorUnitTesting;
using calculatorlib;


public class CalculatorUnitTests
{
    [Fact] //annotation son verbos que les puedo poner a mis funciones 
    public void TestAdd2And2()
    {
        //arrange
        double a=2;
        double b=2;
        double expected=4;
        Calculator calc = new();
        // act
        double actual = calc.Add(a,b);
        //Assert
        Assert.Equal(expected,actual); //se corre con dotnet test
    }
    [Fact]
    public void TestAdd2And3()
    {
        //arrange
        double a=2;
        double b=3;
        double expected=5;
        Calculator calc = new();
        // act
        double actual = calc.Add(a,b);
        //Assert
        Assert.Equal(expected,actual); //se corre con dotnet test
    }
    //comienza la tarea desde aqui

    // IndexOutOfRangeException
    [Fact]
    public void TestDivOutOfIndex()
    {
        //arrange
        double[] a = new double[2];
        a[0] = 1;
        a[1] = 2;
        Calculator calc = new();
        // () sirve para decir que el metodo anonimo no recibe ningun argumento
        // es un tipo de método que no tiene un nombre explícito
        //Estos métodos se utilizan comúnmente para proporcionar una 
        //implementación de una función o acción que se pasará como argumento a otro método o función
        
        // => define el codigo quel cuerpo anonimo
        // El cuerpo de un método anónimo es el bloque de código que define las operaciones 
        // que el método realizará cuando se llame. 

        // act
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            a[3] = calc.Div(a[0],a[1]);  //el problema es cuando tratamos de asignarle un valor cuando el arreglo no abarca hasta esa posicion
        });    
    }

    // FormatException
    [Fact]
    public void TestDivStringToDouble()
    {
        //arrange
        String a="a";
        String b="b";
        Calculator calc = new();
        //Assert
        Assert.ThrowsAny<FormatException>(() =>
        {
            // act
            double actual = calc.Div(Double.Parse(a),Double.Parse(b)); //el tipo no corresponde con lo que espera recibir
        });
    }

    // [Fact]
    // public void TestDivCero()
    // {
    //     //arrange
    //     double a=10;
    //     double b=0;

    //     Calculator calc = new();
    //     try{
    //         double actual = calc.Div(a,b); 
    //     }catch(DivideByZeroException ex){
    //         Assert.Equal(ex.Message, "B cannot be 0"); // se compara el mensaje que hemos escrito con el que lanza
    //     }
    //     // //Assert
    //     // Assert.Throws<Exception>(() =>
    //     // {
    //     //     // act
    //     //     double actual = calc.Div(a,b);  
    //     // });
    // }

    //InvalidCastException
    [Fact]
    public void TestDivCast()
    {
        //arrange
        object a="a";
        double b=10;
        Calculator calc = new();
        //Assert
        Assert.ThrowsAny<InvalidCastException>(() =>
        {
            // act
            double actual = calc.Div((double)a,b);  //Es algo parecido al anterior, pero usando un casteo de un objeto a double
        });
    }

    //NullReferenceException
    [Fact]
    public void TestDivNullRef()
    {
        //arrange
        double b=1;
        string str = null;
        Calculator calc = new();
        //Assert
            Assert.ThrowsAny<NullReferenceException>(() =>
            {
                // act
                double actual = calc.Div(str.Length,b);  //al tratar de acceder a su longitud, es nula por la cual truena
            });
    }
}

//necesita 3 cosas
// arrange
// todo lo q uno necesita para correr la prueba ahi se debd de declarar
// ACT
// mandar a llamar lo que quiero probar
// Assert
// El assert valida lo que esperaba que saliera es lo que sale en realidad

// todas las practicas deben de tener unittesting
// y yo las tengo que escribir

//se debe de referenciar el proyecto al cual vamos a testear

//esta es una manera de debbugear
// una es pruebas unitarias 
// con breakpoints 
// docking platicarle a tu pato tu codigo
// protip despejarse y no buclearse

//practica 3
//usar este proyecto
//agregar una nueva funcion a calculator, una division
//Solo es necesario dividir correctamente
//se va a crear unitTesting para division
//va a tener que regresar exceptions
//if the number is very big
//if the division is by 0 etc etc
//at least 4 UT that return exceptions
//The teacher is going to wait an exception
//and make the code crash? brake? you understand
//--Equal works with exceptions?
//4 exceptions for divition and 4 for divition?