namespace Xadrez;

partial class Form1
{
    private Random random = new Random();
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private System.ComponentModel.IContainer components = null;
    private const int GridSize = 8;
    private Button[,] grid = new Button[GridSize, GridSize];

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(850, 850);
        this.Text = "xadrez";

        for (int x = 0; x < GridSize; x++)
        {
            for (int y = 0; y < GridSize; y++)
            {
                Button botao = new Button();
                botao.Size = new Size(50, 50);
                botao.Location = new Point(50 * x, 50 * y);
                grid[x, y] = botao;
                this.Controls.Add(botao);
            }
        }

        PictureBox rei = new PictureBox();
        rei.Location = new Point(50, 50);
        rei.Size = new Size(50, 50);
        rei.SizeMode = PictureBoxSizeMode.StretchImage;

        try
        {
            string path = Path.Combine(Application.StartupPath, "imagens", "Rei branco.png");
            rei.Image = Image.FromFile(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao carregar imagem: " + ex.Message);
        }

        this.Controls.Add(rei);
        rei.BringToFront();

        PictureBox rainha = new PictureBox();
        rainha.Location = new Point(10, 10);
        rainha.Size = new Size(50, 50);
        rainha.SizeMode = PictureBoxSizeMode.StretchImage;

        try
        {
            string path = Path.Combine(Application.StartupPath, "imagens", "Rainha branco.png");
            rainha.Image = Image.FromFile(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao carregar imagem: " + ex.Message);
        }

        this.Controls.Add(rainha);
        rainha.BringToFront();

        PictureBox torre = new PictureBox();
        torre.Location = new Point(0, 0);
        torre.Size = new Size(50, 50);
        torre.SizeMode = PictureBoxSizeMode.StretchImage;

        try
        {
            string path = Path.Combine(Application.StartupPath, "imagens", "Torre branco.png");
            torre.Image = Image.FromFile(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao carregar imagem: " + ex.Message);
        }

        this.Controls.Add(torre);
        torre.BringToFront();

        PictureBox cavalo = new PictureBox();
        cavalo.Location = new Point(100, 100);
        cavalo.Size = new Size(50, 50);
        cavalo.SizeMode = PictureBoxSizeMode.StretchImage;

        try
        {
            string path = Path.Combine(Application.StartupPath, "imagens", "Cavalo branco.png");
            cavalo.Image = Image.FromFile(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao carregar imagem: " + ex.Message);
        }

        this.Controls.Add(cavalo);
        cavalo.BringToFront();

        PictureBox bispo = new PictureBox();
        bispo.Location = new Point(40, 50);
        bispo.Size = new Size(50, 50);
        bispo.SizeMode = PictureBoxSizeMode.StretchImage;

        try
        {
            string path = Path.Combine(Application.StartupPath, "imagens", "Bispo branco.png");
            bispo.Image = Image.FromFile(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao carregar imagem: " + ex.Message);
        }

        this.Controls.Add(bispo);
         bispo.BringToFront();

        PictureBox peao = new PictureBox();
        peao.Location = new Point(50, 50);
        peao.Size = new Size(50, 50);
        peao.SizeMode = PictureBoxSizeMode.StretchImage;

        try
        {
            string path = Path.Combine(Application.StartupPath, "imagens", "Peão branco.png");
            peao.Image = Image.FromFile(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao carregar imagem: " + ex.Message);
        }

        this.Controls.Add(peao);
        peao.BringToFront();
    }
}