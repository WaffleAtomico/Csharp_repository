WriteLine("Inserta cuantos numeros aleatorios quiere poner");
string? input = ReadLine();
    int i = int.Parse(input);
    Byte[] ranum = new Byte[i]; //hacemos el arreglo de bytes
    Random.Shared.NextBytes(ranum); //le asignamos valores aleatorios
String F = "Fizz"; //almacenamos los textos en variables para cambios mas rapidos y faciles
String B = "Buzz";
foreach (var item in ranum)
{
    if(item%3 == 0 && item%5 == 0){ //al principio ya que quiero que detecte si son los dos
        WriteLine(F+B);
    }else if(item%5 == 0)
    {
        WriteLine(B);
    }else if(item%3 == 0 )
    {
        WriteLine(F);
    }
}