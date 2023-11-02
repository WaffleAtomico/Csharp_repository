using static System.IO.Directory; // CRUD directories
using static System.IO.Path; // create URL's
using _1eraArch.Checkpalin;

internal class Program
{
    private static void Main(string[] args)
    {
        string PathToUpload =        @"C:\Users\penil\Desktop\3.txt";

        //  @"C:\Users\penil\Desktop\2.txt";
        // @"C:\Users\penil\Desktop\1.txt";
        

        //  @"C:\Users\penil\OneDrive\Escritorio\CETI\PROGRAMACION\Avanzada\Git\2P\tareas\1eraArch\1eraArch\Text\LoreIpsum.txt";
        // 

        // @"C:\Users\penil\Desktop\vacio.txt";
        // @"C:\Windows\System32\WerFaultSecure.exe";

        //!1 
        //!2 @"C:\Users\penil\VirtualBox VMs\W81_PRO64Bits_Penil\W81_PRO64Bits_Penil.txt"; //toolong
        //!3 @"C:\Users\penil\Desktop\NoExisto\PruebaCaracteres.txt"; //file not found
        //!4 @"C:\Users\penil\OneDrive\Escritorio\CETI\OTROS\Horario de clases CETI .xlsx"; //IO
        //!5 string fileExtension = System.IO.Path.GetExtension(PathToUpload).ToLower();

        // if(fileExtension == ".exe"){
        //     throw new Exception("Wrong FileType");
        // }
        //6 
        //!7 ""; //
        //!8 null; //null
        //!9  @"C:\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a\a.txt"; //not found
        //10 

            string textToUpload = File.ReadAllText(PathToUpload); //to read the text in the path of the archive
            string newFolderHW = Combine(GetCurrentDirectory(), "Text");
            CreateDirectory(newFolderHW);

            //create the txt archive
            string textFile = Combine(newFolderHW, "RecibedText.txt");
            string backUpFile = Combine(newFolderHW, "BackRT.bak");
            //create the file
            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine(textToUpload);
            textWriter.Close();
            if (Path.Exists(backUpFile))
            { // if exist the backUpFile we destroy it PLUMP, cause, it gave me a error when i tryed to make another
                File.Delete(backUpFile);
            }
            File.Copy(sourceFileName: textFile, destFileName: backUpFile); //File is a class
            StreamReader textReader = File.OpenText(backUpFile);
            // StreamReader textReader =  new StreamReader(backUpFile, System.Text.Encoding.ASCII, false);
            WriteLine("Text in the archive");
            int pos = 0; //this is to know in witch part of the document are we
            int[] vocals = new int[5];
            int[] posvocals = new int[5]; //is to know the position on the vocal where we are going to replace for the number
            //0=a 1=e 2=i 3=o 4=u
            sbyte carac = 0;
            string pal = ""; //this is to keep the current word
            string maxpali = ""; //this is to keep the longest palindrome
            while (carac != -1)
            {
                carac = (sbyte)textReader.Read();
                pal += (char)carac; //agregate el word everytime we start
                if (carac == 65 || carac == 97 ) { vocals[0]++; posvocals[0] = pos; } //Aa
                if (carac == 69 || carac == 101) { vocals[1]++; posvocals[1] = pos; } //Ee
                if (carac == 73 || carac == 105) { vocals[2]++; posvocals[2] = pos; } //Ii
                if (carac == 79 || carac == 111) { vocals[3]++; posvocals[3] = pos; } //Oo
                if (carac == 85 || carac == 117) { vocals[4]++; posvocals[4] = pos; } //Uu

                if (carac == 32)
                {
                    Write(" ");
                    //start funcion ispal()
                    pal = pal.Trim(); //to ignore the fkn spaces >:c
                    if (pal.Length > maxpali.Length)
                    { //for not call the fuction everytime we have a new word and is shorter than the one we're looking for
                        if (pal.Length >= 2)
                        { //cause a palindrome is a word, not a conector, not a, or i, or b
                            Ispal palchecker = new();
                            string tmp = palchecker.ispalindromo(pal);
                            if (tmp.Length > maxpali.Length)
                            {
                                maxpali = tmp;//if is bigger the string returned, we'll switch
                            }
                            pal = ""; //reload the word to write antoher 
                        }
                    }
                }
                else
                {
                    Write((char)carac);
                }
                pos++;
            }
            textReader.Close();
            WriteLine("");
            //WriteLine(textReader.ReadToEnd()); //sabe cuando termina cuando el puntero "endoffile" = .eof
            WriteLine($"There are: {pos - 1} positions on the file ");

            //0=a 1=e 2=i 3=o 4=u
            WriteLine($"a = {vocals[0]} lastposition = {posvocals[0]}");
            WriteLine($"e = {vocals[1]} lastposition = {posvocals[1]}");
            WriteLine($"i = {vocals[2]} lastposition = {posvocals[2]}");
            WriteLine($"o = {vocals[3]} lastposition = {posvocals[3]}");
            WriteLine($"u = {vocals[4]} lastposition = {posvocals[4]}");
            WriteLine("");
            if (maxpali == "")
            {
                WriteLine("There are not any palindrome in the text");
            }
            else
            {
                WriteLine("Biggest palindrome: " + maxpali);
            }
            string filePath = Combine(newFolderHW, "RecibedText.txt");
            StreamWriter newtextWriter = File.CreateText(filePath);
            for (int i = 0; i <= textToUpload.Length - 1; i++)
            {
                bool charswitched = false;
                for (int a = 0; a <= 4; a++)
                { //to check every vocal that we have in the arrange
                    if (i == posvocals[a] && posvocals[a] != 0 && vocals[a] != 0)
                    { //for 
                        newtextWriter.Write("" + vocals[a]); //if enters will write the number and follow with the caracters
                        charswitched = true;
                        break;//we dont need to seach for more numbers in this position
                    }
                }
                if (charswitched == false)
                {
                    newtextWriter.Write(textToUpload[i]); //write the text
                }
            }
            newtextWriter.WriteLine("");
            if (maxpali == "")
            {
                newtextWriter.Write("There are not any palindrome in the text");
            }
            else
            {
                newtextWriter.Write("Biggest palindrome: " + maxpali);
            }
            newtextWriter.Close();
            // return "Archive updated";
    }
    
}
//else{
//     //WriteLine("Archive didnt found, is the path ok?");
//     return "Archive didnt found, is the path ok?";
// }
// }

// }



// Lorem Ipsum is simply dummy text of the 
// printing and typesetting industry. Lorem Ipsum has been the industry's
// standard dummy text ever since the 1500s, when an unknown printer took
// a galley of type and scrambled it to make a type specimen book.

//values of vocals
//A = 65 a = 97
//E = 69 e = 101
//I = 73 i = 105
//O = 79 o = 111
//U = 85 u = 117



//cuando llegue a la posicion de la ultima, o mas bn, la ultima registrada
//a la hora de escribir en el documento de nuevo, ya que ya lo encontro
//se tiene que esperar a que llegue a la posicion exacta en donde esta y poner el nuevo numero
//y seguir con cada letra

//posible problema: Que mueva tooodo el texto poner un nuevo caracter por ende la 
//letra termina x hacerse kk en la posicion
//Act: No lo hace