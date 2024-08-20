partial class Program
{
    static void Main(string[] args)
    {

        //var caminhoNovoArquivo = "D:\\Estudos alura\\Manipulando Arquivos\\ByteBankIO\\bin\\Debug\\net6.0\\testaEscrita.txt";
        //using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.CreateNew)) //CreateNew não substitui arquivo, somente cria um novo, se existir algum arquivo gera erro
        //using (var escritor = new StreamWriter(fluxoDeArquivo))
        //{
        //    escritor.WriteLine(true);
        //    escritor.WriteLine(false);
        //    escritor.WriteLine(4343434343);
        //}

        var linhas = File.ReadAllLines("contas.txt");
        Console.WriteLine(linhas.Length);

        /*
        foreach(var line in linhas)
        {
            Console.WriteLine(line);
        }
        Console.WriteLine("Arquivo Criado");
        */

        var bytesArquivo = File.ReadAllBytes("contas.txt");
        Console.WriteLine($"O arquivo possui {bytesArquivo.Length} bytes.");
        File.WriteAllText("escrevendoComAClasseFile.txt", "Testando File.WriteAllText");

    }

}