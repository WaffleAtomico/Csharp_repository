// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.IO.Directory; // CRUD directories
using static System.IO.Path; // create URL's
using usrlib.Shared;

using FastJson = System.Text.Json.JsonSerializer;

namespace almacenist
{
    public class Reports
    {
        List<Profesor>? loadedProfe = new(); //every class need this list to order their values
        string jsonPathProf = Combine(GetCurrentDirectory(), "json/profesor.json");
        public async Task<bool> PrNameAsync()
        {
            if(!Path.Exists(jsonPathProf)){
                throw new Exception("File not found: "+ jsonPathProf);
            }
            using (FileStream JsonLoad = File.Open(jsonPathProf, FileMode.Open) )
            {
            loadedProfe = await FastJson.DeserializeAsync
            (utf8Json: JsonLoad, returnType: typeof(List<Profesor>)) as List<Profesor>;
            }
            string xmlpath = Combine(GetCurrentDirectory(), "xml/ByNAME.xml");
            string jsonPath = Combine(GetCurrentDirectory(), "json/ByNAME.json");
            // arr = arr.Where(x => !string.IsNullOrEmpty(x)).OrderBy(x => x).ToArray();
            loadedProfe = loadedProfe.OrderBy(profesor => profesor.PrUsrName).ToList();
            XmlSerializer xsprof = new(type:loadedProfe.GetType());
            using(FileStream stream = File.Create(xmlpath))
            {
                xsprof.Serialize(stream,loadedProfe);
            }
            //json
            using (StreamWriter jsonStream = File.CreateText(jsonPath))
            {
                Newtonsoft.Json.JsonSerializer jss = new();
                jss.Serialize(jsonStream, loadedProfe);
            }
            return true;
        }
        public async Task<bool> PrPasswordAsync()
        {
            if(!Path.Exists(jsonPathProf)){
                throw new Exception("File not found: "+ jsonPathProf);
            }
            using (FileStream JsonLoad = File.Open(jsonPathProf, FileMode.Open) )
            {
            loadedProfe = await FastJson.DeserializeAsync
            (utf8Json: JsonLoad, returnType: typeof(List<Profesor>)) as List<Profesor>;
            }
            string xmlpath = Combine(GetCurrentDirectory(), "xml/ByPWD.xml");
            string jsonPath = Combine(GetCurrentDirectory(), "json/ByPWD.json");
            loadedProfe = loadedProfe.OrderBy(profesor => BitConverter.ToString(profesor.PrPWD)).ToList();
            XmlSerializer xsprof = new(type:loadedProfe.GetType());
            using(FileStream stream = File.Create(xmlpath))
            {
                xsprof.Serialize(stream,loadedProfe);
            }
            //json
            using (StreamWriter jsonStream = File.CreateText(jsonPath))
            {
                Newtonsoft.Json.JsonSerializer jss = new();
                jss.Serialize(jsonStream, loadedProfe);
            }
            return true;
        }
        public async Task<bool> PrNomineAsync()
        {
            if(!Path.Exists(jsonPathProf)){
                throw new Exception("File not found: "+ jsonPathProf);
            }
            using (FileStream JsonLoad = File.Open(jsonPathProf, FileMode.Open) )
            {
            loadedProfe = await FastJson.DeserializeAsync
            (utf8Json: JsonLoad, returnType: typeof(List<Profesor>)) as List<Profesor>;
            }
            string xmlpath = Combine(GetCurrentDirectory(), "xml/ByNOM.xml");
            string jsonPath = Combine(GetCurrentDirectory(), "json/ByNOM.json");
            loadedProfe = loadedProfe.OrderBy(profesor => BitConverter.ToString(profesor.PrNomi)).ToList();
            XmlSerializer xsprof = new(type:loadedProfe.GetType());
            using(FileStream stream = File.Create(xmlpath))
            {
                xsprof.Serialize(stream,loadedProfe);
            }
            //json
            using (StreamWriter jsonStream = File.CreateText(jsonPath))
            {
                Newtonsoft.Json.JsonSerializer jss = new();
                jss.Serialize(jsonStream, loadedProfe);
            }
            return true;
        }
        public async Task<bool> PrDivitionAsync()
        {
            if(!Path.Exists(jsonPathProf)){
                throw new Exception("File not found: "+ jsonPathProf);
            }
            using (FileStream JsonLoad = File.Open(jsonPathProf, FileMode.Open) )
            {
            loadedProfe = await FastJson.DeserializeAsync
            (utf8Json: JsonLoad, returnType: typeof(List<Profesor>)) as List<Profesor>;
            }
            string xmlpath = Combine(GetCurrentDirectory(), "xml/ByDIV.xml");
            string jsonPath = Combine(GetCurrentDirectory(), "json/ByDIV.json");
            loadedProfe = loadedProfe.OrderBy(profesor => profesor.PrDivition).ToList();
            XmlSerializer xsprof = new(type:loadedProfe.GetType());
            using(FileStream stream = File.Create(xmlpath))
            {
                xsprof.Serialize(stream,loadedProfe);
            }
            //json
            using (StreamWriter jsonStream = File.CreateText(jsonPath))
            {
                Newtonsoft.Json.JsonSerializer jss = new();
                jss.Serialize(jsonStream, loadedProfe);
            }
            return true;
        }
        public async Task<bool> PrCoursesAsync()
        {
            if(!Path.Exists(jsonPathProf)){
                throw new Exception("File not found: "+ jsonPathProf);
            }
            using (FileStream JsonLoad = File.Open(jsonPathProf, FileMode.Open) )
            {
            loadedProfe = await FastJson.DeserializeAsync
            (utf8Json: JsonLoad, returnType: typeof(List<Profesor>)) as List<Profesor>;
            }
            string xmlpath = Combine(GetCurrentDirectory(), "xml/ByCOUR.xml");
            string jsonPath = Combine(GetCurrentDirectory(), "json/ByCOUR.json");
            loadedProfe = loadedProfe.OrderBy(profesor => profesor.PrCourse.Count()).ToList();
            XmlSerializer xsprof = new(type:loadedProfe.GetType());
            using(FileStream stream = File.Create(xmlpath))
            {
                xsprof.Serialize(stream,loadedProfe);
            }
            //json
            using (StreamWriter jsonStream = File.CreateText(jsonPath))
            {
                Newtonsoft.Json.JsonSerializer jss = new();
                jss.Serialize(jsonStream, loadedProfe);
            }
            return true;
        }
    }
}