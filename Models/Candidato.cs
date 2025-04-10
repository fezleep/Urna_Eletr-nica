namespace UrnaEletronica.Models;

public class Candidato
{
    public int Numero { get; set; }
    public string Nome { get; set; }
    public string Partido { get; set; }
    public string FotoPath => $@"Data\Fotos\{Numero}.png";

    public Candidato()
    {
        Nome = string.Empty;
        Partido = string.Empty;
    }
}