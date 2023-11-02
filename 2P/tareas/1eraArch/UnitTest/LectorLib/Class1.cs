namespace LectorLib;
using static System.IO.Directory; // CRUD directories
using static System.IO.Path; // create URL's
using LectorLib.Checkpalin;
using LectorLib.EditText;

public class Arch
{
    public string TextPalin(string PathToUpload)
    {       /*Variables and arrays*/
            sbyte carac = 0; //sbyte for all the chars and keep the ascii in the variable
            int pos = 0; //this is to know in witch part of the document are we
            int[] vocals = new int[5]; //count the vocals
            int[] posvocals = new int[5]; //is to know the position on the vocal where we are going to replace for the number
            //0=a 1=e 2=i 3=o 4=u
            string pal = ""; //this is to keep the current word
            string maxpali = ""; //this is to keep the longest palindrome
            
            string textToUpload = File.ReadAllText(PathToUpload); //to read the text in the path of the archive
            string newFolderHW = Combine(GetCurrentDirectory(), "Text");
            CreateDirectory(newFolderHW);
            string textFile = Combine(newFolderHW, "RecibedText.txt"); //create the txt archive
            string backUpFile = Combine(newFolderHW, "BackRT.bak"); //and backup
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
            WriteLine("Text in the archive");
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
                    pal = pal.Replace(",","");
                    pal = pal.Replace(".","");
                    pal = pal.Replace(";","");
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
            WriteLine("");//this is only demostrative into the terminal
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
            //edittext(string folder,string maxpali, int posvocals[], int vocals[])
            Write copia = new();
            copia.TextWrite(newFolderHW, textToUpload, maxpali, posvocals, vocals);
            return "Archive updated";
    }
}