using bytebank.Modelos.Conta;

namespace bytebank_ATENDIMENTO.bytebank.Util
{
    internal class ListaContaCorrente
    {
        int _proximaPosicao = 0;

        private ContaCorrente[] _itens = null;

        public ListaContaCorrente(int tamanhoInicial = 5)
        {
            _itens = new ContaCorrente[tamanhoInicial];
        }

        public void AdcionarContaCorrente(ContaCorrente conta)
        {
            VerificarTamanhoNecessario(_proximaPosicao + 1);
            _itens[_proximaPosicao] = conta;
            Console.WriteLine($"Conta criada na posição {_proximaPosicao}.");
            _proximaPosicao++;
        }

        public void VerificarTamanhoNecessario(int tamanhoNecessario)
        {
            if (_itens.Length > tamanhoNecessario)
            {
                return;
            }
            else
            {
                Console.WriteLine("Aumentando a capacidade da lista");
                ContaCorrente[] newArray = new ContaCorrente[tamanhoNecessario];
                for (int i = 0; i < _itens.Length; i++)
                {
                    newArray[i] = _itens[i];
                }
                _itens = newArray;
                return;
            }
        }

        public ContaCorrente VerificarMaiorSaldo()
        {
            ContaCorrente conta = null;
            double MaiorValor = 0;
            for (int i = 0; i < _itens.Length; i++)
            {
                if (_itens[i] != null)
                {

                    if (_itens[i].Saldo != 0)
                    {
                        MaiorValor = _itens[i].Saldo;
                        conta = _itens[i];
                    }
                }
                else break;
            }
            return conta;

        }

        public void ExibeLista()
        {
            int posicao = 0;
            foreach (ContaCorrente conta in _itens)
            {
                if (conta == null) break;
                Console.WriteLine($"Conta {posicao + 1}:\nAgência: {conta.Numero_agencia} - Conta:{conta.Conta}");
            }
        }

        public void RemoverConta(ContaCorrente conta)
        {
            int indiceItem = -1;
            for (int i = 0; i < _itens.Length; i++)
            {
                if (conta == _itens[i])
                {
                    indiceItem = i;
                    break;
                }
            }
            for (int i = indiceItem; i < _proximaPosicao - 1; ++i)
            {
                _itens[i] = _itens[i + 1];
            }
            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
            Console.WriteLine("Conta Removida");
        }

        public ContaCorrente this[int indice]
        {
            get
            {
                return RecuperarConta(indice);
            }
        }

        public ContaCorrente RecuperarConta(int indice)
        {
            if (indice >= _proximaPosicao || indice < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }
            return _itens[indice];
        }

        public int tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }
    }
}
