// using System;
// using System.Collections.Generic;
// 
// using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.IO.Directory; // CRUD directories
using static System.IO.Path; // create URL's
using usrlib.Shared;
// using FastJson = System.Text.Json.JsonSerializer;

namespace almacenist
{
    public class DEL
    {
        public async Task<bool> DelProfessorAsincAsync()
        {
            string xmlpathProf = Combine(GetCurrentDirectory(), "xml/profesor.xml");
            string jsonPathProf = Combine(GetCurrentDirectory(), "json/profesor.json");
            List<Profesor>? loadedProfe = new();
            XmlSerializer xsprof = new(type:loadedProfe.GetType());
            string ProfToKill="";
            int z=0; //counter in foreach

            if(!Path.Exists(xmlpathProf)){
                throw new Exception("Path not found "+xmlpathProf);
            }

            // if(Path.Exists(xmlpathProf)){
            // XmlSerializer xsprof = new(type:loadedProfe.GetType());
            using (FileStream xmlLoad = File.Open(xmlpathProf,FileMode.Open))
            { //deserialize xml
                loadedProfe = xsprof.Deserialize(xmlLoad) as List<Profesor>;
                if(loadedProfe is not null && loadedProfe.Count >= 2)
                {
                    foreach (Profesor p in loadedProfe)
                    {
                        WriteLine($"Name: {p.PrUsrName}");
                    }
                    WriteLine("Write the name of the Profesor you want to kill");
                    ProfToKill = ReadLine();
                }else{
                    // WriteLine("There are not any Profesors to kill :c");
                    throw new Exception ("There are not any Profesors to kill :c");
                    // return false; //falso verdadero
                }
            }
            foreach (Profesor p in loadedProfe)
            {
                if(ProfToKill == p.PrUsrName){
                    WriteLine($"{p.PrUsrName} was killed succesfully");
                    loadedProfe.RemoveAt(z);
                    break;
                }else{
                    z++;
                }
            } 
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