namespace usrlib.Shared;
using System.Collections.Generic;
using System.Collections;
using System.Xml.Serialization; //[XMLAttributes]

public class Almacenista
{
    // public Alm(){}
    public string? AlUsrName {get; set;}
    public required byte[] AlPWD {get; set;} //encriptado

}
public class Profesor
{
    // public Prof(){}
    public string? PrUsrName { get; set; }
    public required byte[] PrNomi { get; set; } //encriptar
    public required byte[] PrPWD { get; set; } //encriptar
    public string[]? PrCourse { get; set; } //mostrar de asc alfabetico
    public string? PrDivition { get; set; }

}
// public class Salon
// {
//     // public Sal(){}

// }