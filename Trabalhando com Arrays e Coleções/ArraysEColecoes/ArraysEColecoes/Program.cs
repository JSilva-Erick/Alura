Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

Array amostra = new double[5];

amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);

//TestaArrayInt();
//TestaBuscaPalavra();
//Mediana(amostra);
Media(amostra);

void TestaArrayInt()
{
    int[] idades = [30, 40, 17, 21, 18];
    Console.WriteLine($"Tamanho do Array {idades.Length}");

    int acumulador = 0;
    for (int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        Console.WriteLine($"índice [{i}] = {idade}");
        acumulador += idade;
    }
    int media = acumulador / idades.Length;
    Console.WriteLine($"Média de idades = {media}");
}

void TestaBuscaPalavra()
{
    string[] Palavras = new string[5];
    for (int i = 0; i < Palavras.Length; i++)
    {
        Console.WriteLine("Digite uma palavra: ");
        Palavras[i] = Console.ReadLine();

    }
    Console.WriteLine("Digite a palavra que deseja buscar:");
    string busca = Console.ReadLine();

    foreach (var palavra in Palavras)
    {
        if (palavra.Equals(busca))
        {
            Console.WriteLine($"Palavra encontrada! {busca}");
            break;
        }
        else
        {
            Console.WriteLine("Palavra não encontrada");
        }
    }
}




void Mediana(Array array)
{
    double[] numerosOrdenados = (double[])amostra.Clone();
    Array.Sort(numerosOrdenados);

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;

    Console.WriteLine($"o tamanho é {tamanho} o meio é {meio}");
    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] : (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;
    Console.WriteLine($"A mediana é {mediana}");
}


void Media(Array array)
{
    double acumulador = 0;
    double media;
    foreach(double i in array)
    {
        acumulador += i;
    }
    media = acumulador / array.Length;
    Console.WriteLine($"A média dos números é {media}");
}