using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using bytebank_ATENDIMENTO.bytebank.Util;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

#region Exemplo Arrays
Array amostra = new double[5];
amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);

//[5,9][1,8][7,1][10][6,9]
//TestaMediana(amostra);
//TestaArrayInt();
//TestaBuscarPalavra();
//TesteContas();

void TestaArrayInt()
{
    int[] idades = new int[5];
    idades[0] = 30;
    idades[1] = 40;
    idades[2] = 17;
    idades[3] = 21;
    idades[4] = 18;

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

void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];

    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.Write($"Digite {i + 1}ª Palavra: ");
        arrayDePalavras[i] = Console.ReadLine();
    }

    Console.Write("Digite palavara a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach (string palavra in arrayDePalavras)
    {
        if (palavra.Equals(busca))
        {
            Console.WriteLine($"Palavra encontrada = {busca}.");
            break;
        }
    }

}

void TestaMediana(Array array)
{
    if ((array == null) || (array.Length == 0))
    {
        Console.WriteLine("Array para cálculo da mediana está vazio ou nulo.");
    }

    double[] numerosOrdenados = (double[])array.Clone();
    Array.Sort(numerosOrdenados);
    //[1,8][5,9][6,9][7,1][10]

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;
    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] :
                                   (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;
    Console.WriteLine($"Com base na amostra a mediana = {mediana}");
}

void TesteContas()
{
    ListaContaCorrente listaDeContas = new ListaContaCorrente();

    listaDeContas.AdcionarContaCorrente(new ContaCorrente(884, "4456668-B"));
    listaDeContas.AdcionarContaCorrente(new ContaCorrente(894, "7781438-C"));
    listaDeContas.AdcionarContaCorrente(new ContaCorrente(884, "4456668-B"));
    listaDeContas.AdcionarContaCorrente(new ContaCorrente(894, "7781438-C"));
    listaDeContas.AdcionarContaCorrente(new ContaCorrente(884, "4456668-B"));
    listaDeContas.AdcionarContaCorrente(new ContaCorrente(894, "7781438-C"));
    ContaCorrente ContaDoErick = new ContaCorrente(777, "1234567-A");
    listaDeContas.AdcionarContaCorrente(ContaDoErick);
    Console.WriteLine();
    //listaDeContas.ExibeLista();
    //listaDeContas.RemoverConta(ContaDoErick);
    for (int i = 0; i < listaDeContas.tamanho; i++)
    {
        Console.WriteLine($"Conta: {i + 1} \nAgência {listaDeContas[i].Numero_agencia} - Conta {listaDeContas[i].Conta}");
    }
}
#endregion

List<ContaCorrente> _listaDeContas = new() {
    new ContaCorrente(95, "123456-X") {Saldo=100, Titular = new Cliente{Cpf="12345678", Nome="Erick", Profissao="DEV"} },
    new ContaCorrente(95, "951258-X") {Saldo=200, Titular = new Cliente{Cpf="12333221", Nome="Nayara", Profissao="Psi"}},
    new ContaCorrente(94, "987321-W") {Saldo=60, Titular = new Cliente{Cpf="12355312", Nome="Teazinha", Profissao="Prof"}}
};

AtendimentoCliente();


void AtendimentoCliente()
{
    try
    {
        char opcao = '0';
        while (opcao != '6')
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===       Atendimento       ===");
            Console.WriteLine("===1 -   Cadastrar Conta    ===");
            Console.WriteLine("===2 -    Listar Contas     ===");
            Console.WriteLine("===3 -    Remover Conta     ===");
            Console.WriteLine("===4 -   Ordenar Contas     ===");
            Console.WriteLine("===5 -   Pesquisar Conta    ===");
            Console.WriteLine("===6 -   Sair do Sistema    ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n\n");
            Console.Write("Digite a opção desejada: ");
            try
            {
                opcao = Console.ReadLine()[0];
            }
            catch (Exception excecao)
            {
                Console.WriteLine($"Aconteceu um erro --> {excecao.Message}");
                throw new ByteBankException(excecao.Message);
            }
            switch (opcao)
            {
                case '1':
                    CadastrarConta();
                    break;
                case '2':
                    ListarContas();
                    break;
                case '3':
                    RemoverConta();
                    break;
                case '4':
                    OrdenarContas();
                    break;
                case '5':
                    PesquisarConta();
                    break;
                default:
                    Console.WriteLine("Opcao não implementada.");
                    break;
            }
        }
    }
    catch (ByteBankException excecao)
    {
        Console.WriteLine($"Aconteceu um erro --> {excecao.Message}");
    }
}

void PesquisarConta()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===     PESQUISAR CONTAS    ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.WriteLine("Digite (1) para pesquisar por Conta ou (2) para pesquisar por CPF: ");
    switch (int.Parse(Console.ReadLine()))
    {
        case 1:
            {
                Console.WriteLine("Digite a Conta:");
                string conta = Console.ReadLine();
                BucarContaPorNumeroConta(conta);
                break;
            }
        case 2:
            {
                Console.WriteLine("Digite o CPF: ");
                string conta = Console.ReadLine();
                BuscarContaPorCPF(conta);
                break;
            }
        default:
            Console.WriteLine("Opção inválida");
            break;
    }

}

void BucarContaPorNumeroConta(string? NumeroConta)
{
    //ContaCorrente busca = null;
    //foreach (ContaCorrente item in _listaDeContas)
    //{
    //    if (item.Conta == NumeroConta)
    //    {
    //        busca = item;
    //        break;
    //    }
    //}
    //if (busca != null)
    //{
    //    Console.WriteLine(busca.ToString());
    //}
    //else
    //{
    //    Console.WriteLine(".. Conta não encontrada ..");
    //}
    Console.WriteLine((from i in _listaDeContas
                      where i.Conta == NumeroConta
                      select i).FirstOrDefault());
    Console.ReadKey();
}

void BuscarContaPorCPF(string? cpf)
{
    //ContaCorrente busca = null;
    //foreach (ContaCorrente item in _listaDeContas)
    //{
    //    if (item.Titular.Cpf == cpf)
    //    {
    //        busca = item;
    //        break;
    //    }
    //}
    //if (busca != null)
    //{
    //    Console.WriteLine(busca.ToString());
    //}
    //else
    //{
    //    Console.WriteLine(".. Conta não encontrada ..");
    //}
    Console.WriteLine(_listaDeContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault());
    Console.ReadKey();
}

void OrdenarContas()
{
    _listaDeContas.Sort();
    Console.WriteLine(".. Lista de contas ordenadas ..");
    Console.ReadLine();

}

void RemoverConta()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===      REMOVER CONTA      ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.WriteLine("Digite a Agência:");
    int agencia = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite a Conta:");
    string conta = Console.ReadLine();
    ContaCorrente remover = null;
    foreach (ContaCorrente item in _listaDeContas)

        if (item.Conta == conta && item.Numero_agencia == agencia)
        {
            remover = item;
            break;
        }
    if (remover != null)
    {
        _listaDeContas.Remove(remover);
        Console.WriteLine(".. Conta Removida ..");
    }
    else
    {
        Console.WriteLine(".. Conta não encontrada ..");
    }
    Console.ReadKey();
}


void ListarContas()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===     LISTA DE CONTAS     ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    if (_listaDeContas.Count <= 0)
    {
        Console.WriteLine("... Não há contas cadastradas! ...");
        Console.ReadKey();
        return;
    }
    foreach (ContaCorrente item in _listaDeContas)
    {
        Console.WriteLine(item.ToString());
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Console.ReadKey();
    }

}

void CadastrarConta()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===   CADASTRO DE CONTAS    ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.WriteLine("=== Informe dados da conta ===");
    Console.Write("Número da conta: ");
    string numeroConta = Console.ReadLine();

    Console.Write("Número da Agência: ");
    int numeroAgencia = int.Parse(Console.ReadLine());

    ContaCorrente conta = new(numeroAgencia, numeroConta!);

    Console.Write("Informe o saldo inicial: ");
    conta.Saldo = double.Parse(Console.ReadLine());

    Console.Write("Infome nome do Titular: ");
    conta.Titular.Nome = Console.ReadLine();

    Console.Write("Infome CPF do Titular: ");
    conta.Titular.Cpf = Console.ReadLine();

    Console.Write("Infome Profissão do Titular: ");
    conta.Titular.Profissao = Console.ReadLine();

    _listaDeContas.Add(conta);
    Console.WriteLine("... Conta cadastrada com sucesso! ...");
    Console.ReadKey();
}
