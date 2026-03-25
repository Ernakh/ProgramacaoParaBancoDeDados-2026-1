static void Main(string[] args)
{
    string[,] tabuleiro = new string[3, 3];

    bool temVencedor = false;
    bool vez = true;//true = X e false = O
    int jogadas = 0;

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            tabuleiro[i, j] = " ";
        }
    }

    mostrarTabuleiro(tabuleiro);

    while (!temVencedor)
    {
        Console.WriteLine("Informe um valor para linha e outro para coluna");
        int linha = int.Parse(Console.ReadLine()) - 1;
        int coluna = int.Parse(Console.ReadLine()) - 1;

        if ((linha > 2 || coluna > 2) || (linha <0 || coluna <0))
        {
            Console.WriteLine("Opção inválida, digite novamente!");
            continue;
        }

        if (tabuleiro[linha, coluna] != " ")
        {
            Console.WriteLine("Opção inválida, digite novamente!");
            continue;
        }

        tabuleiro[linha, coluna] = vez ? "X" : "O";

        mostrarTabuleiro(tabuleiro);

        vez = !vez;
        jogadas++;

        temVencedor = verificarVencedor(tabuleiro);

        if (jogadas >= 9)
        {
            break;
        }

    }

    if (temVencedor)
    {
        Console.WriteLine("Parabéns, o " + (vez ? "O" : "X") + " é o vencedor!");
    }
    else
    {
        Console.WriteLine("Deu velha!");
    }

}

private static bool verificarVencedor(string[,] tabuleiro)
{
    //linahs e colunas
    for (int i = 0; i < 3; i++)
    {
        if (tabuleiro[i,0] == tabuleiro[i, 1] &&
            tabuleiro[i, 0] == tabuleiro[i, 2] && 
            tabuleiro[i,0] != " ")
        {
            return true;
        }

        if (tabuleiro[0, i] == tabuleiro[1, i] &&
           tabuleiro[0, i] == tabuleiro[2, i] &&
           tabuleiro[0, i] != " ")
        {
            return true;
        }

    }

    //diagonal principal
    if (tabuleiro[0,0 ] == tabuleiro[1, 1] &&
        tabuleiro[0, 0] == tabuleiro[2, 2] &&
        tabuleiro[0, 0] != " ")
    {
        return true;
    }

    //diagonal secundaria
    if (tabuleiro[0, 2] == tabuleiro[1, 1] &&
        tabuleiro[0, 2] == tabuleiro[2, 0] &&
        tabuleiro[0, 2] != " ")
    {
        return true;
    }

    return false;
}

private static void mostrarTabuleiro(string[,] tabuleiro)
{
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write("[" + tabuleiro[i, j] + "]");
        }

        Console.WriteLine();
    }
}


