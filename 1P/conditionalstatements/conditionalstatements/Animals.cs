using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace conditionalstatements
{
    public string? Name;
    public DateTime Born;
    public int Legs;
    public bool IsDomestic;
    int Age;
    public class Animal
    {
        Animal[] animals = new Animal?[]
        {
            new Pig{
                name = "Oreo",
                Born = new (year:2012, month:8,day:2),
                legs = 4,
                IsDomestic = true,
                Age = 12
            },
            new Cat{
                name = "Juno",
                Born = new (year:2010, month:4,day:23),
                legs = 4,
                IsDomestic = true,
                Age = 12,
            },
            new Dog{
                name = "Pato",
                Born = new (year:2014, month:8,day:2),
                legs = 3,
                IsDomestic = true,
                Age = 12,
            }
        };
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