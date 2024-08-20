using PokeGoshi.Model;
using PokeGoshi.Service;

namespace PokeGoshi.View
{
    public class PokegoshiFront
    {
        internal string BoasVindas()
        {
            Console.WriteLine("Bem-vindo ao POKEGOSHI");
            Console.WriteLine("\nPara iniciar digite o seu nome:");
            return Console.ReadLine().ToUpper();
        }
        public void MenuInicial(string Nome)
        {
            Console.Clear();
            Console.WriteLine($"{Nome} você deseja:");
            Console.WriteLine($"1 - Ver Pokemons adotados");
            Console.WriteLine($"2 - Adotar novo Pokemon");
            Console.WriteLine($"3 - Sair");
        }

        internal void BuscarPokemons(string Nome, List<PokemonResult> disponiveis)
        {
            Console.Clear();
            Console.WriteLine("Bem vindo " + Nome);
            Console.WriteLine("Estes são os Pokemons:\n");
            for (int i = 0; i < disponiveis.Count; i++)
            {
                Console.WriteLine(i + 1 + " - " + disponiveis[i].Nome);
            }
        }

        internal int EscolherPokemon(List<PokemonResult> disponiveis)
        {
            while (true)
            {
                Console.WriteLine($"Escolha seu Pokemon, opções entre entre: 1 - {disponiveis.Count}. Digite 0 para sair!");
                int escolha;
                if (int.TryParse(Console.ReadLine(), out escolha) && escolha > 0 && escolha <= disponiveis.Count)
                {
                    return escolha - 1;
                    break;
                }
                else if (escolha == 0) { return escolha; break; }
                else
                {
                    Console.WriteLine("Escolha invalida!");
                }
            }
        }

        internal void DetalhesPokemon(PokemonResult pokemonescolhido)
        {
            Console.Clear();
            Console.WriteLine($"Esses são os detalhes do pokemon {pokemonescolhido.Nome.ToUpper()}");
            Console.WriteLine("Habilidades: ");
            var detalhes = Conexao.ObterDetalhes(pokemonescolhido);
            foreach(var habilidade in detalhes.Habilidades)
            {
                Console.WriteLine(" - " + habilidade.Habilidade.Nome);
            }
        }

        internal void OpcoesAdocao(string Nome, string Pokemon)
        {
            Console.WriteLine($"\n {Nome} você deseja:");
            Console.WriteLine($"1 - Adotar {Pokemon.ToUpper()}");
            Console.WriteLine($"2 - Voltar");
        }


        internal void PokemonAdotado(string Nome, string Pokemon)
        {
            Console.Clear();

            Console.WriteLine($"Parabéns {Nome}, você acabou de adotar {Pokemon.ToUpper()}!");
            Thread.Sleep(1000);
        }
    }
}
