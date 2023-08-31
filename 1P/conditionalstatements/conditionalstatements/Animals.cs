using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace conditionalstatements
{
   
    public class Animal
    {
        public string? name;
        public DateTime Born;
        public int legs;
        public bool IsDomestic;
        public int Age;
    }
    public class Pig : Animal
    {     
    }
    public class Cat : Animal
    {
        public bool isPoisonous;
    }
    public class Dog : Animal
    {        
    }
}