//COmo manejar las expeciones
// using static System.convert;
WriteLine("Before Parsing");
WriteLine("What is your age");
string? input = ReadLine();
try
{
    int age = int.Parse(input);
    WriteLine($"Your age is {age}");
}
catch (FormatException) //los errores pueden checarse en la documenacion
{
    WriteLine("Couldnt convert the input");
}
// catch (Exception ex)
// {
//     WriteLine($"{ex.GetType} says {ex.Message}");
// }
WriteLine("After parsing");

//la idea es que nunca truene la aplicacion
//

WriteLine("Enter an amount");
string amount = ReadLine();
if(string.IsNullOrEmpty(amount) ){
    return;} //hay muchos condiciones para filtrar los datos

    try{
        decimal amountValue = decimal.Parse(amount);
        WriteLine($"Amount formatted as currency {amount:C}");
    }catch (FormatException) when (amount.Contains("$")){;
        WriteLine("You cant use $ in the amount");
    }

int max = 300;
for(byte i=0; i<max; i++){
    WriteLine(i); //se queda bucleado infinitamente
}
// FizzBuzz //si el numero es divisible entre 3 imprime fizz
//y si es entre 5 buzz
// y si es entre ambos fizzBuzz

