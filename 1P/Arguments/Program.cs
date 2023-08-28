
    //String args
WriteLine($"There are {args.Length} arguments."); //existe args, solo que no lo vemos
WriteLine("Oli");


//dotnet run firstarg secondarg thrird:arg "fourth arg"
//de aqui en adelante se corre el codigo con esta linea en la terminal

//Al correrlo con este le estas dando argumentos

foreach (var argument in args)
{
    WriteLine(argument);
}
//var desaloja la memoria al dejar de usarla

#region Infer Types
    //object
        object number = 13;
        WriteLine(number.GetType()); //dira system.int32
        //Pros: ahorra memoria, maneja mejor memoria, y bueno para transferir datos
        //Contras: Mas complicado
        number.Equals(1); 
        String name = "Nebai";
        name.Max(); //para dar un ejemplo, tiene muchos mas metodos que objetos

        //Los pros de object tiene muchisimos mas pros de lo que las contras representan

    //dynamic
        dynamic decimalNumber = 45.8;
        WriteLine(decimalNumber.GetType());
        //pros: Puedes usar las propiedades de tipo
        //Contra: No desaloja memoria

    //var
        var array=new int [1,2,3,4];
        //pros: inherit methods and properties
        //libera ram
        //Se recomienda usar var cuando no se sabe que le va a llegar
        WriteLine(array.GetType());
#endregion
//var es una variable sin tipo
//tipo inferido se llama

//dotnet run red yellow 50

if(args.Length <3){
    WriteLine("You must specify two colors and cursor size");
    WriteLine("dotnet run red yellow 50");
    return; //es para salir del ir Stop running
            //las reglas de ambito se determinan por las {} ambit scope
}
//1rt color
ForegroundColor = (ConsoleColor)Enum.Parse(
    enumType: typeof(ConsoleColor),
    value: args[0],
    ignoreCase: true //para que no se confunda de color
); 

//2do color
BackgroundColor = (ConsoleColor)Enum.Parse(
    enumType: typeof(ConsoleColor),
    value: args[1],
    ignoreCase: true
); 
try //son para evitar errores
{
CursorSize = int.Parse(args[2]);
    
}
catch (System.Exception) //exepciones, son errores que suceden en running time
{
    
    WriteLine("The current platform does not support the change in cursor size");
}
