namespace _1erArchUnitTest;
using _1eraArch;

public class UnitTest1
{
    //1
    [Fact]
    public void NotArguments()
    {
        Arch palindroco = new();
        //@ = verbatim = his means that the string is interpreted exactly as it is written, without interpreting escape characters
         string path =null;
        Assert.ThrowsAny<ArgumentNullException>(() =>
        {
           string actual = palindroco.TextPalin(path);
        });
    }
    //2
    [Fact]
    public void Unauthorized()
    {
        Arch palindroco = new();
        string path = @"C:\\";
        //1 @"C:\Recovery\ReAgentOld.xml"; //no autorized
        // File.SetAttributes(path, FileAttributes.Encrypted);
        Assert.ThrowsAny<UnauthorizedAccessException>(() =>
        {
           string actual = palindroco.TextPalin(path);
        });
    }
    //3
    [Fact]
    public void Usedarchive()
    {
        Arch palindroco = new();
        string path =  @"C:\Users\penil\OneDrive\Escritorio\CETI\OTROS\Horario de clases CETI .xlsx";        
        //abre el archivo antes
        Assert.ThrowsAny<IOException>(() =>
        {
           string actual = palindroco.TextPalin(path);
        });
    }
    //4
    [Fact]
    public void DirectoNotfound()
    {
        Arch palindroco = new();
        string path = @"C:\Users\penil\Desktop\NoExisto\PruebaCaracteres.txt";
        //cambia el directorio o busca una manera de que no encuentre el directorio
        Assert.ThrowsAny<DirectoryNotFoundException>(() =>
        {
           string actual = palindroco.TextPalin(path);
        });
    }
    //5
    [Fact]
    public void FileNotFound()
    {
        Arch palindroco = new();
        string path = @"lala";
        Assert.ThrowsAny<FileNotFoundException>(() =>
        {
           string actual = palindroco.TextPalin(path);
        });
    }
    //6
    [Fact]
    public void NotCompatible()
    {
        //no funciona
        Arch palindroco = new();
        string path = @"C:\Users\penil\OneDrive\Escritorio\CETI\PROGRAMACION\Avanzada\Git\2P\tareas\1eraArch\1eraArch\Text\LoreIpsum.txt";
        //quitar
        Assert.ThrowsAny<NotSupportedException>(() =>
        {
           string actual = palindroco.TextPalin(path);
        });
    }
    //7
    [Fact]
    public void TooooBigAndHeavy()
    {
        Arch palindroco = new();
        string path = @"C:\Users\penil\VirtualBox VMs\W81_PRO64Bits_Penil\W81_PRO64Bits_Penil.txt";
        //pon un string E N O R M E, el maximo es 2147483647 bytes máximo o 2GB, pero puedes abrir un archivo de 2GB, como una imagen... abre el de vmbox 
        //8gb seran suficientes? si
        Assert.ThrowsAny<OutOfMemoryException>(() =>
        {
           string actual = palindroco.TextPalin(path);
        });
    }
    //8
    [Fact]
    public void MimeType() 
    {
        Arch palindroco = new();
        string path = @"C:\Windows\System32\WerFaultSecure.exe";
        string fileExtension = System.IO.Path.GetExtension(path).ToLower();
        if(fileExtension == ".exe"){
            throw new Exception("Wrong FileType");
        }
        Assert.ThrowsAny<Exception>(() =>
        {
           string actual = palindroco.TextPalin(path);
        });
    }
    //9
    [Fact]
    public void PathLong()
    {
        Arch palindroco = new();
        string path =@"C:\Users\penil\Desktop\uno\dos\tres\cuatro\cinco\seis\siete\ocho\nueve\diez\uno\dos\tres\cuatro\oiansdoansdiansdipnasdinasidpjasodaopsdjapdjaodsjapodjaopdsjaosdjapsdjaposdjaosdjaojdaopsdjoasdj\aaaaaaaaaaaaaaaaaaaaa\aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.txt";
        if(path.Length >= 261){
            throw new PathTooLongException("Path is too long");
        }
        Assert.ThrowsAny<PathTooLongException>(() =>
        {
           string actual = palindroco.TextPalin(path);
        });
    }
    //10
    [Fact]
    public void ArgShort()
    {
        Arch palindroco = new();
        string path = @"";
        Assert.ThrowsAny<ArgumentException>(() =>
        {
           string actual = palindroco.TextPalin(path);
        });
    }
}