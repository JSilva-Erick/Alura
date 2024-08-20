using PokeGoshi.Controller;
using PokeGoshi.View;

namespace ConsumoAPI
{
    //classe do programa principal
    class Program
    {
        static void Main(String[] args)
        {
            PokegoshiControler jogo = new PokegoshiControler();
            jogo.Jogar();
        }
    }
}