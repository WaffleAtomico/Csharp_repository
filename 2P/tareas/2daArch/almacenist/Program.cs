using System.Xml.Serialization;
using static System.Environment;
using static System.IO.Path;
using usrlib.Shared;
using almacenist.encription;
using almacenist;

Encript encript = new();
ADD addprof = new();
DEL delprof = new();
UPD updprof = new();
Validations isval = new();
Reports mkreport = new();

string xmlpathProf = Combine(CurrentDirectory, "xml/profesor.xml");
string jsonPathProf = Combine(CurrentDirectory, "json/profesor.json");
List<Profesor>? loadedProfe = new();
XmlSerializer xsprof = new(type: loadedProfe.GetType());


#region create firstUserAlm
Almacenista Anel = new()
{
    AlUsrName = "Anel",
    AlPWD = encript.AES("1")
};
//xml
XmlSerializer xs = new(type: Anel.GetType());
string xmlpathAlm = Combine(CurrentDirectory, "xml/almacenist.xml");
using (FileStream stream = File.Create(xmlpathAlm))
{
    xs.Serialize(stream, Anel);
}
// //json
string jsonPathAlm = Combine(CurrentDirectory, "json/almacenist.json");
using (StreamWriter jsonStream = File.CreateText(jsonPathAlm))
{
    Newtonsoft.Json.JsonSerializer jss = new();
    jss.Serialize(jsonStream, Anel);
}
#endregion

#region login
do
{
    WriteLine("User: ");
    string usr = ReadLine();
    WriteLine("Password: ");
    string pwd = ReadLine();
    bool pwdequal = true;

    for (int i = 0; i <= Anel.AlPWD.Length - 1; i++)
    { //read every caracter in the saved data
        if (encript.AES(pwd)[i] != Anel.AlPWD[i])
        { //if in any moment is not equal it will go out
            pwdequal = false;
            break;
        }
    }
    if (pwdequal && usr == Anel.AlUsrName)
    {
        break;
    }
    if (usr != Anel.AlUsrName)
    {
        WriteLine("Unkown user");
    }
    if (!pwdequal)
    {
        WriteLine("Incorrect Password");
    }

} while (true); //infinte cicle until we break the loop
#endregion

#region Menu
bool exitdoor = true;
do
{
    char op = 'a';
    WriteLine("1-Add Profesor");
    WriteLine("2-Edit Profesor");
    WriteLine("3-Kill Profesor (wiii :D)");
    WriteLine("4-Change password");
    WriteLine("5-Generate report");
    WriteLine("6-Exit");
    op = Console.ReadKey().KeyChar;
    WriteLine("");
    switch (op)
    {
        case '1':
            WriteLine("Add Profesor");
            //fuction do while
            string? PrName; //we create the variables to send to the function
            //fuction do while
            string? PrNomine;
            //fuction do while
            string? PrPassword;
            string? PrDivition; //selection sbyte cause is smaller and there are only 
            string[] PrCourses = new string[5]; //selections
            do
            {
                Write("Name: ");
                PrName = ReadLine();
            } while (!isval.USR(PrName));
            do
            {
                Write("Nomine: ");
                PrNomine = ReadLine();
            } while (!isval.NOM(PrNomine));
            do
            {
                Write("Password: ");
                PrPassword = ReadLine();
            } while (!isval.PWD(PrPassword));
            Write("Divition: ");

            PrDivition = ReadLine();

            WriteLine("Courses - type 'X' when you want to stop (MIN 1 - MAX 5): ");
            for (int i = 0; i <= 4; i++)
            {
                Write($"Course {i + 1}: ");
                string tmp = ReadLine(); //tmp is for not save is the result is x
                if ((tmp == "x" || tmp == "X") && i >= 1)
                {
                    break;
                }
                PrCourses[i] = tmp;
            }

            PrCourses = isval.orderCourses(PrCourses); //to order the new courses 
            try
            {
                /*x*/
                if (await addprof.AddProfessorAsincAsync(PrName, encript.AES(PrPassword), encript.AES(PrNomine), PrDivition, PrCourses))
                {
                    WriteLine("Profe Nacido :/");
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }

            break;
        case '2':
            WriteLine("Edit Profesor"); //selection
            try
            {
                /*2x*/
                if (!await updprof.UpdProfessorAsincAsync())
                {
                    WriteLine("Any Profesor was edited in this process");
                }
            }
            catch (System.Exception e)
            {
                WriteLine(e.Message);
            }
            break;
        case '3':
            WriteLine("Kill Profesor (wiii :D)"); //Selection
            try
            {
                /*2x*/
                if (!await delprof.DelProfessorAsincAsync())
                {
                    WriteLine("Any Profesor was killed in this process :| ");
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            break;
        case '4':
            char opwedit = 'a';
            WriteLine("Change password");
            WriteLine("1-Almacenist");
            WriteLine("2-Profesor");
            WriteLine("3-Exit");
            opwedit = Console.ReadKey().KeyChar;
            //only make an validation and just change the pwd
            if (opwedit == '1')
            { //Almacenist
                List<Almacenista>? loadedAlmace = new();
                bool pwdequal = true;
                WriteLine("1-Almacenist: Confirm the password");
                WriteLine("Password: ");
                string pwd = ReadLine();
                for (int i = 0; i <= Anel.AlPWD.Length - 1; i++)
                { //read every caracter in the saved data
                    if (encript.AES(pwd)[i] != Anel.AlPWD[i])
                    { //if in any moment is not equal it will go out
                        pwdequal = false;
                        break;
                    }
                }
                if (pwdequal)
                { //is correct
                    WriteLine("Correct password. Write the new one");
                    string nwpwd = "";
                    // do{
                    nwpwd = ReadLine().Trim();
                    // }while(isval.PWD(nwpwd));
                    Anel.AlPWD = encript.AES(pwd);
                    //update  xml/json
                    //xml
                    using (FileStream stream = File.Create(xmlpathAlm))
                    {
                        xs.Serialize(stream, Anel);
                    }
                    // //json
                    using (StreamWriter jsonStream = File.CreateText(jsonPathAlm))
                    {
                        Newtonsoft.Json.JsonSerializer jss = new();
                        jss.Serialize(jsonStream, Anel);
                    }
                }

            }
            else if (opwedit == '2')
            { //Profesor
                WriteLine("2-Profesor select an professor");
                string ProfToEdit = "", newpasword = "";
                using (FileStream xmlLoad = File.Open(xmlpathProf, FileMode.Open))
                {
                    loadedProfe = xsprof.Deserialize(xmlLoad) as List<Profesor>;
                    if (loadedProfe is not null && loadedProfe.Count >= 1) //at least 1 to edit the data
                    {
                        foreach (Profesor p in loadedProfe)
                        {
                            WriteLine($"Name: {p.PrUsrName}");
                        }
                        WriteLine("Write the name of the Profesor you want to edit their password");
                        ProfToEdit = ReadLine();
                        foreach (Profesor p in loadedProfe)
                        {
                            if (ProfToEdit == p.PrUsrName)
                            {
                                do
                                {
                                    WriteLine("Write this new password");
                                    newpasword = ReadLine().Trim();
                                } while (isval.PWD(newpasword));
                                p.PrPWD = encript.AES(newpasword);
                            }
                        }
                    }
                    else
                    {
                        WriteLine("There are not any Profesors to edit");
                        break;
                    }
                }
                using (FileStream stream = File.Create(xmlpathProf))
                {
                    xsprof.Serialize(stream, loadedProfe);
                }
                //json
                using (StreamWriter jsonStream = File.CreateText(jsonPathProf))
                {
                    Newtonsoft.Json.JsonSerializer jss = new();
                    jss.Serialize(jsonStream, loadedProfe);
                }
            }
            else
            {
                WriteLine("Exit");
            }

            break;
        case '5':
            char generate = 'a';
            WriteLine("Generate report");
            WriteLine("1-Name");
            WriteLine("2-Password");
            WriteLine("3-Nomine");
            WriteLine("4-Divition");
            WriteLine("5-Courses");
            WriteLine("6-Exit");
            generate = Console.ReadKey().KeyChar;
            WriteLine("");
            try
            {
                switch (generate)
                {
                    case '1':
                        await mkreport.PrNameAsync();
                        break;
                    case '2':
                        await mkreport.PrPasswordAsync();
                        break;
                    case '3':
                        await mkreport.PrNomineAsync();
                        break;
                    case '4':
                        await mkreport.PrDivitionAsync();
                        break;
                    case '5':
                        await mkreport.PrCoursesAsync();
                        break;
                    default:
                        break;
                }
            }
            catch(ArgumentNullException e){
                WriteLine("The file: profesor.json contents null argument");
            }
            catch(System.Text.Json.JsonException e){
                WriteLine("The file: profesor.json has bad format");
            }
            catch(NotSupportedException e){
                WriteLine("The file: profesor.json unknown error");
            }
            catch (System.Exception e)
            {
                WriteLine(e.Message);
            }
            break;
        case '6':
        default:
            WriteLine("Do you want to exit? Y/N");
            char exit = Console.ReadKey().KeyChar;
            WriteLine("");
            if (exit == 'Y' || exit == 'y')
            {
                exitdoor = false;
            }
            break;
    }

} while (exitdoor);
#endregion
