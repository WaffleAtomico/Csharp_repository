namespace AlmUnitest;
using almacenist;

public class UnitTest1
{
    [Fact]
    public async void FileNotFound_InReportByName()
    {
        Reports report= new Reports();
        try{
            await report.PrNameAsync();
        }catch(Exception ex){
            Assert.Contains("File not found:", ex.Message);
        }
    }
}