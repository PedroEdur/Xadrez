using System;

namespace Xadrez;
partial class Form1 : Form
{
    public static int sizeOfTabuleiro = 8;
    private int origemX = -1, origemY = -1; 
    public Peça[,] tabuleiro = new Peça[sizeOfTabuleiro,sizeOfTabuleiro];
    private PictureBox pecaSelecionada = null;
    public ArquivoJogo arquivoJogo = new ArquivoJogo();
    public bool  vezBranco = true;
    public int numerojogadas = 0;
    public Form1(){
        InitializeComponent();
    }

    public void cliqueNoTabuleiro(Peça peca)
    {
        if (origemX == -1 && origemY == -1) // Primeiro clique: seleciona a peça
        {
            if (peca is not CasaVazia)
            {
                if (vezBranco && peca.cor == Enumcor.Branco)
                {
                    pecaSelecionada = peca.pictureBox;
                    origemX = peca.X;
                    origemY = peca.Y;
                    MessageBox.Show($"Peça selecionada em ({peca.X}, {peca.Y})");
                }
                else if (!vezBranco && peca.cor == Enumcor.Preto)
                {
                    pecaSelecionada = peca.pictureBox;
                    origemX = peca.X;
                    origemY = peca.Y;
                    MessageBox.Show($"Peça selecionada em ({peca.X}, {peca.Y})");
                }
                else
                {
                    MessageBox.Show("Vez do outro jogador");
                }
            }
        }
        else // Segundo clique: tenta mover a peça
        {
            Peça pecaOrigem = tabuleiro[origemX, origemY];
            Peça pecaDestino = tabuleiro[peca.X, peca.Y];

            if (pecaOrigem.cor == pecaDestino.cor)
            {
                MessageBox.Show("Movimento Inválido, porque é do mesmo time!");
                pecaSelecionada = null;
                origemX = -1;
                origemY = -1;
                return;
            }

            // Verificar se o caminho está livre, se for uma peça com movimento contínuo (torre, bispo, rainha)
            if (pecaOrigem is Torre || pecaOrigem is Rainha || pecaOrigem is Bispo)
            {
                if (!CaminhoLivre(pecaOrigem, peca.X, peca.Y))
                {
                    MessageBox.Show("O caminho está bloqueado!");
                    pecaSelecionada = null;
                    origemX = -1;
                    origemY = -1;
                    return;
                }
            }

            // Verifica se o movimento é válido
            if (!pecaOrigem.Verificarmovimento(peca.X, peca.Y))
            {
                MessageBox.Show("Movimento Inválido!");
                pecaSelecionada = null;
                origemX = -1;
                origemY = -1;
                return;
            }

            if (pecaDestino is CasaVazia) // Se o destino estiver vazio, apenas move a peça
            {
                // Atualiza o tabuleiro
                tabuleiro[origemX, origemY] = new CasaVazia(origemX * 50, origemY * 50, "casaVazia.png", Enumcor.vazio);
                tabuleiro[peca.X, peca.Y] = pecaOrigem;

                // Atualiza as coordenadas da peça movida
                pecaOrigem.X = peca.X;
                pecaOrigem.Y = peca.Y;

                // Atualiza a posição visualmente
                pecaOrigem.pictureBox.Location = new Point(peca.X * 50, peca.Y * 50);
            }
            else // Se houver outra peça, remove a peça
            {
                this.Controls.Remove(pecaDestino.pictureBox);
                tabuleiro[peca.X, peca.Y] = pecaOrigem;
                tabuleiro[origemX, origemY] = new CasaVazia(origemX * 50, origemY * 50, "casaVazia.png", Enumcor.vazio);

                // Atualiza a posição visualmente
                pecaOrigem.X = peca.X;
                pecaOrigem.Y = peca.Y;
                pecaOrigem.pictureBox.Location = new Point(peca.X * 50, peca.Y * 50);
                if (pecaDestino is Rei){
                    switch(pecaDestino.cor){
                        case Enumcor.Branco:
                            MessageBox.Show("Team preto vencedor!");
                            Application.Exit();
                        break;

                        case Enumcor.Preto:
                            MessageBox.Show("Team white vencedor!");
                            Application.Exit();
                        break;
                    }
                }
            }

            // Finaliza a jogada e alterna a vez
            switch (vezBranco)
            {
                case true:
                    vezBranco = false;
                    break;
                case false:
                    vezBranco = true;
                    break;
            }

            // Atualiza a interface
            this.Refresh();
            arquivoJogo.SalvarJogadas(tabuleiro);

            // Reseta os valores para a próxima jogada
            pecaSelecionada = null;
            origemX = -1;
            origemY = -1;
        }
    }
  
    // Método para verificar se o caminho está livre para peças com movimento contínuo
    private bool CaminhoLivre(Peça pecaOrigem, int destinoX, int destinoY)
    {
        if (pecaOrigem is Torre)
        {
            return VerificarCaminhoTorre(pecaOrigem.X, pecaOrigem.Y, destinoX, destinoY);
        }
        else if (pecaOrigem is Bispo)
        {
            return VerificarCaminhoBispo(pecaOrigem.X, pecaOrigem.Y, destinoX, destinoY);
        }
        else if (pecaOrigem is Rainha)
        {
            return VerificarCaminhoRainha(pecaOrigem.X, pecaOrigem.Y, destinoX, destinoY);
        }
        return true;
    }

    // Exemplo de verificação para a Torre
    private bool VerificarCaminhoTorre(int origemX, int origemY, int destinoX, int destinoY)
    {
        if (origemX == destinoX)  // Movimento vertical
        {
            int start = Math.Min(origemY, destinoY) + 1;
            int end = Math.Max(origemY, destinoY);
            for (int y = start; y < end; y++)
            {
                if (tabuleiro[origemX, y] is not CasaVazia)
                {
                    return false;  // Caminho bloqueado
                }
            }
        }
        else if (origemY == destinoY)  // Movimento horizontal
        {
            int start = Math.Min(origemX, destinoX) + 1;
            int end = Math.Max(origemX, destinoX);
            for (int x = start; x < end; x++)
            {
                if (tabuleiro[x, origemY] is not CasaVazia)
                {
                    return false;  // Caminho bloqueado
                }
            }
        }
        return true;  // Caminho livre
    }

    // Exemplo de verificação para o Bispo
    private bool VerificarCaminhoBispo(int origemX, int origemY, int destinoX, int destinoY)
    {
        // Verifica se o movimento é realmente diagonal
        if (Math.Abs(origemX - destinoX) != Math.Abs(origemY - destinoY))
        {
            return false;  // Não é um movimento diagonal válido
        }

        // Caminho na diagonal
        int dx;
        int dy;

        // Substituindo o operador ternário por if-else
        if (destinoX > origemX)
        {
            dx = 1;
        }
        else
        {
            dx = -1;
        }

        if (destinoY > origemY)
        {
            dy = 1;
        }
        else
        {
            dy = -1;
        }

        int x = origemX + dx;
        int y = origemY + dy;

        for (; x != destinoX && y != destinoY; x += dx, y += dy)
        {
            if (tabuleiro[x, y] is not CasaVazia)
            {
                return false;  // Caminho bloqueado
            }
        }

        return true;  // Caminho livre
    }

    // Exemplo de verificação para a Rainha
    private bool VerificarCaminhoRainha(int origemX, int origemY, int destinoX, int destinoY)
    {
        // Se o movimento é diagonal (como um bispo)
        if (Math.Abs(origemX - destinoX) == Math.Abs(origemY - destinoY))
        {
            return VerificarCaminhoBispo(origemX, origemY, destinoX, destinoY);
        }
        // Se o movimento é reto (como uma torre)  
        else if (origemX == destinoX || origemY == destinoY)
        {
            return VerificarCaminhoTorre(origemX, origemY, destinoX, destinoY);
        }

        return false;  // Movimento inválido para a Rainha
    }
}