namespace UrnaEletronica.Models;

public class Voto
{
    public int NumeroCandidato { get; set; }
    public DateTime DataHora { get; set; } = DateTime.Now;
    public string Hash { get; set; }
    public string HashAnterior { get; set; }

    public Voto()
    {
        Hash = string.Empty;
        HashAnterior = string.Empty;
    }
}