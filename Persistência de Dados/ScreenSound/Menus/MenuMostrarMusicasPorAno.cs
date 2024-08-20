using ScreenSound.BD;
using ScreenSound.Modelos;


namespace ScreenSound.Menus
{
    internal class MenuMostrarMusicasPorAno : Menu
    {
        public override void Executar(DAL<Artista> artistaDAL)
        {
            base.Executar(artistaDAL);
            ExibirTituloDaOpcao("Musicas por ANO de Lançamento!");
            Console.Write("Digite o Ano de lançamento: ");
            var AnoLancamento = Convert.ToInt32(Console.ReadLine()!);
            var musicaDAL = new DAL<Musica>(new ScreenSoundContext());
            var listaDeMusicas = musicaDAL.ListarPor(a => a.AnoLancamento == AnoLancamento);
            foreach(var musica in listaDeMusicas)
            {
                Console.WriteLine($"{musica.Nome} - {musica.AnoLancamento}");
            }
            Console.WriteLine("Aperte qualquer tecla para voltar");
            Console.ReadKey();
        }
    }
}
