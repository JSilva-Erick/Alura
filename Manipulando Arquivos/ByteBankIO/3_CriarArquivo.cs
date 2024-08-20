using System.Text;

partial class Program
{
    static void CriarArquivo()
    {
        var caminhoNovoArquivo = "contasExportadas.csv";

        using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        {
            var contaComoString = "456, 7895, 4785.40, Gustavo Santos";

            var encoding = Encoding.UTF8;
            var bytes = encoding.GetBytes(contaComoString);
            fluxoDeArquivo.Write(bytes, 0, bytes.Length);
        }
    }

    static void CriarArquivoComWriter()
    {
        var caminhoNovoArquivo = "contasExportadas2.csv";
        using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.CreateNew)) //CreateNew não substitui arquivo, somente cria um novo, se existir algum arquivo gera erro
        using (var escritor = new StreamWriter(fluxoDeArquivo))
        {
            escritor.Write("456, 7895, 4785.40, Thiago");
        }
    }

    static void TestaEscrita()
    {
        var caminhoNovoArquivo = "teste.txt";
        using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.CreateNew)) //CreateNew não substitui arquivo, somente cria um novo, se existir algum arquivo gera erro
        using (var escritor = new StreamWriter(fluxoDeArquivo))
        {
            for (int i = 0; i < 10; i++)
            {
                escritor.WriteLine($"Linha {i+1}");
                escritor.Flush(); // libera itens do buffer e escreve no arquivo
                Console.WriteLine($"Linha {i+1} foi escrita, aperte Enter:");
                Console.ReadLine();
            }
        }
    }
}