using System;

public abstract class Peça{
    public string Cor {get; set;} // cor da peça
    public int X{get; set;} // linha 
    public int Y {get; set;} // coluna

    public Peça(string cor, int x, int y){
        this.Cor = cor;
        this.X = x;
        this.Y = Y;
    }

    public abstract bool VerificarMovimento(int destinoX, int destinoY); // vai verificar se o movimento é válido 
}