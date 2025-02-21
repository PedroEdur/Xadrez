using System;

public class Bispo : Peça
{
    public Bispo(string cor, int x, int y) : base(cor, x, y){}
    public override bool VerificarMovimento(int destinoX, int destinoY)
    {
        throw new NotImplementedException(); // lógica de movimentação do bispo 
    }
}