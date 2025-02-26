using Microsoft.EntityFrameworkCore;
using WorkingWithEFCore;
using System;
using System.Text;
//Info
//https://stackoverflow.com/questions/2562709/iqueryablet-extension-method-not-working


public static class Extensions
{
    //solo a product
    public static double media<T>(this IQueryable<T> query) //where T : IConvertible
    {
        double media = 0;
        int n = query.Count();
        using (Northwind db = new())
        {
            //  IQueryable<Product> products = db.Products;
            foreach (var field in query)
            {
                if(field is string)
                {
                    string? stringValue = Convert.ToString(field);
                    // byte[] sumstring =  Encoding.ASCII.GetBytes(stringValue);
                    foreach (var charvar in stringValue)
                    {
                         media += charvar;
                    }   
                }else
                {
                    media += Convert.ToDouble(field);   
                } 
                //n++;               
            }
        }
        if (media != 0)
            media = media / n;

        return media;

    }
    public static string mediana<T>(this IQueryable<T> query)
    {
        double Mediana = 0;
        int maxValue = query.Count()/2;
        int i =0;
        IQueryable<T> orderDescValues = query.OrderBy(x => x);
        foreach (var item in orderDescValues)
        {
            //WriteLine(item.ToString());
            if(i == maxValue)
                return item.ToString();
            i++;
        }
        return null;
            //me gustaria contar todos los valores
            //y simplemente obtener el valor y por medio de la PK hacer el del medio
            //pero yo no conozco ni la pk, ni cuantos valores hay en total, mucho menos sus indices
            //por ende, si no tengo eso, que puedo tener?
            //Puedo contar cuantos valores hay
            //Puro parar en el valor medio una vez que ya este ordenado
    }
    public static Dictionary<char, int> moda<T>(this IQueryable<T> query)
    {
        Dictionary<char, int> DicionaryChars = new Dictionary<char, int>();
        //double numericModa = 0;    

        foreach (var field in query)
        {   // first, pick all the variables from the query, 
            // we convert them to string to asegurate the times that those repeat
            string? stringValue = Convert.ToString(field);

            foreach (var currentChar in stringValue)
            {
                char normalizedValue = char.ToLower(currentChar);
                if (char.IsWhiteSpace(normalizedValue)) //if the char is a space
                {
                    continue; // Skip
                }else
                {
                    if(DicionaryChars.ContainsKey(normalizedValue)) //exist? yes agregatte +1 to a list
                    {
                         DicionaryChars[normalizedValue] += 1;
                    }else{ //no, crate a new list where it can land
                        DicionaryChars.Add(normalizedValue, 1);
                    } 
                }
            }
        }

        //numericModa = DicionaryChars.Max(m =>m.field);
        // char charModa = DicionaryChars.OrderByDescending(kv => kv.field).First().Key;
        
        return DicionaryChars;
    }
}