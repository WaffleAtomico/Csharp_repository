// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.IO.Directory; // CRUD directories
using static System.IO.Path; // create URL's
using usrlib.Shared;
// using FastJson = System.Text.Json.JsonSerializer;
using almacenist.encription;

namespace almacenist
{
    public class UPD
    {
        public async Task<bool> UpdProfessorAsincAsync()
        {
            string xmlpathProf = Combine(GetCurrentDirectory(), "xml/profesor.xml");
            string jsonPathProf = Combine(GetCurrentDirectory(), "json/profesor.json");
            List<Profesor>? loadedProfe = new();
            Validations isval = new();
            Encript encript = new();
            XmlSerializer xsprof = new(type:loadedProfe.GetType());
            string ProfToEdit="", editData="";
            char fieldToEdit='a';                
            
            if(!Path.Exists(xmlpathProf)){
                throw new FileNotFoundException("File not found to edit "+ xmlpathProf);
            }
            
                // XmlSerializer xsprof = new(type:loadedProfe.GetType());
                using (FileStream xmlLoad = File.Open(xmlpathProf,FileMode.Open))
                {
                    loadedProfe = xsprof.Deserialize(xmlLoad) as List<Profesor>;
                    if(loadedProfe is not null && loadedProfe.Count >= 1)
                    {
                        foreach (Profesor p in loadedProfe)
                        {
                            WriteLine($"Name: {p.PrUsrName}");
                        }
                        WriteLine("Write the name of the Profesor you want to edit");
                        ProfToEdit = ReadLine();
                    }else{
                        WriteLine("There are not any Profesors to edit");
                        return false;
                    }
                }
                bool foundProf = false;
                foreach (Profesor p in loadedProfe)
                {
                        if(ProfToEdit == p.PrUsrName){
                        foundProf= true;
                        // WriteLine($"{p.PrUsrName} was killed succesfully");
                        WriteLine("Data you want to edit");
                            WriteLine("1-Name");
                            WriteLine("2-Nomine");
                            WriteLine("3-Divition");
                            WriteLine("4-Courses");
                            WriteLine("5-Exit");
                        fieldToEdit = Console.ReadKey().KeyChar;
                        WriteLine("");
                        switch (fieldToEdit)
                        {
                        case '1':
                            do{
                                WriteLine("1-Name: Write the new name");
                                editData = ReadLine();
                            }while(!isval.USR(editData)); //repeat until is a new value
                            p.PrUsrName = editData;
                        break;
                        case '2':
                            do{
                                WriteLine("2-Nomine: Write the new Nomine");
                                editData = ReadLine();
                            }while(!isval.NOM(editData)); //repeat until is a new value
                            p.PrNomi =  encript.AES(editData);
                        break;
                        case '3':
                                WriteLine("3-Divition: Write the new Diviton");
                                editData = ReadLine();
                                if(editData.Length >= 30){
                                    throw new Exception("Division too long");
                                }
                                if(editData.Length == 0){
                                    throw new Exception("Division too short");
                                }
                                p.PrDivition =  editData.Trim();
                        break;
                        case '4':
                            char indexCourse = 'a';
                            // int indexCourse =0;
                                WriteLine("4-Courses: Select a course to Edit");
                                for(int i=0; i<=p.PrCourse.Length-1; i++){ //show the courses
                                    WriteLine($"{i+1}.-{p.PrCourse[i]}");
                                }
                            indexCourse = Console.ReadKey().KeyChar;
                            WriteLine("");
                            switch (indexCourse)
                            {
                                case '1':
                                    WriteLine("Write the new course 1");
                                    editData = ReadLine().Trim();
                                    if(editData == ""){
                                        p.PrCourse[0] = null;
                                    }else{
                                        p.PrCourse[0] =  editData;
                                    }                                    
                                break;
                                case '2':
                                if(2 <= p.PrCourse.Length){
                                    WriteLine("Write the new course 2");
                                    editData = ReadLine().Trim();
                                    if(editData == ""){
                                        p.PrCourse[1] = null;
                                    }else{
                                    p.PrCourse[1] =  editData;
                                    }
                                }else{
                                    WriteLine("There any course to edit here");
                                }
                                break;
                                case '3':
                                if(3 <= p.PrCourse.Length ){
                                    WriteLine("Write the new course 3");
                                    editData = ReadLine().Trim();
                                    if(editData == ""){
                                        p.PrCourse[2] = null;
                                    }else{
                                    p.PrCourse[2] =  editData;
                                    }
                                }else{
                                    WriteLine("There any course to edit here");
                                }                                
                                break;
                                case '4':
                                if(4 <= p.PrCourse.Length ){
                                    WriteLine("Write the new course 4");
                                    editData = ReadLine().Trim();
                                    if(editData == ""){
                                        p.PrCourse[3] = null;
                                    }else{
                                    p.PrCourse[3] =  editData;
                                    }
                                }else{
                                    WriteLine("There any course to edit here");
                                }                                    
                                break;
                                case '5':
                                if(5 <= p.PrCourse.Length){
                                    WriteLine("Write the new course 5");
                                    editData = ReadLine().Trim();
                                    if(editData == ""){
                                        p.PrCourse[4] = null;
                                    }else{
                                    p.PrCourse[4] =  editData;
                                    }
                                }else{
                                    WriteLine("There any course to edit here");
                                }                                    
                                break;
                                default:
                                    WriteLine("Index of the course not found");
                                break;
                            }
                            p.PrCourse = isval.orderCourses(p.PrCourse);
                        break;
                        case '5':default:
                            WriteLine("Exit");
                        break;
                        }
                        
                    break;
                    }
                    
                }
                if(!foundProf){
                    throw new Exception("Profesor not found "+ ProfToEdit);
                } 
                //update  the json/xml
                //xml
                using(FileStream stream = File.Create(xmlpathProf))
                {
                    xsprof.Serialize(stream,loadedProfe);
                }
                //json
                using (StreamWriter jsonStream = File.CreateText(jsonPathProf))
                {
                    Newtonsoft.Json.JsonSerializer jss = new();
                    jss.Serialize(jsonStream, loadedProfe);
                }
                return true;
            
        }
    }
}