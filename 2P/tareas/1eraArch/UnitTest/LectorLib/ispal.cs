namespace LectorLib.Checkpalin
{
    public class Ispal
    {
        public string ispalindromo(string pal) //fuction made to know if a word is a palindrome or if isnt
            {
            int palength = pal.Length-1;//we need to know the lenght of the word
                for(int i=0; i<=(pal.Length)/2; i++){ //then is the lenght/2 to only compare to the middle and dont do more loops than 
                    // WriteLine($"ini { pal[i] } fin {pal[palength  - i]}");
                    if (!string.Equals(pal[i].ToString(), pal[palength - i].ToString(),
                    StringComparison.OrdinalIgnoreCase))//this is to ignore the case, and Any word with upper and lowe can be compared
                    {
                        return "";//we return a short, a very short word meaning that isnt a palindrome
                    }   
                }
            // WriteLine("Salgo "+pal);
            return pal; //we return the complete word
            }
    }
}