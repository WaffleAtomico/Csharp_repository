Byte[] b = new Byte[128]; //hacemos el arreglo de bytes
Random.Shared.NextBytes(b); //le asignamos valores aleatorios
WriteLine("Binary Object as bytes:");
foreach (var item in b)
{
    Write($"{item.ToString("X2")} "); //X2 para indicar que es en hexa y con 2 caracteres
}
Write("\nBinary Object as Base64: ");
Write($"{System.Convert.ToBase64String(b)}"); //convertimos todo el arreglo a base 64 y mostramos

// foreach (var item in b)
// {
//     Write($"{item.ToString("X2")} "); //X2 para indicar que es en hexa y con 2 caracteres
// }


// Write($"{System.Convert.ToHexString(b)} "); // No agrega los espacios pedidos en la tarea


//formato haciendo el pase del arreglo sin espacios, mas corto pero no lo comprendo bien

// string hexString = System.Convert.ToHexString(b);
// string formattedHexString = string.Join(" ", Enumerable.Range(0, hexString.Length / 2).Select(i => hexString.Substring(i * 2, 2)));
// Write($"{formattedHexString} "); // Agrega espacios entre los valores hexadecimales