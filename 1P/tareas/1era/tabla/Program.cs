WriteLine("---------------------------------------------------------------------------------"); // para que se va bonis
WriteLine($"{"Type", 0}{"Byte(s) of memory", 25}{"min", 20}{"MAX", 32}"); //Se va a usar interpolacion de cadenas, ya que no le entendi nd a lo del formato y los argumentos
WriteLine("---------------------------------------------------------------------------------");
WriteLine($"sbyte {sizeof(sbyte),10}{sbyte.MinValue, 33}{sbyte.MaxValue, 32}"); //cada numero son los espacios que se le van a asignar antes de la cadena de texto
WriteLine($"byte {sizeof(byte),11}{byte.MinValue, 33}{byte.MaxValue, 32}");// se separan por cadena ya que no se pueden hacer seguidos
WriteLine($"short {sizeof(short),10}{short.MinValue, 33}{short.MaxValue, 32}"); 
WriteLine($"ushort {sizeof(ushort),9}{ushort.MinValue, 33}{ushort.MaxValue, 32}");
WriteLine($"int {sizeof(int),12}{int.MinValue, 33}{int.MaxValue, 32}"); //En cada linea es distinto el formato ya que cada una tiene su longitud distinta de caracteres o numeros
WriteLine($"uint {sizeof(uint),11}{uint.MinValue, 33}{uint.MaxValue, 32}"); 
WriteLine($"long {sizeof(long),11}{long.MinValue, 33}{long.MaxValue, 32}");
WriteLine($"float {sizeof(float),10}{float.MinValue, 33}{float.MaxValue, 32}");
WriteLine($"double {sizeof(double),9}{double.MinValue, 33}{double.MaxValue, 32}");
WriteLine($"decimal {sizeof(decimal),9}{decimal.MinValue, 33}{decimal.MaxValue, 31}"); //el numero de espacios se dio a base de prueba y error
WriteLine("---------------------------------------------------------------------------------");
//es mejor hacerlo en funcion y con constantes para mejorar la disponibilidad de cambios