using ByteBankIO;

partial class Program
{
    static void UsandoStreamReader(string[] args)
    {
        var enderecoDoArquivo = "contas.txt";
        using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDeArquivo);

            //var linha = leitor.ReadLine(); lê somente a primeira linha
            //var texto = leitor.ReadToEnd(); lê todo o texto, só que carrega o arquivo todo de uma vez, o que pode ser prejudicial com arquivos muito grandes
            //var numero = leitor.Read(); Pega o primeiro byte
            while (!leitor.EndOfStream) // verifica se é o final do arquivo
            {
                var linha = leitor.ReadLine();
                var contaCorrente = ConverterStringParaContaCorrente(linha);
                var msg = $"{contaCorrente.Titular.Nome}: Conta número {contaCorrente.Numero}, ag {contaCorrente.Numero}, Saldo {contaCorrente.Saldo}";
                Console.WriteLine(msg);
            }
        }
        Console.ReadLine();
    }

    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        var campos = linha.Split(',');
        var agencia = campos[0];
        var numero = campos[1];
        var saldo = campos[2].Replace('.', ',');
        var nomeTitular = campos[3];

        var titular = new Cliente();
        titular.Nome = nomeTitular;

        var resultado = new ContaCorrente(int.Parse(agencia), int.Parse(numero));
        resultado.Depositar(double.Parse(saldo));
        resultado.Titular = titular;

        return resultado;
    }
}