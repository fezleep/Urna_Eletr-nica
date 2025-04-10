using UrnaEletronica.Models;
using UrnaEletronica.Services;

namespace UrnaEletronica;

public class FormUrna : Form
{
    private readonly VotacaoService _service = new();

    public FormUrna()
    {
        // Configuração da janela
        this.Text = "URNA ELETRÔNICA";
        this.Size = new Size(600, 400);
        this.StartPosition = FormStartPosition.CenterScreen;

        // Controles
        var lblInstrucao = new Label 
        { 
            Text = "DIGITE O NÚMERO:", 
            Location = new Point(20, 20), 
            Font = new Font("Arial", 12) 
        };

        var txtNumero = new TextBox 
        { 
            Location = new Point(20, 50), 
            Width = 100, 
            Font = new Font("Arial", 14) 
        };

        var btnConfirmar = new Button 
        { 
            Text = "CONFIRMAR", 
            Location = new Point(130, 50), 
            BackColor = Color.LightGreen,
            Font = new Font("Arial", 10, FontStyle.Bold)
        };

        var picFoto = new PictureBox 
        { 
            Location = new Point(20, 100), 
            Size = new Size(200, 200),
            SizeMode = PictureBoxSizeMode.Zoom,
            BorderStyle = BorderStyle.FixedSingle
        };

        var lblInfo = new Label 
        { 
            Location = new Point(250, 100), 
            Size = new Size(300, 200),
            Font = new Font("Arial", 12)
        };

        // Evento do botão
        btnConfirmar.Click += (sender, e) =>
        {
            if (int.TryParse(txtNumero.Text, out int numero))
            {
                var candidato = _service.BuscarCandidato(numero);
                if (candidato != null)
                {
                    try 
                    {
                        picFoto.Image = Image.FromFile(candidato.FotoPath);
                        lblInfo.Text = $"CANDIDATO: {candidato.Nome}\n\nPARTIDO: {candidato.Partido}";
                        _service.RegistrarVoto(numero);
                        MessageBox.Show("Voto confirmado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch 
                    {
                        picFoto.Image = SystemIcons.Error.ToBitmap();
                        MessageBox.Show("Foto do candidato não encontrada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Candidato não encontrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        };

        // Adiciona controles ao formulário
        this.Controls.AddRange(new Control[] { lblInstrucao, txtNumero, btnConfirmar, picFoto, lblInfo });
    }
}