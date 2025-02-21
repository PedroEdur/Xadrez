using System;

public class Rei : Peça{
    public Rei(string cor, int x, int y) : base(cor,x ,y){}
    public override bool VerificarMovimento(int destinoX, int destinoY)
    {
        int difX = Math.Abs(destinoX - X);
        int difY = Math.Abs(destinoY - Y);

        // O Rei pode se mover apenas uma casa em qualquer direção
        return difX <= 1 && difY <= 1;
    }
}