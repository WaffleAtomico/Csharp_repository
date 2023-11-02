using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PA17F.Shared;
using static PA17F.Shared.Person;
partial class Program
{//un metodo que ni siquiera esta en el main, se puede mandar a llamar funciones
    //Method to handle the shout (Delegate) event

    //sender es el objeto que esta sacando
    static void Jordi_Shout (object? sender, EventArgs e){ //no se pueden hacer delegados privados
        if(sender is null) return;
        Person? p = sender as Person;
        if(p is null) return;
        WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
    }
}


// namespace PeopleApp
// {
//     public class Program.EventHandlers
//     {
        
//     }
// }