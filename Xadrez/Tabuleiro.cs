public class Tabuleiro
{
    public Peça[,] Pecas { get; private set; }
    public Rainha[] Rainhas { get; private set; }
    public Rei[] reis { get; private set; }
    public Torre[] torres { get; private set; }
    public Bispo[] bispos { get; private set; }
    public Cavalo[] cavalos { get; private set; }
    public Peao[] peaos { get; private set; }

    public Tabuleiro()
    {
        Pecas = new Peça[8, 8];
        Rainhas = new Rainha[2]; // uma preta e outra branca;
        cavalos = new Cavalo[4]; // dois black e dois white;
        reis = new Rei[2]; // um black e um white;
        torres = new Torre[4]; // dois pretos e dois white;
        bispos = new Bispo[4]; // dois black e dois white.
        peaos = new Peao[16]; // 8 peões do time black e 8 peões do time white 

        InicializarTabuleiro();
    }

    private void InicializarTabuleiro()
    {
        // peças time black
        Pecas[1, 1] = new Torre("preto", 1, 1); // torre black
        Pecas[1, 2] = new Cavalo("preto", 1, 2); // cavalo black
        Pecas[1, 3] = new Bispo("preto", 1, 3); // bispo black
        Pecas[1, 4] = new Rainha("preto", 1, 4); //rainha black
        Pecas[1, 5] = new Rei("preto", 1, 5); // rei black
        Pecas[1, 6] = new Bispo("preto", 1, 6); // bispo balck
        Pecas[1, 7] = new Cavalo("preto", 1, 7); // cavalo black
        Pecas[1, 8] = new Torre("preto", 1, 8); // torre black

        // peões black (linha 1)
        for (int i = 2; i < 9; i++)
        {
            Pecas[2, i] = new Peao("preto", 2, i); // Peões black
        }

        // peças time white
        Pecas[8, 1] = new Torre("branco", 8, 1); // Torre branca
        Pecas[8, 2] = new Cavalo("branco", 8, 2); // Cavalo branco
        Pecas[8, 3] = new Bispo("branco", 8, 3); // Bispo branco
        Pecas[8, 4] = new Rainha("branco", 8, 4); // Rainha branca
        Pecas[8, 5] = new Rei("branco", 8, 5); // Rei branco
        Pecas[8, 6] = new Bispo("branco", 8, 6); // Bispo branco
        Pecas[8, 7] = new Cavalo("branco", 8, 7); // Cavalo branco
        Pecas[8, 8] = new Torre("branco", 8, 8); // Torre branca

        // peões white (linha 6)
        for (int i = 7; i < 9; i++)
        {
            Pecas[7, i] = new Peao("branco", 7, i); // Peões brancos
        }

        // Inicializando as rainhas após a criação das peças no tabuleiro
        Rainhas[1] = new Rainha("preto", 1, 4); // Rainha preta
        Rainhas[2] = new Rainha("branco", 8, 4); // Rainha branca

        // Inicializando os reis
        reis[1] = new Rei("preto", 1, 5); // Rei preto
        reis[2] = new Rei("branco", 8, 5); // Rei branco

        // Inicializando as torres
        torres[1] = new Torre("preto", 1, 1); // Torre preta
        torres[2] = new Torre("preto", 1, 8); // Torre preta
        torres[3] = new Torre("branco", 8, 1); // Torre branca
        torres[4] = new Torre("branco", 8, 8); // Torre branca

        // Inicializando os cavalos
        cavalos[1] = new Cavalo("preto", 1, 2); // Cavalo preto
        cavalos[2] = new Cavalo("preto", 1, 7); // Cavalo preto
        cavalos[3] = new Cavalo("branco", 8, 2); // Cavalo branco
        cavalos[4] = new Cavalo("branco", 8, 7); // Cavalo branco

        // Inicializando os bispos
        bispos[1] = new Bispo("preto", 1, 3); // Bispo preto
        bispos[2] = new Bispo("preto", 1, 6); // Bispo preto
        bispos[3] = new Bispo("branco", 8, 3); // Bispo branco
        bispos[4] = new Bispo("branco", 8, 6); // Bispo branco
    }
}