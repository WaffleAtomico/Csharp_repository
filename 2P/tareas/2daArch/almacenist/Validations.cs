using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace almacenist
{
    public class Validations
    {
        public bool USR(string user){
            user = user.Trim();
            if(user.Length <= 8 || user.Length >=25){
                WriteLine($"Too short or long: {user.Length} chars");
                return false;
            }
            bool charverify = false;
            foreach (var item in user) //mayus
            {
                if(item >= 65 && item <=90){ 
                    charverify = true;
                    break;
                }
            }
            if(charverify == false){ //if its negative return 
                WriteLine("No Mayus");
                return false;
            }
            charverify = false;
            foreach (var item in user) //minus
            {
                if(item >= 97 && item <=122){
                    charverify = true;
                    break;
                }
            }
            if(charverify == false){ //if its negative return 
                WriteLine("No minus");
                return false;
            }
            charverify = false;
            foreach (var item in user) //especial char
            {
                if((item >= 65 && item <=90) || (item >= 97 && item <=122) || item == 32){
                    charverify = true;
                    break;
                }
            }
            if(charverify == false){ //if its negative return 
                WriteLine("Special Chars");
                return false;
            }
            if(!user.Contains(' ')){ //if not contains spaces return false
                WriteLine("Not contains spaces");
                return false;
            }
            return true;
        }
        public bool PWD(string password){
            password = password.Trim();
            if(password.Length <= 8 || password.Length >=15){
                WriteLine($"Too short or long: {password.Length} chars");
                return false;
            }
            bool charverify = false;
            foreach (var item in password) //mayus
            {
                if(item >= 65 && item <=90){ 
                    charverify = true;
                    break;
                }
            }
            if(charverify == false){ //if its negative return 
                WriteLine("No Mayus");
                return false;
            }
            charverify = false;
            foreach (var item in password) //minus
            {
                if(item >= 97 && item <=122){
                    charverify = true;
                    break;
                }
            }
            if(charverify == false){ //if its negative return 
                WriteLine("No minus");
                return false;
            }
            charverify = false;
            foreach (var item in password) //especial char
            {
                if(!((item >= 65 && item <=90) || (item >= 97 && item <=122))){
                    charverify = true;
                    break;
                }
            }
            if(charverify == false){ //if its negative return 
                WriteLine("Not Special Chars");
                return false;
            }
            if(password.Contains(' ')){ //if contains spaces return false
                WriteLine("Contains spaces");
                return false;
            }
            return true;
        }
        public bool NOM(string nomine){
            nomine = nomine.Trim();
            if(nomine.Length != 10){
                WriteLine($"Must have 10 chars: {nomine.Length} chars");
                return false;
            }
            bool charverify = false;
            foreach (var item in nomine) //mayus
            {
                if(item >= 65 && item <=90){ 
                    charverify = true;
                    break;
                }
            }
            if(charverify == false){ //if its negative return 
                WriteLine("No Mayus");
                return false;
            }
            charverify = false;
            foreach (var item in nomine) //minus
            {
                if(item >= 97 && item <=122){
                    charverify = true;
                    break;
                }
            }
            if(charverify == false){ //if its negative return 
                WriteLine("No minus");
                return false;
            }
            charverify = false;
            foreach (var item in nomine) //especial char
            {
                if(item>=48 && item <=57){
                    charverify = true;
                    break;
                }
            }
            if(charverify == false){ //if its negative return 
                WriteLine("No Numbers");
                return false;
            }
            if(nomine.Contains(' ')){ //if contains spaces return false
                WriteLine("Contains spaces");
                return false;
            }
            return true;
        }
        public string[] orderCourses(string[] arr){
               arr = arr.Where(x => !string.IsNullOrEmpty(x)).OrderBy(x => x).ToArray();
        return arr;
        }     
    }
}