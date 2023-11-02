using System.Xml.Serialization;
using PA17F.Shared;
using static System.Environment;
using static System.IO.Path;

//con lo estatico solo puedes acceder a uno en especial, o sea, solo se puede usar Path
//Mas no IO

//alias
using FastJson = System.Text.Json.JsonSerializer;

// namespace WorkingWithSerialization;

List<Person> people = new(){
    new(30000M)
    {
        Name = "Isaac",
        lastname = "Chavez",
        DateOfBirth = new (year:2005, month:03, day:2)
    },
    new(400000M)
    {
        Name = "Carolina",
        lastname = "Prian",
        DateOfBirth = new (year:2006, month:05, day:14)
    },
    new(20000M)
    {
        Name = "Samantha",
        lastname = "Valadez",
        DateOfBirth = new (year:2005, month:02, day:20)
    },
    new(8000M)
    {
        Name = "Paco",
        lastname = "Juarez",
        DateOfBirth = new (year:2003, month:09, day:12),
        Children = new()
        {
            new(0M)
            {
                Name ="Ana",
                lastname = "Velasquez",
                DateOfBirth = new (year:2023, month:10, day:1),
            },
            new(0M)
            {
                Name = "Hector",
                lastname = "Velasquez",
                DateOfBirth = new (year:2019, month:11, day:23),
            },
        }
    },

};

//Cualquier calse se puede describir como un grafo, ya que tiene una raiz y sus hojas
//

#region Serializar
    XmlSerializer xs = new(type:people.GetType());

    string path = Combine(CurrentDirectory, "people.xml");

    // 1: Take care of the open on stream
    // 2: 
    // 3: 

    using(FileStream stream = File.Create(path))
    {
        xs.Serialize(stream,people);
    }

    WriteLine($"Written {new FileInfo(path).Length} bytes of xml to {path}");
    WriteLine();
    //Read
    WriteLine(File.ReadAllText(path));
#endregion

#region Deserializar
    WriteLine("Deseriaze people List");
    using (FileStream xmlLoad = File.Open(path,FileMode.Open))
    {
        //Deserialize
        // List<Person>? loadedPeople = (List<Person>)xs.Deserialize(xmlLoad);
        List<Person>? loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;
        if(loadedPeople is not null)
        {
            foreach (Person p in loadedPeople)
            {
                WriteLine($"{p.Name} has {p.Children?.Count ?? 0} children.");
            }
        }
    }
#endregion

#region Serialize Json
    string jsonPath = Combine(CurrentDirectory, "Persona.json");
    using (StreamWriter jsonStream = File.CreateText(jsonPath))
    {
        WriteLine($"Written {new FileInfo(path).Length} bytes of Json to {path}");
        Newtonsoft.Json.JsonSerializer jss = new();
        jss.Serialize(jsonStream, people);
    }
#endregion

#region Deserialize Json
    WriteLine("Deserialize Json");
    using (FileStream JsonLoad = File.Open(jsonPath, FileMode.Open) )
    {
        // deserialize
        //sincrono: Esperar a que termine una actividad para poder seguir el siguiente
        //ASincrono hacer varias cosas en el mismo proceso
        List<Person>? loadedPeople = await FastJson.DeserializeAsync
        (utf8Json: JsonLoad, returnType: typeof(List<Person>) ) as List<Person>;
        if(loadedPeople is not null)
        {
            foreach (Person p in loadedPeople)
            {
                // ?? ternario si llega a nulo imprime 0
                WriteLine($"{p.Name} has {p.Children?.Count ?? 0} children.");
            }
        }
    }

    /*
    cosas necesarias para hacer un metodo asincrono
    Task: accede a los hilos esto
    await:
    async Task<int> GetLenghtString(string s)
    {
        return await s.Lenght;
    }
    */
#endregion


/* Practica

N almacenistas, como se van a dar de alta?

Un login
Como hago mi primer almacenista?

Le vale madre el login

1ero: Agregar profe
2do: Editar profe
3ero: Matar un profe
4to: Cambiar pasword, Almacenista/Profesor
5to: Reportes


Con Json y XML se van a hacer todos

Se serialzara

1 archivo JSON/XML por usuario
Almacenista
Profesor
Salones

Almacenista con pasword encriptado en lo que sea y se le ajusta IDGA
AES
SHA
HASH
MDS

El profesor se le tiene que encriptar su nomina y pasword


El profesor en realidad el archivo XML y JSON 

Se debe de ordenar sus materias en forma ascendente de manera alfabetica
A
B
C


Reportes Se va a poder generar un nuevo archivo XML/JSON
Y que se le pregunte por cual de todos los campos quiere organizarlo
Nombre
Nomina
Password
Materiaas
Division

1 NC
2 N
3 Pasword

Salon??????

Archivo para almacenista
PRofesor
Los archivos de cada apartado

Pruebas unitarias de acuerdo para cada archivo

10 pruebas unitarias
Probar la funcion

En un contexto en el que no esperabas en que 

En que contexto de hace una prueba

Each Cases

Y si se abre rompiendo la botella?

Cumplir lo que esperas, ya sea un error o una respuesta correcta en torno al objetivo

Login solo es para almacenista
o un login para solo un almacenista

Hay que saber como conectar el profesor con el salon etc etc
*/


//diagrama entidad relacion 3er forma normal