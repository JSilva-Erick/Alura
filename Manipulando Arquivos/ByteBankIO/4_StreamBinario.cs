partial class Program
{
    static void EscritaBinaria()
    {
        using (var fs = new FileStream("D:\\Estudos alura\\Manipulando Arquivos\\ByteBankIO\\bin\\Debug\\net6.0\\contaCorrente.txt", FileMode.Create))
        using (var escritor = new BinaryWriter(fs)) //Binary não possui WriteLine
        {
            escritor.Write(456); //número da Agência
            escritor.Write(546544); //número da conta
            escritor.Write(1212.34); //saldo
            escritor.Write("Gustavo Braga");//Nome
        }
    }

    static void LeituraBinaria()
    {
        using (var fs = new FileStream("contaCorrente.txt", FileMode.Open))
        using(var leitor = new BinaryReader(fs))
        {
            var agencia = leitor.ReadInt32();
            var numeroConta = leitor.ReadInt32();
            var saldo = leitor.ReadDouble();
            var titular = leitor.ReadString();

            Console.WriteLine($"{agencia}/{numeroConta} {titular} {saldo}");
        }
    }
}