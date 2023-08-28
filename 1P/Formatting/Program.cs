using static System.Console; //con tabulador se completa

//margins
// {index[,alignment] [:FormatString]}

string pearText = "Pear";
int pearCount = 12345;
string pricklyPearText = "Prickly Pear";
int pricklyPearCount = 450000;

//HEADERS
//todo margen se genera en el eje X, negativo izq, pos der
WriteLine(
    format: "{0,-10} {1, 8}",
    arg0: "Name",
    arg1: "Count"
);

//1rt row
WriteLine(
    format: "{0,-10} {1, 9:N0}", /**/
    arg0: pearText,
    arg1: pearCount /*La coma cuenta como espacio*/
);
//2nd row
WriteLine(
    format: "{0,-12} {1, 8:N0}",
    arg0: pricklyPearText,
    arg1: pricklyPearCount
);

//No le crean al pinche usuario 

Write("TYpe yout first name and press ENTER ");
String firstname = ReadLine();
Write("Type your age and press ENTER: ");
String age = ReadLine();
Write($"Hello {firstname} you look good for {age}");

//sigueinte clase, error handlyng

