// if(expression)
// {
// }
// else if(expression){
// }

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

