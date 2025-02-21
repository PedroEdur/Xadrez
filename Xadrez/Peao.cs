using System;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
public class Peao : Peça{
    public Peao(string cor, int x, int y) : base(cor, x, y) {}

    public override bool VerificarMovimento(int destinoX, int destinoY)
    {
        return true; // logica de movimentação do peão
    }
}