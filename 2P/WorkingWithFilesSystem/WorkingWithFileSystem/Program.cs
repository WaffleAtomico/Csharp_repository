using static System.IO.Directory; // CRUD directories
using static System.IO.Path; // create URL's
using static System.Environment;
using Microsoft.VisualBasic.FileIO; //get the localtion, SpecialFolder, etc etc etc etc
                                    //those are the mores importants to make archives
                                    //File, Wirte or read drom files, StreamWriter, StreamReader

#region Getting Directories Info
WriteLine("Handling cross platform enviroments");
    WriteLine($"{"Path.PathSeparator",-33} {PathSeparator}"); //property
    WriteLine($"{"Path.DirectorySeparatorChar",-33} {DirectorySeparatorChar}");
    WriteLine($"{"Path.GetCurrentDirectory",-33} {GetCurrentDirectory()}"); //method
    WriteLine($"{"Enviroment.SystemDirectory",-33} {SystemDirectory}"); //property
    WriteLine($"{"Path.GetTempPath()",-33} {GetTempPath()}"); //method
    //every archive not saved get a temporal archive
    WriteLine($"{"GetFolderPath(SpecialFolder.System)",-33} {GetFolderPath(SpecialFolder.System)}"); //special folder is an subclass
    //send a type folder everytime
    WriteLine($"{"GetFolderPath(SpecialFolder.ApplicationData)",-33} {GetFolderPath(SpecialFolder.ApplicationData)}"); 
    WriteLine($"{"GetFolderPath(SpecialFolder.MyDocuments)",-33} {GetFolderPath(SpecialFolder.MyDocuments)}"); 
#endregion

 #region manage Drives
    SectionTitle("Mananging Drives");
    WriteLine($"{"NAME",-30}{"TYPE",-10}{"FORMAT",-7}{"SIZE(BYTES)",18}{"FREE SPACE",18}");
    foreach(DriveInfo drive in DriveInfo.GetDrives())
    {
        WriteLine($"{drive.GetType(),-30}{drive.GetType(),-10}{drive.DriveFormat,-7}{drive.TotalSize,18}{drive.TotalFreeSpace,18}");
    }
 #endregion

 #region  Manage Directories
    SectionTitle("Mananging Directories");
                                // en donde?
    string newFolder = Combine(GetFolderPath(SpecialFolder.MyDocuments),"NewFolder" );
    WriteLine($"Working with {newFolder}"); //name of folder
    WriteLine($"Does it exist : {Path.Exists(newFolder)}"); //existe?
    WriteLine($"Creating it ...");
    CreateDirectory(newFolder);
    WriteLine($"Does it exist : {Path.Exists(newFolder)}"); //existe?
    ReadLine(); //si se crea uno con el mismo nombre sobreescribe
    Delete(newFolder, recursive: true); //, recursive: true
    WriteLine("Assasinate the directory");
    //Para eliminar de manera recursiva Orden: derecha, izquierda raiz
    WriteLine($"Does it exist : {Path.Exists(newFolder)}"); //existe?
 #endregion

 #region Manage Files
    SectionTitle("Mananging Files");
    string dir = Combine(GetFolderPath(SpecialFolder.MyDocuments),"OutputFiles");
    CreateDirectory(dir);
    //define file paths
    string textFile = Combine(dir, "Dummy.txt");
    string backUpFile = Combine(dir,"dummy.bak");
    WriteLine($"Working with {textFile}");
    //check if exist
    WriteLine($"Does it exist? : {Path.Exists(textFile)}"); //existe?
    //create the file
    StreamWriter textWriter = File.CreateText(textFile);
    //write onto the file
    textWriter.WriteLine("Hello my brudaaaa");
    textWriter.Close();
    //cada que se abre un archivo se tiene que cerrar
    File.Copy(sourceFileName: textFile, destFileName: backUpFile); //File is a class
    //this archive is a bidimentional array, you can go for rows or colums
    File.Delete(textFile);
    //check if exist
    WriteLine($"Does it exist? : {Path.Exists(textFile)}"); //existe?
    //Readmform file
    WriteLine("Reading from file");
    StreamReader textReader = File.OpenText(backUpFile); 
    WriteLine(textReader.ReadToEnd()); //sabe cuando termina cuando el puntero "endoffile" = eof
    textReader.Close();
 #endregion


//Practica
//De una archivo con texto cualquiera
//lorem impsum well
//Entrar en el archivo
//Despues de que se acabe el archivo mostrar cuantas vocales se repiten
// a-10
// e-10
// i-11
// o-1
// u - 0

//Si no tiene letras, se muestra como un 0 y la u nunca se muestra el numero de esa

// En la ultima vocal conocida en el archivo que se encuentre va a ir el numero

//digamos, en la ultima a = arbol == 10rbol

//Encontrar el anagrama mas grande de todo el archivo
//Abajo de las vocales poner todas las combinaciones que tiene el anagrama
//La palabra mas larga que haya

//ahora debe de haber un un palindromo en el texto

//10 minimas unit testing

//el palindromo mas grande

//pueden ser falsos positivos