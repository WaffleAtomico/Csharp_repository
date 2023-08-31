// if(expression)
// {
// }
// else if(expression){
// }

using conditionalstatements;

string password = "SatouroGoujo"; //Geto (kfc)
if(password .Length <12)
{
    WriteLine("Your password is too short. use at least 12");
}
else
{
    WriteLine("Your password is strong");
}

object o =3;
int j=4;
if(o is int i /*out preference*/) //hace la referencia a un tipo nuevo que esta siendo generado a la hora de correr el codigo
{
    WriteLine($"{i} * {j} = {i*j}");
}
else
{
    WriteLine("Is not interger, can not multiply");
}

// random number
int number = Random.Shared.Next(1,7);
// number = 5;
WriteLine($"Memory random number is {number}");
switch (number)
{
    case 1:
    {
    WriteLine("One");
    break;
    }
    case 2:
    {
    WriteLine("two");
    goto case 1;
    }
    case 3:
    case 4:
    {
    WriteLine("Three or four");
    goto case 1;
    }
    case 5:
    goto A_label; //

    default:
    WriteLine("Default");
    break;
}
WriteLine("After end of switch");
A_label:
WriteLine("After A_label");


Animal?[] animals = new Animal?[] // el ? indica que un string se pueda indicar a manera nula
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
//pattern match switch
foreach (var animal in animals) //trabaja con los objetos de la coleccion
{
    string message = string.Empty;
    switch (animal)
    {

        /*
        case Cat:
            message = $"";
            //cuando se usa pattern matching si o si usar el brake
        break;*/
        //mientras hay un caso generalizado antes, el de abajo nunca se ejecutara
        //no se pueden poner los casos generalizados al incio. Al igual que la opcion

        case Cat fourLegCat when fourLegCat.legs ==4:
            message = $"THe name of the cat is {fourLegCat.name}";
            //cuando se usa pattern matching si o si usar el brake
        break;

        case Pig chanchito when !chanchito.IsDomestic: //por default piensa que es falso con el ! debe de ser verdadero
            message =$"You have a beautiful companion mate, say hi to {chanchito.name}";
        break;

        case Dog Platon when Platon.Age == 11:
            message =$"oldie but goldie, good old {Platon.name}";
        break;
        default:
        message ="That type of animal does not exist.";
        break;
    }

    //simplified switcch | minimalist switch

    //hacer esto minimiza la memoria

    message = animal switch
    {
        // => es sobrecarga de operadores, de lambda
        //esta mandando a llamar lo que previamente estuvo o no estuvo declarado
        //cuando veamos llamadas anonimas quedara mas claro
        //lo que esta en el del medio es un intermediario
        //Una llamada no se necesita saber a quien le llamas pero si a donde vas??????
        //a lambda no le importa lo que esta del lado derecho, lo ejecuta
        //las lambdas son feas feas
        Cat threeLegCat when threeLegCat.legs ==3 =>
        $"THe name of the cat is {threeLegCat.name}",

        Cat poisonousCat when !poisonousCat.isPoisonous =>
        $"STAY AWAY of that michi!!",
    };

    //detras de bambalina del switch, ejecuta cada uno de los case
    //en ejecucion no se nota la diferencia, pero en memoria si
    //en el simplificado espera hasta en el que cae y devolver el valor

}