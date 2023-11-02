using static System.IO.Path; // create URL's

namespace LectorLib.EditText
{
    public class Write
    {
        public void TextWrite(string FolderPath, string textToUpload, string maxpali, int[] posvocals, int[] vocals) 
        {
            string filePath = Combine(FolderPath, "RecibedText.txt");
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
        }
    }
}