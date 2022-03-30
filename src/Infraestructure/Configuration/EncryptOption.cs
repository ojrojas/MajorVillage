namespace MajorVillage.Infraestructure.Configuration;

public class EncryptOption
{
    public string Salt { get; set; }   
    public string PassPhrase { get; set; }
    public int SizeKey { get; set; }
    public int Iterations { get; set; }
}