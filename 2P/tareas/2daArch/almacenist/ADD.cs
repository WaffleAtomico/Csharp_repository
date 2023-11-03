using System.Xml.Serialization;
using static System.IO.Directory; // CRUD directories
using static System.IO.Path; // create URL's
// using static System.Environment;

using usrlib.Shared;
using FastJson = System.Text.Json.JsonSerializer;

namespace almacenist
{
    public class ADD
    {
        public async Task<bool> AddProfessorAsincAsync(string name, byte[] password, byte[] nomine, string divition, string[] PrCourses)
        {
            string xmlpath = Combine(GetCurrentDirectory(), "xml/profesor.xml");
            string jsonPath = Combine(GetCurrentDirectory(), "json/profesor.json");

            if(!Path.Exists(xmlpath) && !Path.Exists(jsonPath) 
            ){ //check if exist any of the files
                // WriteLine("Creando nuevo Maestro");
                if(divition.Length >= 30){
                    throw new Exception ("Division lenght too long");
                }
                //courses tmb puede tener exception
                List<Profesor> Profe = new(){
                    new(){
                        PrUsrName = name,
                        PrPWD = password,
                        PrNomi = nomine,
                        PrDivition = divition,
                        PrCourse = PrCourses
                    }
                };
                //xml
                XmlSerializer xs = new(type:Profe.GetType());
                using(FileStream stream = File.Create(xmlpath))
                {
                    xs.Serialize(stream,Profe);
                }
                //json
                using (StreamWriter jsonStream = File.CreateText(jsonPath))
                {
                    Newtonsoft.Json.JsonSerializer jss = new();
                    jss.Serialize(jsonStream, Profe);
                }
            }else{
                //3 steps
                //1 Asign to a list the new Professor
                //2 Get the Data from the Json and add the new information
                //3 ReWrite the json and xml
                // WriteLine("Agregando nuevo Maestro");
                List<Profesor> Profe = new(){
                    new(){
                        PrUsrName = name,
                        PrPWD = password,
                        PrNomi = nomine,
                        PrDivition = divition,
                        PrCourse = PrCourses
                    }
                };
                List<Profesor>? loadedProfe = new();
                using (FileStream JsonLoad = File.Open(jsonPath, FileMode.Open) )
                {
                loadedProfe = await FastJson.DeserializeAsync
                (utf8Json: JsonLoad, returnType: typeof(List<Profesor>)) as List<Profesor>;
                    if(loadedProfe is not null)
                    {
                        WriteLine("Agregado");
                        loadedProfe.Add(Profe[0]);
                    }
                }//close the process

                    // if(Path.Exists(xmlpath)){
                    //     File.Delete(xmlpath);
                    // }
                    // if(Path.Exists(jsonPath)){
                    //     File.Delete(jsonPath);
                    // }
                    
                    //xml
                    XmlSerializer xs = new(type:Profe.GetType());
                    using(FileStream stream = File.Create(xmlpath))
                    {
                        xs.Serialize(stream,loadedProfe);
                    }
                    //json
                    using (StreamWriter jsonStream = File.CreateText(jsonPath))
                    {
                        Newtonsoft.Json.JsonSerializer jss = new();
                        jss.Serialize(jsonStream, loadedProfe);
                    }
                            
            }
            return true;
        }       

    }
}