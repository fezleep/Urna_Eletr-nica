using System.Security.Cryptography;
using System.Text;
using UrnaEletronica.Models;

namespace UrnaEletronica.Services;

public class VotacaoService
{
    private readonly List<Candidato> _candidatos = new()
    {
        new Candidato { Numero = 10, Nome = "Jorge Vasconcelos", Partido = "PT" },
        new Candidato { Numero = 20, Nome = "Fábio Lourenço", Partido = "PL" }
    };

    private string _ultimoHash = string.Empty;
    private readonly string _caminhoArquivo = @"Data\votos.txt";

    public Candidato BuscarCandidato(int numero)
    {
        return _candidatos.FirstOrDefault(c => c.Numero == numero);
    }

    public void RegistrarVoto(int numero)
    {
        var voto = new Voto
        {
            NumeroCandidato = numero,
            Hash = GerarHash(numero),
            HashAnterior = _ultimoHash
        };

        Directory.CreateDirectory("Data");
        File.AppendAllText(_caminhoArquivo, $"{voto.NumeroCandidato}|{voto.DataHora}|{voto.Hash}|{voto.HashAnterior}{Environment.NewLine}");
        _ultimoHash = voto.Hash;
    }

    private string GerarHash(int numero)
    {
        using var sha256 = SHA256.Create();
        byte[] hashBytes = sha256.ComputeHash(
            Encoding.UTF8.GetBytes($"{numero}{DateTime.Now.Ticks}{_ultimoHash}"));
        return BitConverter.ToString(hashBytes).Replace("-", "");
    }
}