using PokeGoshi.Model;
using PokeGoshi.Service;
using PokeGoshi.View;

namespace PokeGoshi.Controller
{
    public class PokegoshiControler
    {
        private PokegoshiFront PokegoshiFront { get; set; }
        private Conexao Conexao { get; set; }
        private List<PokemonResult> PokemonsAdotados { get; set; }
        private List<PokemonResult> TodosPokemons { get; set; }

        public PokegoshiControler()
        {
            PokegoshiFront = new PokegoshiFront();
            Conexao = new Conexao();
            TodosPokemons = Conexao.GetEspeciesDisponiveis();
            PokemonsAdotados = new List<PokemonResult>();
        }
        public void Jogar()
        {
            string Nome = PokegoshiFront.BoasVindas();
            string escolhaUsuario;
            int jogar = 1;

            while (jogar == 1)
            {
                PokegoshiFront.MenuInicial(Nome);
                escolhaUsuario = Console.ReadLine();
                switch (escolhaUsuario)
                {
                    case "1":
                        PokegoshiFront.BuscarPokemons(Nome, PokemonsAdotados);
                        var pokemonEscolhido = PokegoshiFront.EscolherPokemon(PokemonsAdotados);
                        if (pokemonEscolhido != 0)
                        {
                            PokegoshiFront.DetalhesPokemon(PokemonsAdotados[pokemonEscolhido]);
                        }
                        Console.ReadLine();
                        break;
                    case "2":
                        PokegoshiFront.BuscarPokemons(Nome, TodosPokemons);
                        int escolha = PokegoshiFront.EscolherPokemon(TodosPokemons);
                        PokegoshiFront.DetalhesPokemon(TodosPokemons[escolha]);
                        PokegoshiFront.OpcoesAdocao(Nome, TodosPokemons[escolha].Nome);
                        while (true)
                        {
                            var escolhaAdocao = Console.ReadLine();
                            if (escolhaAdocao == "1")
                            {
                                PokegoshiFront.PokemonAdotado(Nome, TodosPokemons[escolha].Nome);
                                PokemonsAdotados.Add(TodosPokemons[escolha]);
                                break;
                            }
                            else if (escolhaAdocao == "2") break;
                            else
                            {
                                Console.WriteLine("Opção Invalida!");
                                PokegoshiFront.OpcoesAdocao(Nome, TodosPokemons[escolha].Nome);
                                break;
                            }
                        }
                        break;
                    case "3":
                        Console.WriteLine("Obrigado por jogar Pokegoshi");
                        jogar = 0;
                        break;

                }


            }
        }
    }
}
